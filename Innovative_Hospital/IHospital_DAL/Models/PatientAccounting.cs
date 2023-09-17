using Innovative_Hospital_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovative_Hospital_DAL.Models
{
    /// <summary>
    /// Поставление пациента на учет
    /// </summary>
    public class PatientAccounting : IEntity<int>
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID на доктора который смотрит за пациентом
        /// </summary>
        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; }

        /// <summary>
        /// Id отделения
        /// </summary>
        [ForeignKey(nameof(Departament))]
        public int DepartamentId { get; set; }

        /// <summary>
        /// Id палаты
        /// </summary>
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }

        /// <summary>
        /// ID самого пациента
        /// </summary>
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }

        /// <summary>
        /// Полное имя фамилие пацаента
        /// </summary>
        public string FullNamePatient { get; set; }

        /// <summary>
        /// Дата поставление на учет
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Дата выписки
        /// </summary>
        public DateTime? DateOfDischarge { get; set; }

        /// <summary>
        /// Выписан ли пацент
        /// </summary>
        public bool IsDischarged { get; set; }

        /// <summary>
        /// Фото пациента
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Мед карта пациента
        /// </summary>
        public int? MedicalCardId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Departament Departament { get; set; }
        public virtual Room Room { get; set; }
        public virtual Doctor Doctor  { get; set; }
        public virtual PatientDischarge PatientDischarge { get; set; }
        public virtual IEnumerable<DoctorInstruction> DoctorInstructions { get; set; }

    }
}
