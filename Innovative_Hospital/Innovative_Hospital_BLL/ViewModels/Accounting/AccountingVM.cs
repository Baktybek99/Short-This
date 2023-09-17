using Innovative_Hospital_DAL.Enums;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.Accounting
{
    public class AccountingVM
    {        
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public int DepartamentId { get; set; }
       
        public int RoomId { get; set; }
        
        public string PatientId { get; set; }

        public int? MedicalCardId { get; set; }

        [Display(Name = "ФИO")]
        public string FullNamePatient { get; set; }

        
        [Display(Name = "Дата поставление на учет")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

       
        [Display(Name = "Дата выписки")]
        [DataType(DataType.Date)]
        public DateTime? DateOfDischarge { get; set; }

        [Display(Name = "Выписан ли")]
        public bool IsDischarged { get; set; }

        [Display(Name = "Фото пациента")]
        public string ImagePath { get; set; }
        public IEnumerable<DoctorInstruction> DoctorInstructions { get; set; }
        public string Diagnosis { get; set; }
        public string FullNameDoctor{ get; set; }
        public string DepartmentName { get; set; }
        public int RoomNumber { get; set; }
        public string EmailPatient { get; set; }

        public string WorkPhoneNumber { get; set; }
        public BloodType BloodType { get; set; }
        public string Allergy { get; set; }

        public Sex Sex { get; set; }

    }
}
