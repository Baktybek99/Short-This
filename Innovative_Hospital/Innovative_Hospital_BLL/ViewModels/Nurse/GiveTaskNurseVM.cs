using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.Nurse
{
    /// <summary>
    /// Класс для того чтоб выбрать какой медсестре дать задание
    /// </summary>
    public class GiveTaskNurseVM
    {
        public  string Id { get; set; }
        public string FullName { get; set; }
        public string ImagePath { get; set; }

    }
}
