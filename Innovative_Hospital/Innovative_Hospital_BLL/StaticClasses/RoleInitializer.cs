using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace Innovative_Hospital_BLL.StaticClasses
{
    /// <summary>
    /// роли и начальные данные
    /// </summary>
    public static class RoleInitializer
    {
        public static string[] StatusFilter = { "Все", "Доктор", "Старшая медсестра", "Младшая медсестра"};
        public static string roleAdmin = "Admin";
        public static string roleDoctor = "Doctor";
        public static string roleJuniorNurse = "JuniorNurse";
        public static string roleSeniorNurse = "SeniorNurse";
        public static string roleRegistry = "Registry";
        public static string rolePatient = "Patient";
        public static async Task InitializeAsync(UserManager<User> userManager,
           RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string regystryEmaiil = "reg12@gmail.com";
            string password = "123";
            if (await roleManager.FindByNameAsync(roleAdmin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleAdmin));
            }
            if (await roleManager.FindByNameAsync(roleSeniorNurse) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleSeniorNurse));
            }
            if (await roleManager.FindByNameAsync(roleDoctor) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleDoctor));
            }
            if (await roleManager.FindByNameAsync(roleJuniorNurse) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleJuniorNurse));
            }
            if (await roleManager.FindByNameAsync(roleRegistry) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleRegistry));
            }
            if (await roleManager.FindByNameAsync(rolePatient) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(rolePatient));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    FirstName = "admin",
                    LastName = "admin",
                    DateOfBirth = DateTime.Now
                };

                User regystry = new User
                {
                    Email = regystryEmaiil,
                    UserName = regystryEmaiil,
                    FirstName = "Регистратура",
                    LastName = "Регистратура",
                    DateOfBirth = DateTime.Now
                };

                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, roleAdmin);
                }

                result = await userManager.CreateAsync(regystry, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(regystry, roleRegistry);
                }
            }
        }
    }
}
