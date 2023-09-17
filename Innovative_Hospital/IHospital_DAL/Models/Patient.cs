using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovative_Hospital_DAL.Models
{
    /// <summary>
    /// Пациент
    /// </summary>
    public class Patient : User
    {
        /// <summary>
        /// Ссылка на его медицинскую карту
        /// </summary>
        [ForeignKey(nameof(MedicalCard))]
        public int? MedicalCardId { get; set; }

        /// <summary>
        /// Дата регистрации пациента
        /// </summary>
        public DateTime DateOfRegistration { get; set; }

        /// <summary>
        /// Находиться ли пацент на учете
        /// </summary>
        public bool IsInTheHospital { get; set; }

        public virtual MedicalCard MedicalCard { get; set; }

        public virtual IEnumerable<PatientAccounting> PatientAccountings { get; set; }


    }
}
