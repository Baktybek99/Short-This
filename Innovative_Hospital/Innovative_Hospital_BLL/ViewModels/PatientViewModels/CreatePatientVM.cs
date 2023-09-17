using Innovative_Hospital_DAL.Enums;
using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.PatientViewModels
{
    /// <summary>
    /// View Model который нужна для создания пациента
    /// </summary>
    public class CreatePatientVM
    {
        [Required(ErrorMessage = "Обязательно укажите почту")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Не верный формат почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ты куда без пароля")]
        [Display(Name = "Пароль")]
        [StringLength(100,MinimumLength =5,ErrorMessage =("Минимум 5 символов"))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Максимум 50,минимум 5 символов")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Введите Фамилие")]
        [Display(Name = "Фамилие")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Максимум 50,минимум 5 символов")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Введите Отчество")]
        [Display(Name = "Отчество")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Максимум 50,минимум 5 символов")]
        public string Patronomyc { get; set; }


        [Required(ErrorMessage = "Введите дату рождения")]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage ="Укажит пол")]
        [Display(Name = "Пол")]
        public Sex Sex { get; set; }

        public int? MedicalCardId { get; set; }

        public DateTime DateOfRegistration { get; set; } = DateTime.Now;

        [Required(ErrorMessage ="Вставьте фото")]
        [Display (Name ="Фото")]
        public IFormFile Avatar { get; set; }

        public string ImagePath { get; set; }

        //private string UserName { get; set; } 

        public string SetUserName
        {
            get { return Email; }
            //set { UserName = Email; }
        }






    }
}
