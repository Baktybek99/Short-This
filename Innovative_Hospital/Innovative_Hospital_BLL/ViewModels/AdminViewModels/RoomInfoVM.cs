using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.ViewModels.AdminViewModels
{
    public class RoomInfoVM
    {
        public int RoomNumber { get; set; }
        public int MaxBeds { get; set; }
        public int FreeBeds { get; set; }
    }
}
