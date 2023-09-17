using Innovative_Hospital_DAL.Enums;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.PatientViewModels
{
    public class PatientsNotFullInfoVM
    {
        public string Id { get; set; }


        [Display(Name = "ФИО")]
        public string FullName { get; set; }


        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        public int? MedicalCardId { get; set; }

        [Display(Name ="Фото")]
        public string ImagePath { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime DateOfRegistration { get; set; }

        [Display(Name = "На учете")]
        public bool IsInTheHospital { get; set; }

        [Display(Name ="Пол")]
        public Sex Sex { get; set; }
        //public virtual MedicalCardVM MedicalCard { get; set; }
        //public  MedicalCard MedicalCard { get; set; }
    }
}
