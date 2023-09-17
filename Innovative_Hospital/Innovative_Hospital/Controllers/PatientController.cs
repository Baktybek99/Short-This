using Innovative_Hospital_BLL.Services;
using Innovative_Hospital_BLL.Services.MedicalCardService;
using Innovative_Hospital_BLL.Services.Register;
using Innovative_Hospital_BLL.ViewModels.MedicalCard;
using Innovative_Hospital_BLL.ViewModels.PatientViewModels;
using Innovative_Hospital_DAL.Models;
using Innovative_Hospital_Web.ChatGpt;
using Innovative_Hospital_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenAI_API.Chat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Innovative_Hospital_Web.Controllers
{
    /// <summary>
    /// Контроллер для пациентов
    /// </summary>
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IRegistryService _registryService;
        private readonly IMedicalCardService _medicalCardService;
        private readonly IMessageService _messageService;
        private readonly IWebHostEnvironment _appEnvironment;
        private IEnumerable<PatientsNotFullInfoVM> _patients;
        private static List<Message> chatHistory = new List<Message>();

        public PatientController(IRegistryService registryService, IWebHostEnvironment appEnvironment, IMessageService messageService, IMedicalCardService medicalCardService)
        {
            _registryService = registryService;
            _appEnvironment = appEnvironment;
            _messageService = messageService;
            _medicalCardService = medicalCardService;
        }

        /// <summary>
        /// Получить учет пациентов
        /// </summary>
        /// <returns></returns>
        public IActionResult GetPatient()
        {
            _patients = _registryService.GetPatient(x => x.IsInTheHospital == false);
            return View(_patients);
        }


        /// <summary>
        /// метод для создания аккаунта пацеинта 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientVM model)
        {

            string path = "/Files/" + model.Avatar.FileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await model.Avatar.CopyToAsync(fileStream);
            }
            model.ImagePath = path;
            try
            {
                await _registryService.CreatePatient(model);
                await _messageService.SendWelcomeAsync(model.Email, $"{model.FirstName}-{model.LastName}-{model.Patronomyc}", model.Password);
                return RedirectToAction(nameof(GetPatient));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        /// <summary>
        /// Поставление пациента на учет
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CreateAccounting(string patientId, string fullName, string imagePath, int? medicalCardId)
        {
            var lists = await _registryService.GetDepartaments();
            ViewBag.listDepartaments = new SelectList(lists, "Id", "Name");
            return View(new RegistrationPatientVM
            {
                PatientId = patientId,
                FullNamePatient = fullName,
                ImagePath = imagePath,
                MedicalCardId = medicalCardId
                //listDepartametn =new System.Web.Mvc.SelectList(await _registryService.GetDepartaments(), "DepartamentId", "Name")
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccounting(RegistrationPatientVM model)
        {
            if (!ModelState.IsValid)
            {
                var lists = await _registryService.GetDepartaments();
                ViewBag.listDepartaments = new SelectList(lists, "IdMedicalCard", "Name");
                ModelState.AddModelError("", "ВЫберите отделение");
                return View(model);
            }
            try
            {
                await _registryService.Registration(model);
                return RedirectToAction(nameof(GetPatient), new { IsInTheHospital = false });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }


        /// <summary>
        /// Частичное представление для выбора доктора и палаты при поставлении на учет пацеинта
        /// </summary>
        /// <param name="departamentId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDoctorAndRoom(int departamentId)
        {
            ListDoctorAndRoom list = new ListDoctorAndRoom();
            list.ListDoctors = _registryService.GetDoctorId(x => x.DepartamentId == departamentId);
            list.ListRooms = _registryService.GetRoomId(x => x.DepartamentId == departamentId && x.FreeBads > 0);
            return PartialView(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetMedicalCard(int? id, string patientId)
        {
            var patient = await _registryService.GetPatientById(patientId);
            if (patient == null)
                return NotFound();

            if (patient.MedicalCardId == null)
                return RedirectToAction(nameof(CreateMedicalCard), new { patientId = patientId });
            var medicalcard = await _medicalCardService.GetById(patient.MedicalCardId ?? 0);
            medicalcard.PatientId = patientId;
            return View(medicalcard);
        }

        [HttpGet]
        public IActionResult CreateMedicalCard(string patientId)
        {

            return View(new CreateAndEditMedicalCardVM
            {
                PatientId = patientId,
            });
        }
        [HttpPost]
        public async Task<IActionResult> CreateMedicalCard(CreateAndEditMedicalCardVM model)
        {
            try
            {
                if (model == null)
                    throw new Exception("вы передали пустое значение");

                await _medicalCardService.Create(model);
                if (CheckIsRole._IsRoleDoctor)
                {
                    return RedirectToAction("GetAccounting", "Accounting");
                }
                if (!CheckIsRole._IsRolePatient)
                {
                    return RedirectToAction("GetAccounting", "Accounting", new { IsRegistry = true });
                }
                else
                {
                    //Написать сперва о юзере
                    //return RedirectToAction();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string patientId)
        {
            var medicalCard = await _medicalCardService.GetForEdit(id);
            medicalCard.PatientId = patientId;
            return View(medicalCard);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateAndEditMedicalCardVM model)
        {
            try
            {
                await _medicalCardService.Edit(model);
                return RedirectToAction(nameof(GetMedicalCard), new { id = model.IdMedicalCard, patientId = model.PatientId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        public ActionResult SupportServic()
        {
            if (chatHistory.Count == 0)
            {
                chatHistory.Add(new Message {Text = "Привет! Чем я могу помочь?" });
            }

            return View(chatHistory);
        }

        [HttpPost]
        public ActionResult SendMessage(string message)
        {
            string response = GetResponseFromAI(message);

            chatHistory.Add(new Message { Text = message });
            chatHistory.Add(new Message { Text = response });

            return RedirectToAction("SupportServic");
        }

        private string GetResponseFromAI(string message)
        {
            var mess = AI.Request(message);
            return "Служба: " + mess;
        }
    }
}