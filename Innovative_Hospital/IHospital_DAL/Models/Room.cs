using Innovative_Hospital_DAL.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovative_Hospital_DAL.Models
{
    /// <summary>
    /// Палата в которую будут помещать пациента
    /// </summary>
    public class Room : IEntity<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// номер палаты
        /// </summary>
        public int RoomNumber { get; set; }
        /// <summary>
        /// ID к какому отделению относится
        /// </summary>
        [ForeignKey(nameof(Departament))]
        public int DepartamentId { get; set; }
           
        /// <summary>
        /// Максимально кол-во мест
        /// </summary>
        public int MaxBads { get; set; }

        /// <summary>
        /// Свободное кол-ко мест
        /// </summary>
        public int FreeBads { get; set; }

        public virtual Departament Departament { get; set; }
        public virtual IEnumerable<PatientAccounting> PatientAccountings { get; set; }


    }
}
