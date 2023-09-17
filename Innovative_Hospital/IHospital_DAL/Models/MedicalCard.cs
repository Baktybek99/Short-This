using Innovative_Hospital_DAL.Enums;
using Innovative_Hospital_DAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovative_Hospital_DAL.Models
{
    /// <summary>
    /// Медицинская карта пациента
    /// </summary>
    public class MedicalCard : IEntity<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Хранит в себе болезни какие были, и какие есть
        /// </summary>
        public string Diseases { get; set; }

        /// <summary>
        /// Хранит в себе какие есть аллергии
        /// </summary>
        public string Allergy { get; set; }

        /// <summary>
        ///  Группа крови
        /// </summary>
        public BloodType BloodType { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Адресс проживания
        /// </summary>
        public string ResidentialAddress { get; set; }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Район
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Домашний телефон
        /// </summary>
        public string HomePhoneNumber { get; set; }

        /// <summary>
        /// Рабочий телефон
        /// </summary>
        public string WorkPhoneNumber { get; set; }

        /// <summary>
        /// Инвалидность
        /// </summary>
        public string Disability { get; set; }

        /// <summary>
        /// Место работы
        /// </summary>
        public string PlaceOfWork { get; set; }

        /// <summary>
        /// Профессия
        /// </summary>
        public string Profession { get; set; }

        /// <summary>
        /// Должность на работе
        /// </summary>
        public string PositionAtWork { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
