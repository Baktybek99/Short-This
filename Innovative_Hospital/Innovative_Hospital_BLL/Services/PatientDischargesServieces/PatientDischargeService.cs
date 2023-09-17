using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.Discharge;
using Innovative_Hospital_DAL.Interfaces;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.PatientDischargesServieces
{
    /// <summary>
    /// Основной сервис для работой с выпиской пациента
    /// </summary>
    public class PatientDischargeService : IPatientDischargeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<PatientDischarge> _dischargeRep;
        private readonly IMessageService _message;
        private readonly IMapper _mapper;

        public PatientDischargeService(IUnitOfWork uow, IMapper mapper, IMessageService message)
        {
            _uow = uow;
            _dischargeRep = _uow.GetRepository<PatientDischarge>();
            _mapper = mapper;
            _message = message;
        }

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Create(PatientDischargeVM model)
        {
            if (model == null)
                throw new Exception("Вы передали пустой обьект");
            var dich = _mapper.Map<PatientDischarge>(model);
           await _dischargeRep.CreateAsync(dich);
            await _dischargeRep.SaveAsync();
            await _message.SendDischarge(model);
        }

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Edit(PatientDischargeVM model)
        {
            if (model == null)
                throw new Exception("Вы передали пустой обьект");

            _dischargeRep.EditEntry(_mapper.Map<PatientDischarge>(model));
            await _dischargeRep.SaveAsync();
        }

        /// <summary>
        /// Взять по id
        /// </summary>
        /// <param name="accountingId"></param>
        /// <returns></returns>
        public PatientDischargeVM GetByIdAsynd(int accountingId)
        {
            var accountingFullInfo = _dischargeRep.GetWithInclude(x => x.PatientAccounting); 
            return _mapper.Map<PatientDischargeVM>(accountingFullInfo.FirstOrDefault(x => x.AccountingId == accountingId));
        }

        /// <summary>
        /// Взять спсиок выписок по определенному условию
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<PatientDischargeVM> GetDischarge(Func<PatientDischarge, bool> predicate)
        {
            return _mapper.Map<IEnumerable<PatientDischarge>, List<PatientDischargeVM>>(_dischargeRep.GetAsync(predicate));
        }
    }
}
