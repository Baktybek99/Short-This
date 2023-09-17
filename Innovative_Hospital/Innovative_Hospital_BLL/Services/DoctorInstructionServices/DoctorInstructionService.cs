using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.DoctorInstructions;
using Innovative_Hospital_DAL.Interfaces;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.DoctorInstructionServices
{
    /// <summary>
    /// Сервис для работы с инструкцией доктора
    /// </summary>
    public class DoctorInstructionService : IDoctorInstructionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<DoctorInstruction> _instructionRep;
        private readonly IMapper _mapper;
        private  DoctorInstruction _instruction;
        public DoctorInstructionService(IUnitOfWork uow , IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _instructionRep = _uow.GetRepository<DoctorInstruction>();
        }

        /// <summary>
        /// Создание 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Create(CreateInstructionVM model)
        {
            if(model == null)
                throw new NullReferenceException("Вы дали пустое значение");

            await _instructionRep.CreateAsync(_mapper.Map<DoctorInstruction>(model));
            await _instructionRep.SaveAsync();
        }

        /// <summary>
        /// удаление 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            _instruction = await _instructionRep.GetByIdAsync(id);
            if(_instruction == null)
                throw new NullReferenceException("Вы дали пустое значение");

            _instructionRep.Delete(_instruction);
            await _instructionRep.SaveAsync();
        }

        /// <summary>
        /// Изменение 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Edit(InstructionVM model)
        {
            if (model == null)
                throw new NullReferenceException("Вы дали пустое значение");

            _instruction = await _instructionRep.GetByIdAsync(model.Id);

            if(_instruction == null)
                throw new Exception("Такое значение не существует");

            _instruction.Analyzes = model.Analyzes;
            _instruction.Diagnosis = model.Diagnosis;
            _instruction.Treatment = model.Treatment;
            await _instructionRep.SaveAsync();
        }

        /// <summary>
        /// Взять наставление врача по IdMedicalCard
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<InstructionVM> GetById(int id)
        {
            return _mapper.Map<InstructionVM>(await _instructionRep.GetByIdAsync(id) ?? null);
        }

        /// <summary>
        /// Взять список наставлений врача по определенным условим
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<InstructionVM> GetInstuctions(Func<DoctorInstruction, bool> predicate)
        {
            return _mapper.Map<IEnumerable<DoctorInstruction>, List<InstructionVM>>(_instructionRep.GetAsync(predicate) );
        }

        /// <summary>
        /// Взять полную информацию о наставлении врача
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<InstuctionFullInfoVM> GetInstuctionsFullInfo(Func<DoctorInstruction, bool> predicate, params Expression<Func<DoctorInstruction, object>>[] includeProperties)
        {
            return _mapper.Map<IEnumerable<DoctorInstruction>, List<InstuctionFullInfoVM>>(_instructionRep.GetWithInclude(predicate,includeProperties));
        }
    }
}
