using AutoMapper;
using Innovative_Hospital_BLL.StaticClasses;
using Innovative_Hospital_BLL.ViewModels.AdminViewModels;
using Innovative_Hospital_DAL.Data;
using Innovative_Hospital_DAL.Enums;
using Innovative_Hospital_DAL.Models;
using Innovative_Hospital_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Innovative_Hospital_BLL.Services.Admin
{
    /// <summary>
    /// здесь прописан основной функционал Админа
    /// </summary>
    public class AdminService : IAdminService
    {
        private readonly IHospitalDbContext _context;
        private readonly UserManager<User> _employeeManager;
        private readonly IMapper _mapper;

        public AdminService(IHospitalDbContext context, IMapper mapper, UserManager<User> employeeManager )
        {
            _context = context;
            _mapper = mapper;
            _employeeManager = employeeManager;
        }
        public async Task<bool> CloseDepartmentAsync(int id)
        {
            var department = await _context.Departaments.FirstOrDefaultAsync(x => x.Id == id);

            if (department != null)
            {
                department.IsClosed = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task CreateDepartmentAsync(CreateDepartmentVM model)
        {
            var department = _mapper.Map<Departament>(model);
           await _context.Departaments.AddAsync(department);
            await _context.SaveChangesAsync();

        }
        public async Task CreateEmployeeAsync(CreateEmployeeVM model)
        {

            if (model.IsDoctor == true)
            {
                var doctor = _mapper.Map<Doctor>(model);
                doctor.DateOfEmployment = DateTime.Now;
                doctor.UserName = model.Email;
                var createDoctor = await _employeeManager.CreateAsync(doctor, model.Password);
                if (createDoctor.Succeeded)
                {
                    await _employeeManager.AddToRoleAsync(doctor, RoleInitializer.roleDoctor);
                }
            }
            else
            {
                if (model.IsSeniorNurse == true)
                {
                    var seniorNurse = _mapper.Map<Nurse>(model);
                    seniorNurse.DateOfEmployment = DateTime.Now;
                    seniorNurse.UserName = model.Email;
                    var createNurse = await _employeeManager.CreateAsync(seniorNurse, model.Password);
                    if (createNurse.Succeeded)
                    {
                        await _employeeManager.AddToRoleAsync(seniorNurse, RoleInitializer.roleSeniorNurse);
                    }
                }
                else
                {
                    var juniorNurse = _mapper.Map<Nurse>(model);
                    juniorNurse.DateOfEmployment = DateTime.Now;
                    juniorNurse.UserName = model.Email;
                    var createNurse = await _employeeManager.CreateAsync(juniorNurse, model.Password);
                    if (createNurse.Succeeded)
                    {
                        await _employeeManager.AddToRoleAsync(juniorNurse, RoleInitializer.roleJuniorNurse);
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
        public async Task CreateRoomAsync(int id, Room model)
        {
           // var doctor = _context.Departaments.FirstOrDefault(x => x.Id == id);
            await _context.Rooms.AddAsync(model);
            await _context.SaveChangesAsync();
            
        }
        public async Task<EditEmployeeVM> EditEmployeeAsync(EditEmployeeVM model)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == model.Id);

            employee = _mapper.Map(model, employee);
            var result = _context.Employees.Update(employee);
           
            await _context.SaveChangesAsync();
            return _mapper.Map<EditEmployeeVM>(employee);

        }
        public async Task<bool> EditRoomAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> FireEmployeeAsync(string id)
        {
            var employee = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                employee.IsFired = true;
                employee.LockoutEnabled = false;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public async Task<List<EmployeeInfoVM>> GetAllEmployeesAsync(Expression<Func<Employee, bool>> predicate)
        {
            var employees = await _context.Employees.Where(predicate).ToListAsync();
            return _mapper.Map<List<EmployeeInfoVM>>(employees);
        }
        public async Task<EmployeeInfoVM> GetEmployeeAsync(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return _mapper.Map<EmployeeInfoVM>(employee);
        }
        public async Task<bool> OpenDepartmentAsync(int id)
        {
            var department = await  _context.Departaments.FirstOrDefaultAsync(x => x.Id == id);

            if (department != null)
            {
                department.IsClosed = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> RecoveryEmployeeAsync(string id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                employee.IsFired = false;
                employee.LockoutEnabled = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<DepartmentInfoVM>> GetAllDepartmentsAsync(Expression<Func<Departament, bool>> predicate)
        {
            var dep = await _context.Departaments.Where(predicate).ToListAsync();

            var result = _mapper.Map<List<DepartmentInfoVM>>(dep);

            return result;
        }
        public async Task<List<EmployeeInfoVM>> SearchAsync(string searchText)
        {
            var filters = new string[] { };

            if (!string.IsNullOrEmpty(searchText))
            {
                filters = searchText.Trim().ToLower().Split(" ");
                filters = filters.Where(filter => !string.IsNullOrEmpty(filter)).Take(4).ToArray();
            }

            var query = _context.Employees.Where(employee => true);

            foreach (var filter in filters)
                query = query.Where(employee =>
                    employee.Email.ToLower().Contains(filter)
                    || employee.FirstName.ToLower().Contains(filter)
                    || employee.LastName.ToLower().Contains(filter)
                    || employee.Patronomyc.ToLower().Contains(filter));

            var employees = await query.ToListAsync();
            var result = _mapper.Map<List<EmployeeInfoVM>>(employees);

            return result;
        }
        public async Task<List<EmployeeInfoVM>> FilterEmployees(EmployeeFilter employeeFilter)
        {
            if(employeeFilter.Position == RoleInitializer.StatusFilter[0])
            {
                var employees = await _context.Employees.ToListAsync();
                return _mapper.Map<List<EmployeeInfoVM>>(employees);
            }
            else if(employeeFilter.Position == RoleInitializer.StatusFilter[1])
            {
                var doctors = await _context.Doctors.ToListAsync();
                return  _mapper.Map<List<EmployeeInfoVM>>(doctors);
            }
            else if (employeeFilter.Position == RoleInitializer.StatusFilter[2])
            {
                var seniors = await _context.Nurses.Where(x=>x.Position==PositionEmployee.Senior_Nurse).ToListAsync();
                return _mapper.Map<List<EmployeeInfoVM>>(seniors);
            }
            else
            {
                var seniors = await _context.Nurses.Where(x => x.Position == PositionEmployee.Junior_Nurse).ToListAsync();
                return _mapper.Map<List<EmployeeInfoVM>>(seniors);
            }
        }
        public async Task<List<EmployeeInfoVM>> GetDoctorsByDep(Departament departament)
        {
            var doctors = await _context.Doctors.Where(x=>x.DepartamentId==departament.Id).ToListAsync();
            return _mapper.Map<List<EmployeeInfoVM>>(doctors);
        }
        public async Task<List<RoomInfoVM>> GetRoomsByDep(Departament departament)
        {
            var rooms = await _context.Rooms.Where(x => x.DepartamentId == departament.Id).ToListAsync();
            return _mapper.Map<List<RoomInfoVM>>(rooms);
        }

    }
}
