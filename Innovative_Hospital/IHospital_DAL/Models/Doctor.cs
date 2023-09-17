using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovative_Hospital_DAL.Models
{
    /// <summary>
    /// Класс доктора
    /// </summary>
    public class Doctor : Employee
    {
        /// <summary>
        /// Ссылка на то к какому отделению относится
        /// </summary>
        [ForeignKey(nameof(Departament))]
        public int DepartamentId { get; set; }


        public virtual Departament Departament { get; set; }

        public virtual IEnumerable<PatientAccounting> PatientAccountings { get; set; }


    }
}
