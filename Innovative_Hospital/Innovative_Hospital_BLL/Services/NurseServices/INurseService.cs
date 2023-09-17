using Innovative_Hospital_BLL.ViewModels.Nurse;
using Innovative_Hospital_BLL.ViewModels.Tasks;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.NurseServices
{
    public interface INurseService
    {
        IEnumerable<GiveTaskNurseVM> GetJuniorNurse(Func<Nurse, bool> predicate = null);
        Task CreateTaskJuniorNurse(CreateTaskVM model);
        Task<EditJuniorTaskVM> GetTaskForEdit(int id);
        Task Edit(EditJuniorTaskVM model);
        Task Delete(int id);

        Task MarkTaskDone(int id);

        //IEnumerable<JuniorTaskVM> GetTasks(Func<TaskOfJuniorNurse, bool> predicate = null);
        IEnumerable<JuniorTaskVM> GetTasks(Func<TaskOfJuniorNurse, bool> predicate,
        params Expression<Func<TaskOfJuniorNurse, object>>[] includeProperties);
    }
}
