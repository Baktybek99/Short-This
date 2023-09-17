using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.AdminViewModels
{
    public class CreateDepartmentVM
    {
        public int Id { get; set; }

        [Display(Name = "Отделение")]
        public string Name { get; set; }
    }
}
