using Innovative_Hospital_BLL.ViewModels.Accounting;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.Accounting
{
    public interface IAccountingService
    {
        
        IEnumerable<AccountingVM> GetAccountings(Func<PatientAccounting, bool> predicate);
        Task DischargeThePatient(int id, DateTime? dateTimeOfDischange);
        public AccountingVM GetAccountingAsync(int id);
        public AccountingVM GetAcc(string currentUserId);

    }
}
