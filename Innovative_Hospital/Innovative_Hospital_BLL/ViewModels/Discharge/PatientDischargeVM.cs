using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.Discharge
{
    public class PatientDischargeVM
    {
        public int Id { get; set; }

        [Required()]
        public int AccountingId { get; set; }

        [Required()]
        public string DoctorId { get; set; }

        [Display(Name = "Болезнь")]
        [Required(ErrorMessage ="Укажите чем болел пациент")]
        public string Disease { get; set; }

        [Display(Name = "ФИО пациента")]
        [Required()]
        public string FullNamePatient { get; set; }

        [Display(Name = "ФИО доктора")]
        [Required()]
        public string FullNameDoctor { get; set; }

        [Display(Name = "Рекомендации врача")]
        [Required(ErrorMessage = "Укажите что должен делать пациент")]
        public string RecommendationsForDoctor { get; set; }

        [Display(Name ="Дата поставления на учет")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Дата выписки")]
        [Required(ErrorMessage ="Укажиите дату выписки")]

        public DateTime DateOfDischarge { get; set; } = DateTime.Now;

        public string PatietEmail { get; set; }

    }
}
