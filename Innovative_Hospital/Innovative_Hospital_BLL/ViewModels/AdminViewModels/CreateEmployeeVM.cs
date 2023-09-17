using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Web.Mvc;
using Innovative_Hospital_DAL.Enums;

namespace Innovative_Hospital_BLL.ViewModels.AdminViewModels
{
    /// <summary>
    /// VM для создания сотрудника больницы Админом
    /// </summary>
    public class CreateEmployeeVM
    {
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Максимум 50,минимум 5 символов")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Введите Фамилию")]
        [Display(Name = "Фамилию")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Максимум 50,минимум 5 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Выберите Ваш Пол")]
        [Display(Name = "Пол")]
        public Sex Sex { get; set; }

        [Required(ErrorMessage = "Введите Отчество")]
        [Display(Name = "Фамилие")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Максимум 50,минимум 5 символов")]
        public string Patronomyc { get; set; }


        [Required(ErrorMessage = "Введите дату рождения")]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Обязательно укажите почту")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Не верный формат почты")]
        [Remote(action: "CheckEmail", controller: "Account", ErrorMessage = "Данный Email занят")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Минимум 4 цифр, максимум 20")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public IFormFile Avatar { get; set; }
        public int DepartamentId { get; set; }
        public List<CreateDepartmentVM> Departments { get; set; } = new List<CreateDepartmentVM>();
        public bool IsDoctor { get; set; }
        public bool IsSeniorNurse { get; set; }



    }
}
