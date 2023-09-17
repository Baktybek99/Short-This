using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.AdminViewModels;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Profiles
{
    public class AdminProfile:Profile
    {
        public AdminProfile()
        {
            CreateMap<CreateEmployeeVM, Doctor>();
            CreateMap<Doctor, CreateEmployeeVM>();

            CreateMap<CreateEmployeeVM, Nurse>();
            CreateMap<Nurse, CreateEmployeeVM>();

            CreateMap<EmployeeInfoVM, Doctor>();
            CreateMap<Doctor, EmployeeInfoVM>().ForMember(x => x.FullName, domain => domain.MapFrom(x => x.FirstName +" "+ x.LastName))
                                               .ForMember(x => x.Position, domain => domain.MapFrom(x => "Доктор"));

            CreateMap<EmployeeInfoVM, Nurse>();
            CreateMap<Nurse, EmployeeInfoVM>().ForMember(x => x.FullName, domain => domain.MapFrom(x => x.FirstName + " " + x.LastName));

            CreateMap<CreateDepartmentVM, Departament>();
            CreateMap<Departament, CreateDepartmentVM>();

            CreateMap<DepartmentInfoVM, Departament>();
            CreateMap<Departament, DepartmentInfoVM>();
        }

        
    }
}
