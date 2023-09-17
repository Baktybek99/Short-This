using Innovative_Hospital_DAL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.AdminViewModels
{
    /// <summary>
    /// VM для инфо о сотруднике
    /// </summary>
    public class EmployeeInfoVM
    {
        public string Id { get; set; }
        [Display(Name = "Фото")]
        public string ImagePath { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Дата принятия на работу")]
        public DateTime DateOfEmployment { get; set; }
        [Display(Name = "Дата увольнения")]
        public DateTime DateOfDismissal { get; set; }
        [Display(Name = "Пол")]
        public Sex Sex { get; set; }
        [Display(Name = "Отделение")]
        public string DepartmentName { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
        /// <summary>
        /// true если сотрудник уволен, false если сотрудник работает
        /// </summary>
        [Display(Name = "Уволен")]
        public bool IsFired { get; set; }
    }
}
