using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.DoctorInstructions
{
    public class InstuctionFullInfoVM
    {
        public int Id { get; set; }

        [Required()]
        public string PatientId { get; set; }

        [Required()]
        public string DoctorId { get; set; }

        [Required()]
        public int AccountingId { get; set; }

        [Display(Name = "Напрвление на анлизы")]
        public string Analyzes { get; set; }

        [Display(Name = "Диагноз")]
        public string Diagnosis { get; set; }

        [Display(Name = "Лечение")]
        public string Treatment { get; set; }

        [Display(Name = "ФИО пациена:")]
        public string FullNamePatient { get; set; }

        [Display(Name = "ФИО доктора:")]
        public string FullNameDoctor { get; set; }

        [Display(Name = "Название отделения")]
        public string DepartamentName { get; set; }

    }
}
