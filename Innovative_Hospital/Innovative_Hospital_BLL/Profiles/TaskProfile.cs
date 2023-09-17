using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.Tasks;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<JuniorTaskVM, TaskOfJuniorNurse>();
            CreateMap<TaskOfJuniorNurse, JuniorTaskVM>()
                                                .ForMember(x => x.RoomNumber,opt => opt.MapFrom(y => y.PatientAccounting.Room.RoomNumber))
                                                .ForMember(x => x.PatientFullName,opt => opt.MapFrom(y => y.PatientAccounting.FullNamePatient))
                                                .ForMember(x => x.DepartamentName,opt => opt.MapFrom(y => y.PatientAccounting.Departament.Name))
                                                .ForMember(x => x.FullNameJuniorNurse,opt => opt.MapFrom(y => $"{y.JuniorNurse.FirstName}-{y.JuniorNurse.LastName}-{y.JuniorNurse.Patronomyc}"))
                                                .ForMember(x => x.ImagePath,opt => opt.MapFrom(y => y.PatientAccounting.Patient.ImagePath));

            CreateMap<TaskOfJuniorNurse, EditJuniorTaskVM>();
            CreateMap<EditJuniorTaskVM, TaskOfJuniorNurse>();

            CreateMap<TaskOfJuniorNurse,CreateTaskVM>();
            CreateMap<CreateTaskVM, TaskOfJuniorNurse>();


        }
    }
}
