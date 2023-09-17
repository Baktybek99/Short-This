using Innovative_Hospital_BLL.ViewModels.DoctorInstructions;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.DoctorInstructionServices
{
    public interface IDoctorInstructionService
    {
        Task<InstructionVM> GetById(int id);
        Task Create(CreateInstructionVM model);
        Task Edit(InstructionVM model);
        Task Delete(int id);
        IEnumerable<InstructionVM> GetInstuctions(Func<DoctorInstruction, bool> predicate);
        IEnumerable<InstuctionFullInfoVM> GetInstuctionsFullInfo(Func<DoctorInstruction, bool> predicate,
        params Expression<Func<DoctorInstruction, object>>[] includeProperties);
    }
}
