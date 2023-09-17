using Innovative_Hospital_DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels
{
    public class MedicalCardVM
    {
        //-------------------Мед карта--------------------------------//
        public int Id { get; set; }

        [Required]
        public string PatientId { get; set; }
        
        [Display(Name = "История болезней")]
        public string Diseases { get; set; }


        [Display(Name = "Какие есть аллергии")]
        public string Allergy { get; set; }


        [Required(ErrorMessage = "Укажите тип крови")]
        [Display(Name = "Тип крови")]
        public BloodType BloodType { get; set; }


        [Display(Name = "Вес")]
        public int? Weight { get; set; }


        [Display(Name = "Рост")]
        public int? Height { get; set; }

        

    }
}
