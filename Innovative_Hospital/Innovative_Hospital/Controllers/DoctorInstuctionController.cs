using Innovative_Hospital_BLL.Services.DoctorInstructionServices;
using Innovative_Hospital_BLL.ViewModels.DoctorInstructions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Innovative_Hospital_Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с указаниями врача
    /// </summary>
    [Authorize] 
    public class DoctorInstuctionController : Controller
    {
        private readonly IDoctorInstructionService _instructionService;

        public DoctorInstuctionController(IDoctorInstructionService instructionService)
        {
            _instructionService = instructionService;
        }


        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="accountingId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(string patientId, int accountingId)
        {
            return View(new CreateInstructionVM
            {
                PatientId = patientId,
                AccountingId = accountingId,
                DoctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
        });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateInstructionVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _instructionService.Create(model);
                    return RedirectToAction(nameof(GetInstructions), new { accountingId = model.AccountingId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

        /// <summary>
        /// Изменить указание
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _instructionService.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InstructionVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _instructionService.Edit(model);
                    return RedirectToAction(nameof(GetInstructions), new { accountingId = model.AccountingId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

        
        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountingId"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id,int accountingId,string patientId)
        {
            await _instructionService.Delete(id);
           return RedirectToAction(nameof(GetInstructions),new { accountingId =accountingId, patientId = patientId});
        }

        /// <summary>
        /// Получить список указаний
        /// </summary>
        /// <param name="accountingId"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public IActionResult GetInstructions(int accountingId,string patientId)
        {            
            var list = _instructionService.GetInstuctions(x => x.AccountingId == accountingId);
            if(list.Count() < 1)
            {
                return RedirectToAction(nameof(Create),new { patientId = patientId , accountingId = accountingId });
            }
            return View(list );
        }

        /// <summary>
        /// Получить полную информацию об указании врача
        /// </summary>
        /// <param name="accountingId"></param>
        /// <returns></returns>
        public IActionResult GetFullInstructioInfo(int accountingId)
        {   
            return View(_instructionService.GetInstuctionsFullInfo(x => x.AccountingId == accountingId
                                                            ,p => p.Patient
                                                            ,d => d.Doctor
                                                            ,dep => dep.Doctor.Departament));
        }

    }
}
