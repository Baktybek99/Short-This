using Innovative_Hospital_BLL.ViewModels.Nurse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.Tasks
{
    public class CreateTaskVM
    {
        public int AccountingId { get; set; }

        public string SeniorNurseId { get; set; }

        [Required(ErrorMessage = "Выберите медсестру")]
        public string JuniorNurseId { get; set; }
        //--------------------------------------------------------------------

        [Required(ErrorMessage = "Дайте задание медсестре")]
        [Display(Name = "Задание")]
        public string Task { get; set; }

        [Required(ErrorMessage = "Выберите дату выволнения задания")]
        [Display(Name = "Дата выполнения задания")]
        public DateTime TaskDateTime { get; set; } = DateTime.Now.Date;

        public DateTime DateOfCreateTask { get; set; } = DateTime.Now;

        public IEnumerable<GiveTaskNurseVM> Nurses{ get; set; }

    }
}
