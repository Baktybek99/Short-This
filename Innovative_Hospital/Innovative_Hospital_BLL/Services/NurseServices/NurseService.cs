using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.Nurse;
using Innovative_Hospital_BLL.ViewModels.Tasks;
using Innovative_Hospital_DAL.Interfaces;
using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.NurseServices
{
    /// <summary>
    /// Сервис хранит в себе основной функционал медсестер
    /// </summary>
    public class NurseService : INurseService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryUser<Nurse> _nurseRep;
        private readonly IRepository<TaskOfJuniorNurse> _taskNurseRep;
        public readonly IMapper _mapper;
        public NurseService(IUnitOfWork uow, IMapper mapper = null)
        {
            _uow = uow;
            _mapper = mapper;
            _nurseRep = _uow.GetRepositoryUser<Nurse>();
            _taskNurseRep = _uow.GetRepository<TaskOfJuniorNurse>();

        }

        /// <summary>
        /// Создать задачу для младшей медсетсры
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateTaskJuniorNurse(CreateTaskVM model)
        {
            await _taskNurseRep.CreateAsync(_mapper.Map<TaskOfJuniorNurse>(model));
            await _taskNurseRep.SaveAsync();
        }


        /// <summary>
        /// Чтоб изменить задание
        /// </summary>
        /// <param name="model"></param>
        public async Task Edit(EditJuniorTaskVM model)
        {
            var task = _taskNurseRep.GetById(model.Id);
            task.Task = model.Task;
            task.TaskDateTime = model.TaskDateTime;
            task.IsCompleted = model.IsCompleted;
            await _taskNurseRep.SaveAsync();
        }

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="id"></param>
        public async Task Delete(int id)
        {
            var task = _taskNurseRep.GetById(id);
            if (task == null)
                throw new NullReferenceException("Вы дали пустое значение");

            _taskNurseRep.Delete(task);
            await _taskNurseRep.SaveAsync();
        }

        /// <summary>
        /// Чтоб получить именя и id медсестер
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<GiveTaskNurseVM> GetJuniorNurse(Func<Nurse, bool> predicate = null)
        {
            return _mapper.Map<IEnumerable<Nurse>, List<GiveTaskNurseVM>>(_nurseRep.Get(predicate));
        }

        /// <summary>
        /// Получить задание
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<JuniorTaskVM> GetTasks(Func<TaskOfJuniorNurse, bool> predicate,
        params Expression<Func<TaskOfJuniorNurse, object>>[] includeProperties )
        {
            //return _mapper.Map<IEnumerable<TaskOfJuniorNurse>, List<JuniorTaskVM>>(_taskNurseRep.GetAsync(predicate));
            return _mapper.Map<IEnumerable<TaskOfJuniorNurse>, List<JuniorTaskVM>>(_taskNurseRep.GetWithInclude(predicate, includeProperties));
        }


        /// <summary>
        /// Отметить что задание выполнено
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task MarkTaskDone(int id)
        {
            var task = await _taskNurseRep.GetByIdAsync(id);
            if (task == null)
                throw new NullReferenceException("Вы дали пу~стое значение");

            task.IsCompleted = true;
            await _taskNurseRep.SaveAsync();
        }

        /// <summary>
        /// Получить задание чтоб изменить его
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EditJuniorTaskVM> GetTaskForEdit(int id)
        {
            return _mapper.Map<EditJuniorTaskVM>(await _taskNurseRep.GetByIdAsync(id));
        }
    }
}
