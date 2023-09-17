using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.AdminViewModels
{
    public class DepartmentInfoVM
    {
        [Display(Name = "")]
        public int id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Закрыто")]
        public bool IsClosed { get; set; }

    }
}
