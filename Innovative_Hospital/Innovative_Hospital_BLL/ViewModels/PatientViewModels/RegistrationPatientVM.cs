using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Innovative_Hospital_BLL.ViewModels.PatientViewModels
{
    public class RegistrationPatientVM
    {
        public int Id { get; set; }

        public int? MedicalCardId { get; set; }

        [Required(ErrorMessage = "Выберите доктора")]
        [Display(Name = "Доктор")]
        public string DoctorId { get; set; }

        [Required(ErrorMessage = "Ыыберите отделение")]
        [Display(Name = "Отделение")]
        public int DepartamentId { get; set; }

        [Required(ErrorMessage ="Выберите палату")]
        [Display(Name = "Палата")]
        public int RoomId { get; set; }
        public string ImagePath { get; set; }
        public string PatientId { get; set; }

        [Display (Name = "ФИО пациента")]
        public string FullNamePatient { get; set; }

        [Display(Name = "Дата поставления на учет")]
        public DateTime ArrivalDate { get; set; } = DateTime.Now.Date;

        public SelectList listDepartametn { get; set; }

    }
}
