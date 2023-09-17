using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_DAL.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
