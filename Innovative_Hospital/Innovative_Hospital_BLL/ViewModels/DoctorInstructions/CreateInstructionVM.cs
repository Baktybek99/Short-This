using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.DoctorInstructions
{
    public class CreateInstructionVM
    {
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

        [Display(Name ="Лечение")]
        public string Treatment { get; set; }
    }
}
