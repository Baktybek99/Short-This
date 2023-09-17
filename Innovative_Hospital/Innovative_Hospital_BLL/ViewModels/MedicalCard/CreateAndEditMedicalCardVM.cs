using Innovative_Hospital_DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.MedicalCard
{
    public class CreateAndEditMedicalCardVM
    {
        public int IdMedicalCard { get; set; }
        public string PatientId { get; set; }

        [Display(Name ="Болезни")]
        public string Diseases { get; set; }

        [Display(Name = "Аллергия")]
        public string Allergy { get; set; }

        [Display(Name ="Тип крови")]
        [Required(ErrorMessage ="укажите тип крови")]
        public BloodType BloodType { get; set; }

        [Display(Name ="Вес")]
        public int? Weight { get; set; }

        [Display(Name = "Рост")]
        public int? Height { get; set; }

        [Display(Name ="Адрес проживания")]
        public string ResidentialAddress { get; set; }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Район
        /// </summary>
        [Display(Name ="Район")]
        public string District { get; set; }

        /// <summary>
        /// Домашний телефон
        /// </summary>
        [Display(Name ="Домашний телефон")]
        [DataType(dataType:DataType.PhoneNumber,ErrorMessage ="Укажите нормально домашний телефон")]
        public string HomePhoneNumber { get; set; }

        /// <summary>
        /// Рабочий телефон
        /// </summary>
        [Display(Name ="Рабочий телефон")]
        [Required(ErrorMessage ="Укажите рабочий телефон")]
        [DataType(dataType:DataType.PhoneNumber,ErrorMessage ="Укажите правильно рабочий телефон")]
        public string WorkPhoneNumber { get; set; }

        /// <summary>
        /// Инвалидность
        /// </summary>
        [Display(Name ="Инвалидность")]
        public string Disability { get; set; }

        /// <summary>
        /// Место работы
        /// </summary>
        [Display(Name ="Место работы")]
        public string PlaceOfWork { get; set; }

        /// <summary>
        /// Профессия
        /// </summary>
        [Display(Name ="Профессия")]
        public string Profession { get; set; }

        /// <summary>
        /// Должность на работе
        /// </summary>
        [Display(Name ="Должность на работе")]
        public string PositionAtWork { get; set; }
    }
}
