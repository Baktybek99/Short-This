using Innovative_Hospital_BLL.Services;
using Innovative_Hospital_BLL.Services.Accounting;
using Innovative_Hospital_BLL.Services.PatientDischargesServieces;
using Innovative_Hospital_BLL.Services.Register;
using Innovative_Hospital_BLL.ViewModels;
using Innovative_Hospital_BLL.ViewModels.Accounting;
using Innovative_Hospital_BLL.ViewModels.Discharge;
using Innovative_Hospital_BLL.ViewModels.PatientViewModels;
using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Innovative_Hospital_Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с учетом пациентов
    /// </summary>
    public class AccountingController : Controller
    {
        private readonly IAccountingService _accountingService;
        private readonly IRegistryService _registryService;
        private IEnumerable<AccountingVM> _accountingsVM;
        private IPatientDischargeService _dishargeService;
        private readonly IMessageService _messageService;
        private string _currentUserId;
        public AccountingController(IAccountingService accountingService, IMessageService messageService, IPatientDischargeService dishargeService, IRegistryService registryService)
        {
            _registryService = registryService;
            _accountingService = accountingService;
            _messageService = messageService;
            _dishargeService = dishargeService;
        }

        /// <summary>
        /// Получить пациентов на учете
        /// </summary>
        /// <param name="IsRegistry"></param>
        /// <param name="isNurse"></param>
        /// <returns></returns>
        public IActionResult GetAccounting(bool IsRegistry = false, bool isNurse = false, bool isPatient = false,bool isDischarged = false)
        {
            if (isNurse || IsRegistry)
            {
                _accountingsVM = _accountingService.GetAccountings(x => x.IsDischarged == false);
            }
            else if (isPatient)
            {
                _currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                _accountingsVM = _accountingService.GetAccountings(x => x.IsDischarged == isDischarged && x.PatientId == _currentUserId);
            }
            else
            {
                _currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                _accountingsVM = _accountingService.GetAccountings(x => x.IsDischarged == isDischarged && x.DoctorId == _currentUserId);
            }
            return View(_accountingsVM);
        }

        /// <summary>
        /// Позволяет выписать пациента
        /// </summary>
        /// <param name="accountingId"></param>
        /// <param name="doctorId"></param>
        /// <param name="patientnId"></param>
        /// <returns></returns>
        public IActionResult DischargeThePatient(int accountingId)
        {
            var accounting = _accountingService.GetAccountingAsync(accountingId);
            if (accounting == null)
                return NotFound();

            return View(new PatientDischargeVM
            {
                AccountingId = accounting.Id,
                DoctorId = accounting.DoctorId,
                PatietEmail = accounting.EmailPatient,
                FullNameDoctor = accounting.FullNameDoctor,
                FullNamePatient = accounting.FullNamePatient,
                ArrivalDate = accounting.ArrivalDate
            });
        }
        /// <summary>
        /// Создание пациента
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DischargeThePatient(PatientDischargeVM model)
        {
            try
            {
                await _accountingService.DischargeThePatient(model.AccountingId, model.DateOfDischarge);
                await _dishargeService.Create(model);
                return RedirectToAction(nameof(GetAccounting));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        /// <summary>
        /// Взять выписку по id учета
        /// </summary>
        /// <param name="accountingId"></param>
        /// <returns></returns>
        public IActionResult  GetDicharge(int accountingId)
        {
            return View(_dishargeService.GetByIdAsynd(accountingId));
        }

        public IActionResult GetCurrentAccounting()
        {
            var _currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var _accountingVM = _accountingService.GetAcc(_currentUserId);
            if (_accountingVM != null)
            {
                return View(_accountingVM);
            }
            else return NotFound("Вы не состоите на учете в больнице на данный момент");
        }
    }
}
