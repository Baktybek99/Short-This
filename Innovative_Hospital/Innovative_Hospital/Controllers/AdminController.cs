using AutoMapper;
using Innovative_Hospital_BLL.Services.Admin;
using Innovative_Hospital_BLL.ViewModels.AdminViewModels;
using Innovative_Hospital_DAL.Models;
using Innovative_Hospital_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Innovative_Hospital_Web.Controllers
{
    /// <summary>
    /// Контроллер Админа
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class AdminController:Controller
    {
        private readonly IAdminService _adminService;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IMapper _mapper;
        public AdminController(IAdminService adminService, IWebHostEnvironment appEnvironment)
        {
            _adminService = adminService;
            _appEnvironment = appEnvironment;
        }

        /// <summary>
        /// Для начальной страницы Админа со списком отделений
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AdminIndex()
        {
            List<EmployeeInfoVM> deps = await _adminService.GetAllEmployeesAsync(x => x.IsFired==false);
            return View(deps);
        }
        /// <summary>
        /// Создание клиента Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        /// <summary>
        /// Создание клиента Post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeVM model)
        {
            if (ModelState.IsValid)
            {
                string path = "/Files/" + model.Avatar.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await model.Avatar.CopyToAsync(fileStream);
                }

                if (model.DateOfBirth.Date > DateTime.Now.Date)
                {
                    ViewBag.Error = "Некорректная дата";
                    return View(model);
                }
                try
                {
                    await _adminService.CreateEmployeeAsync(model);
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

        /// <summary>
        /// Изменение данных клиента Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditEmployee(string id)
        {
            EmployeeInfoVM employee = await _adminService.GetEmployeeAsync(id);
            return View(_mapper.Map<EditEmployeeVM>(employee));
        }
        /// <summary>
        /// Изменение данных клиента Post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(EditEmployeeVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employee = await _adminService.EditEmployeeAsync(model);
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Не удалось отредактировать клиента", ex.Message);
                }
               
            }
            return View(model);
        }
        /// <summary>
        /// Для увольнения сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FireEmployee(string id)
        {
            if(await _adminService.FireEmployeeAsync(id))
                return RedirectToAction("Index");

            return BadRequest("Не удалось удалить клиента");
        }
        /// <summary>
        /// Для восстановления сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> RecoveryEmployee(string id)
        {
            if (await _adminService.RecoveryEmployeeAsync(id))
                return RedirectToAction("Index");

            return BadRequest("Не удалось восстановить клиента");
        }
        /// <summary>
        /// Поиск сотрудника
        /// </summary>
        /// <param name="searchText">Текст поиска</param>
        [HttpGet]
        public async Task<IActionResult> Search(string searchText)
        {
            var searchResult = await _adminService.SearchAsync(searchText);

            if (!User.IsInRole("admin"))
                searchResult = searchResult.Where(x => x.IsFired == false).ToList();

            return PartialView(searchResult);
        }
        /// <summary>
        /// получение списка всех сотрудников
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAllEmployees()
        {
            return View(await _adminService.GetAllEmployeesAsync(x=>x.IsFired==false));
        }
        public async Task<IActionResult> GetAllDepartments()
        {
            return View(await _adminService.GetAllDepartmentsAsync(x=>x.IsClosed==false));
        }

        /// <summary>
        /// Фильтпация сотрудников по должности
        /// </summary>
        /// <param name="employeeFilter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EmployeeFilter(EmployeeFilter employeeFilter)
        {
            return  PartialView(await _adminService.FilterEmployees(employeeFilter));
        }
        /// <summary>
        /// Получение списка докторов в отделении
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDoctorsByDep(Departament departament)
        {
            return PartialView(await _adminService.GetDoctorsByDep(departament));
        }
        /// <summary>
        /// Получение списка палат в отделении
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GeеRoomsByDep(Departament departament)
        {
            return PartialView(await _adminService.GetRoomsByDep(departament));
        }

    }
}
