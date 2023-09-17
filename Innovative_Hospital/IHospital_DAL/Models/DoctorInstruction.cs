using Innovative_Hospital_DAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovative_Hospital_DAL.Models
{
    public class DoctorInstruction : IEntity<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// ID пациента к которому была создана инструкция
        /// </summary>
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }

        /// <summary>
        /// Id доктора который создал эту инструкцию
        /// </summary>
        [ForeignKey(nameof(Doctor))]
        public string  DoctorId { get; set; }

        /// <summary>
        /// Id учета к которому должна привязываться интсрукция
        /// </summary>
        [ForeignKey(nameof(PatientAccounting))]
        public int AccountingId { get; set; }

        /// <summary>
        /// Направление на анализы
        /// </summary>
        public string Analyzes { get; set; }

        /// <summary>
        /// Диагноз
        /// </summary>
        public string Diagnosis { get; set; }

        /// <summary>
        /// Лечение
        /// </summary>
        public string Treatment { get; set; }


        public virtual  Patient Patient { get; set; }
        public virtual  Doctor Doctor{ get; set; }
        public virtual  PatientAccounting PatientAccounting{ get; set; }

    }
}
