using Innovative_Hospital_BLL.ViewModels.Discharge;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.PatientDischargesServieces
{
    public interface IPatientDischargeService
    {
        Task Create(PatientDischargeVM model);
        Task Edit(PatientDischargeVM model);
        PatientDischargeVM GetByIdAsynd(int id);
        IEnumerable< PatientDischargeVM >GetDischarge(Func<PatientDischarge, bool> predicate);
    }
}
