using Innovative_Hospital_DAL.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovative_Hospital_DAL.Models
{
    /// <summary>
    /// Задание для младшей медсестрыч
    /// </summary>
    public class TaskOfJuniorNurse : IEntity<int>
    {
        /// <summary>
        /// Id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID к какому учету дается задание
        /// </summary>
        [ForeignKey(nameof(PatientAccounting))]
        public int AccountingId { get; set; }

        /// <summary>
        /// Id старшей медсестры которая дает задачу
        /// </summary>
        [ForeignKey(nameof(SeniorNurse))]
        public string  SeniorNurseId { get; set; }

        /// <summary>
        /// Id младшей медсестры которая будет выполнять задачу
        /// </summary>
        [ForeignKey(nameof(JuniorNurse))]
        public string  JuniorNurseId { get; set; }

        /// <summary>
        /// Хранит в себе задание которая даст старшая медсестра
        /// </summary>
        public string Task { get; set; }

        /// <summary>
        /// Выполнена ли задача
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Дата и время в которое должно быть сделана задача
        /// </summary>
        public DateTime TaskDateTime { get; set; }

        /// <summary>
        /// Дата создания задачи
        /// </summary>
        public DateTime DateOfCreateTask{ get; set; }

        public virtual PatientAccounting PatientAccounting{ get; set; }
        public virtual Nurse SeniorNurse{ get; set; }
        public virtual Nurse JuniorNurse{ get; set; }
    }
}
