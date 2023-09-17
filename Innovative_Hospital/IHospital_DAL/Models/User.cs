using Innovative_Hospital_DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace Innovative_Hospital_DAL.Models
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Имя 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилие
        /// </summary>
        public string LastName{ get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string  Patronomyc { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Дата Рождени
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Хранит в себе путь к фотографии
        /// </summary>
        public string ImagePath { get; set; }

        
    }
}
