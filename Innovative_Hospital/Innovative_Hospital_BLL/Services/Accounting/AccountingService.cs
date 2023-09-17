using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.Accounting;
using Innovative_Hospital_DAL.Interfaces;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.Accounting
{
    public class AccountingService : IAccountingService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<PatientAccounting> _accountingRep;
        private readonly IRepository<Room> _roomRep;
        private readonly IRepositoryUser<Patient> _patientRep;
        private readonly IMapper _mapper;

        public AccountingService(IMapper mapper, IUnitOfWork uow)
        {
            _uow = uow;
            _mapper = mapper;
            _accountingRep = _uow.GetRepository<PatientAccounting>();
            _roomRep = _uow.GetRepository<Room>();
            _patientRep = _uow.GetRepositoryUser<Patient>();
        }

        public async Task DischargeThePatient(int id,DateTime? dateTimeOfDischange = null)
        {
            var accounting =  _accountingRep.GetById(id);
            if(accounting != null)
            {
                accounting.DateOfDischarge = dateTimeOfDischange ?? DateTime.Now;
                accounting.IsDischarged = true;
                var patient = _patientRep.GetById(accounting.PatientId);
                patient.IsInTheHospital = false;
                var room = _roomRep.GetById(accounting.RoomId);
                room.FreeBads++;
                await _accountingRep.SaveAsync();
            }            
        }

        public IEnumerable< AccountingVM> GetAccountings(Func<PatientAccounting, bool> predicate)
        {
            return _mapper.Map<IEnumerable<PatientAccounting>,List<AccountingVM>>(_accountingRep.GetWithInclude(predicate,
                                                                                                                        m => m.Patient.MedicalCard,
                                                                                                                        d => d.Doctor));
        }

        public AccountingVM GetAccountingAsync(int id)
        {
            var accountingInclude = _accountingRep.GetWithInclude(x => x.Patient
                                                                    ,d => d.Doctor );
            return _mapper.Map<AccountingVM>(accountingInclude.FirstOrDefault(x => x.Id == id));
        }

        public AccountingVM GetAcc(string currentUserId)
        {
            var patient = _patientRep.GetById(currentUserId);
            if (patient.IsInTheHospital == true)
            {
                var accountingInclude = _accountingRep.GetWithInclude(x => x.Patient
                                                                     , d => d.Doctor, t=> t.DoctorInstructions);
                return _mapper.Map<AccountingVM>(accountingInclude.FirstOrDefault(x => x.PatientId == currentUserId && x.IsDischarged == false));
            }
            else return null;
        }
    }
}
