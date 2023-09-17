using Innovative_Hospital_BLL.ViewModels.Accounting;
using Innovative_Hospital_DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.MedicalCard
{
    public class FullMedicalCardInfoVM
    {        
        public int Id { get; set; }
        public string PatientId { get; set; }

        [Display(Name ="Болезни")]
        public string Diseases { get; set; }

        [Display(Name ="Аллергии")]
        public string Allergy { get; set; }

        
        [Display(Name ="Тип Крови")]
        public BloodType BloodType { get; set; }

        
        [Display(Name ="Вес")]
        public int? Weight { get; set; }

        
        [Display(Name ="Рост")]
        public int? Height { get; set; }

        
        [Display(Name ="Аддрес проживания")]
        public string ResidentialAddress { get; set; }

        //---------------------------------------------------------------------//
        
        [Display(Name ="Район")]
        public string District { get; set; }

        [Display(Name ="Домашний телефон")]
        public string HomePhoneNumber { get; set; }

        [Display(Name ="Рабочий телефон")]
        public string WorkPhoneNumber { get; set; }

        [Display(Name ="Инвалидность")]
        public string Disability { get; set; }

        [Display(Name ="Место работы")]
        public string PlaceOfWork { get; set; }

        [Display(Name ="Профессия")]
        public string Profession { get; set; }

        [Display(Name ="должность на работе")]
        public string PositionAtWork { get; set; }

        public IEnumerable<AccountingVM> Accountings { get; set; }
    }
}
