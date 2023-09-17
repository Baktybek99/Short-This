using Innovative_Hospital_BLL.ViewModels.DoctorViewModels;
using Innovative_Hospital_BLL.ViewModels.Rooms;
using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Innovative_Hospital_Web.Models
{
    public class ListDoctorAndRoom
    {
        //public SelectList listDoctor { get; set; }
        //public SelectList listRoom { get; set; }

        public IEnumerable<DoctorNameIdVM> ListDoctors { get; set; }
        public IEnumerable<RoomVM> ListRooms { get; set; }

        [Display(Name ="Отделение")]
        [Required(ErrorMessage = "Выберите доктора")]
        public string DepartamentId { get; set; }
        
        [Display(Name ="Палата")]
        [Required(ErrorMessage ="ВЫберите комнату")]
        public string RoomId { get; set; }
        
    }
}
