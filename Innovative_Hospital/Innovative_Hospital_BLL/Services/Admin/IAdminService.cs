using Innovative_Hospital_BLL.ViewModels.AdminViewModels;
using Innovative_Hospital_DAL.Models;
using Innovative_Hospital_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.Admin
{
    /// <summary>
    /// Все функции Админа
    /// </summary>
    public interface  IAdminService
    {
        /// <summary>
        /// Для регистрации сотрудника 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task CreateEmployeeAsync(CreateEmployeeVM model);
        /// <summary>
        /// Для изменения данных сотрудника 
        /// </summary>
        /// <param name="model"></param>
        public Task<EditEmployeeVM> EditEmployeeAsync(EditEmployeeVM model);
        /// <summary>
        /// Для увольнения сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> FireEmployeeAsync(string id);
        /// <summary>
        /// Для восстановления уволенного сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> RecoveryEmployeeAsync(string id);
        /// <summary>
        /// Для получения списка всех сотрудников
        /// </summary>
        /// <returns></returns>
        public Task<List<EmployeeInfoVM>> GetAllEmployeesAsync(Expression<Func<Employee, bool>> predicate);
        /// <summary>
        /// Для получения данных одного сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<EmployeeInfoVM> GetEmployeeAsync(string id);

        /// <summary>
        /// Для получения данных одного отделения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<DepartmentInfoVM>> GetAllDepartmentsAsync(Expression<Func<Departament, bool>> predicate);

        /// <summary>
        /// Для создания нового отделения
        /// </summary>
        /// <param name="model"></param>
        public Task CreateDepartmentAsync(CreateDepartmentVM model);
        /// <summary>
        /// Для закрытия отделения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> CloseDepartmentAsync(int id);
        /// <summary>
        /// Для открытия отделения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> OpenDepartmentAsync(int id);
        /// <summary>
        /// Для создания палаты
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public Task CreateRoomAsync(int id, Room model);
        /// <summary>
        /// Для изменения палаты
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> EditRoomAsync(int id);
        /// <summary>
        /// Для поиска сотрудника
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public  Task<List<EmployeeInfoVM>> SearchAsync(string searchText);
        /// <summary>
        /// Для фильтрации сотрудников по должности
        /// </summary>
        /// <param name="companyFilter"></param>
        /// <returns></returns>
        public Task<List<EmployeeInfoVM>> FilterEmployees(EmployeeFilter companyFilter);
        /// <summary>
        /// Для списка докторов по отделению
        /// </summary>
        /// <param name="departament"></param>
        /// <returns></returns>
        public Task<List<EmployeeInfoVM>> GetDoctorsByDep(Departament departament);
        /// <summary>
        /// Для списка палат по отделению
        /// </summary>
        /// <param name="departament"></param>
        /// <returns></returns>
        public Task<List<RoomInfoVM>> GetRoomsByDep(Departament departament);



    }
}
