using Innovative_Hospital_BLL.ViewModels;
using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innovative_Hospital_Web.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Для вывода всех ролей
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        
        /// <summary>
        /// Для изменения ролей пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var roles = _roleManager.Roles.ToList();
                var userRoles = await _userManager.GetRolesAsync(user);
                var model = new ChangeRoleViewModel
                {
                    AllRoles = roles,
                    UserEmail = user.Email,
                    UserId = user.Id,
                    UserRoles = userRoles
                };

                return View(model);
            }


            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {               
                var userRoles = await _userManager.GetRolesAsync(user);
                var addedRoles = roles.Except(userRoles);
                var deleteRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, deleteRoles);
                return RedirectToAction("Index", "User");

            }
            return NotFound();
        }

    }
}
