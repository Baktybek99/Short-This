using Innovative_Hospital_DAL.Enums;
using System.Collections.Generic;

namespace Innovative_Hospital_DAL.Models
{
    /// <summary>
    /// Медсестра
    /// </summary>
    public class Nurse : Employee
    {

        /// <summary>
        /// Позиция на которой работает медсестра
        /// </summary>
        public PositionEmployee Position { get; set; }


    }
}
