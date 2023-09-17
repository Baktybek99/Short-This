using System;

namespace Innovative_Hospital_DAL.Models
{
    /// <summary>
    /// Работник
    /// </summary>
    public abstract class Employee : User
    {
        /// <summary>
        /// Дата принятия на работу
        /// </summary>
        public DateTime DateOfEmployment { get; set; }

        /// <summary>
        /// Дата увольнения
        /// </summary>
        public DateTime? DateOfDismissal { get; set; }

        /// <summary>*
        /// Описание работника
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// уволен ли работник
        /// </summary>
        public bool IsFired { get; set; }
    }
}
