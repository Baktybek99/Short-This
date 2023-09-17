using Innovative_Hospital_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_DAL.Models
{
    /// <summary>
    /// Создается при выписке пациента
    /// </summary>
    public class PatientDischarge : IEntity<int>
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID учета
        /// </summary>
        [ForeignKey(nameof(PatientAccounting))] 
        public int AccountingId { get; set; }

        /// <summary>
        /// ID доктора
        /// </summary>
        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; }

        /// <summary>
        /// Заболевание
        /// </summary>
        public string Disease { get; set; }

        /// <summary>
        /// ФИО пациента
        /// </summary>
        public string FullNamePatient { get; set; }

        /// <summary>
        /// ФИО доктор
        /// </summary>
        public string FullNameDoctor { get; set; }

        /// <summary>
        /// Рекомендации для пациента
        /// </summary>
        public string RecommendationsForDoctor { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual PatientAccounting PatientAccounting{ get; set; }

    }
}
