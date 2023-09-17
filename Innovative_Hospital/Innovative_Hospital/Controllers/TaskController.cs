using Innovative_Hospital_BLL.Services.NurseServices;
using Innovative_Hospital_BLL.ViewModels.Tasks;
using Innovative_Hospital_DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Innovative_Hospital_Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с задачами для медсестрами
    /// </summary>
    [Authorize]
    public class TaskController : Controller
    {
        private readonly INurseService _nurseService;
        private IEnumerable<JuniorTaskVM> _tasks;
        private string _curentNurseId;
        public TaskController(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        /// <summary>
        /// Показать задания в зависимости от роли выводятся определенные задачи
        /// </summary>
        /// <param name="isCompleted"></param>
        /// <returns></returns>
        public IActionResult GetTasks(bool isCompleted = true, bool isSeniorNurse = false, int accountingId = 0, bool isPatient = false)
        {
            if (isSeniorNurse)
            {
                _curentNurseId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (accountingId < 1)
                {
                    _tasks = _nurseService.GetTasks(x => x.IsCompleted == isCompleted && x.SeniorNurseId == _curentNurseId
                                                        , y => y.PatientAccounting
                                                        , r => r.PatientAccounting.Room
                                                        , d => d.PatientAccounting.Departament
                                                        , j => j.JuniorNurse
                                                        , i => i.PatientAccounting.Patient);

                }
                else
                {
                    _tasks = _nurseService.GetTasks(x => x.IsCompleted == isCompleted && x.AccountingId == accountingId
                                                    , y => y.PatientAccounting
                                                    , r => r.PatientAccounting.Room
                                                    , d => d.PatientAccounting.Departament
                                                    , j => j.JuniorNurse
                                                    , i => i.PatientAccounting.Patient);
                }
            }
            else if (isPatient)
            {
                _curentNurseId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                _tasks = _nurseService.GetTasks(x => x.AccountingId == accountingId
                                                , y => y.PatientAccounting
                                                , r => r.PatientAccounting.Room
                                                , d => d.PatientAccounting.Departament
                                                , j => j.JuniorNurse
                                                , i => i.PatientAccounting.Patient);
            }
            else
            {
                _curentNurseId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                _tasks = _nurseService.GetTasks(x => x.JuniorNurseId == _curentNurseId && x.IsCompleted == isCompleted
                                                        , y => y.PatientAccounting
                                                        , r => r.PatientAccounting.Room
                                                        , d => d.PatientAccounting.Departament
                                                        , i => i.PatientAccounting.Patient);
            }
            return View(_tasks);
        }

        /// <summary>
        /// Создать задание
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int accountingId)
        {
            var createTask = new CreateTaskVM
            {
                Nurses = _nurseService.GetJuniorNurse(x => x.Position == PositionEmployee.Junior_Nurse),
                SeniorNurseId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                AccountingId = accountingId
            };
            return View(createTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTaskVM model)
        {
            if (ModelState.IsValid)
            {
                if (!(model.TaskDateTime < DateTime.Now))
                {
                    await _nurseService.CreateTaskJuniorNurse(model);
                    return RedirectToAction("GetAccounting", "Accounting", new { isNurse = true });
                }
                ModelState.AddModelError("", "Нельзя дать задание на предыдущие дни");
            }
            model.Nurses = _nurseService.GetJuniorNurse(x => x.Position == PositionEmployee.Junior_Nurse);
            return View(model);
        }

        /// <summary>
        /// Изменить задание
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _nurseService.GetTaskForEdit(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditJuniorTaskVM model)
        {
            if (!ModelState.IsValid)    
            {
                return View(model);
            }
            else if (model.TaskDateTime < DateTime.Now)
            {
                ModelState.AddModelError("", "Нельзя выбирать предыдущие дни");
                return View(model);
            }
            try
            {
                _nurseService.Edit(model);
                return RedirectToAction(nameof(GetTasks), new { isSeniorNurse = true , accountingId = model.AccountingId, isCompleted = false });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        /// <summary>
        /// Удалить задание
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _nurseService.Delete(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("GetAccounting", "Accounting", new { isNurse = true });
        }

        /// <summary>
        /// Отметить что задание сделано
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> MarkTaskDone(int id)
        {
            try
            {
                await _nurseService.MarkTaskDone(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction(nameof(GetTasks), new { isCompleted = false });
        }
    }
}
