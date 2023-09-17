using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.DoctorInstructions;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Profiles
{
    public class DoctorInstructionProfile : Profile
    {
        public DoctorInstructionProfile()
        {
            CreateMap<DoctorInstruction, CreateInstructionVM > ().ReverseMap();
            CreateMap<DoctorInstruction, InstructionVM>().ReverseMap();

            CreateMap<DoctorInstruction, InstuctionFullInfoVM>()
                                                                .ForMember(x => x.FullNamePatient, opt => opt.MapFrom(y => $"{y.Patient.FirstName}-{y.Patient.LastName}-{y.Patient.Patronomyc}"))
                                                                .ForMember(x => x.FullNameDoctor,opt => opt.MapFrom(y => $"{y.Doctor.FirstName}-{y.Doctor.LastName}-{y.Doctor.Patronomyc}"))
                                                                .ForMember(x => x.DepartamentName,opt => opt.MapFrom(y => $"{y.Doctor.Departament.Name}"));
        }
    }
}
