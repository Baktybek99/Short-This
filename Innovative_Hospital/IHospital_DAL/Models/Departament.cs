using Innovative_Hospital_DAL.Interfaces;
using System.Collections.Generic;

namespace Innovative_Hospital_DAL.Models
{
    /// <summary>
    /// Отделение в которых работают доктора
    /// </summary>
    public class Departament : IEntity<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название отделения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Закрыто ли отделение
        /// </summary>
        public bool IsClosed { get; set; }


        public virtual IEnumerable<Room> Rooms{ get; set; }
        public virtual IEnumerable<Doctor> Doctors { get; set; }
        public virtual IEnumerable<PatientAccounting> PatientAccountings { get; set; }
    }
}
