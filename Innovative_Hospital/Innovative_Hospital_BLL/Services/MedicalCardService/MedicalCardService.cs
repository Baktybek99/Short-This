using AutoMapper;
using Innovative_Hospital_BLL.ViewModels;
using Innovative_Hospital_BLL.ViewModels.MedicalCard;
using Innovative_Hospital_DAL.Interfaces;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.MedicalCardService
{
    /// <summary>
    /// Сервис для работы с медкартами
    /// </summary>
    public class MedicalCardService : IMedicalCardService
    {
        private readonly IRepositoryUser<Patient> _patientRep;
        private readonly IRepository<MedicalCard> _medicalCardRep;
        private readonly IMapper _mapper;

        public MedicalCardService(IUnitOfWork uow, IMapper mapper)
        {
            _patientRep = uow.GetRepositoryUser<Patient>();
            _medicalCardRep = uow.GetRepository<MedicalCard>();
            _mapper = mapper;
        }

        /// <summary>
        /// Создание медкарты
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Create(CreateAndEditMedicalCardVM model)
        {
            var patient = await _patientRep.GetByIdAsync(model.PatientId);
            if (patient == null)
                throw new Exception("Пациент с таким IdMedicalCard не найден ");

            patient.MedicalCard = _mapper.Map<MedicalCard>(model);
            await _patientRep.SaveAsync();
        }

      

        /// <summary>
        /// Изменение мед карты
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Edit(CreateAndEditMedicalCardVM model)
        {
            if (model == null)
                throw new Exception("Вы передали пустое значение");

            //var medicalcar = _medicalCardRep.GetById(model.IdMedicalCard);
            //if (medicalcar == null)
            //    throw new Exception("С такой id нету обьекта");

            //model.IdMedicalCard = medicalcar.Id;
            _medicalCardRep.EditEntry(_mapper.Map<MedicalCard>(model));
            await _medicalCardRep.SaveAsync();
        }

       /// <summary>
       /// Получение информации о медкарте
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public async Task<FullMedicalCardInfoVM> GetById(int id)
        {            
            return _mapper.Map<FullMedicalCardInfoVM>(await _medicalCardRep.GetByIdAsync(id));            
        }

        public async Task<CreateAndEditMedicalCardVM> GetForEdit(int id)
        {
            return _mapper.Map<CreateAndEditMedicalCardVM>(await _medicalCardRep.GetByIdAsync(id));
        }
    }
}
