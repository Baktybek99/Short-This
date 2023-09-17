using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.Accounting;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Profiles
{
    public class AccountingProfile : Profile
    {
        public AccountingProfile()
        {
            CreateMap<PatientAccounting, AccountingVM>()
                                                        .ForMember(x => x.FullNameDoctor,opt => opt.MapFrom(y => $"{y.Doctor.FirstName}-{ y.Doctor.LastName}-{ y.Doctor.Patronomyc}"))
                                                        //.ForMember(x => x.FullNamePatient,opt => opt.MapFrom(y => $"{y.Patient.FirstName}-{ y.Patient.LastName}-{ y.Patient.Patronomyc}"))
                                                        .ForMember(x => x.EmailPatient,opt => opt.MapFrom(y => y.Patient.Email))
                                                        .ForMember(x => x.WorkPhoneNumber,opt => opt.MapFrom(y => y.Patient.MedicalCard.WorkPhoneNumber))
                                                        .ForMember(x => x.BloodType,opt => opt.MapFrom(y => y.Patient.MedicalCard.BloodType))
                                                        .ForMember(x => x.Allergy,opt => opt.MapFrom(y => y.Patient.MedicalCard.Allergy))
                                                        .ForMember(x => x.Sex,opt => opt.MapFrom(y => y.Patient.Sex))
                                                         .ForMember(x => x.DepartmentName, opt => opt.MapFrom(y => y.Doctor.Departament))
                                                        .ForMember(x => x.RoomNumber, opt => opt.MapFrom(y => y.Room))
                                                        .ForMember(x => x.DoctorInstructions, opt => opt.MapFrom(y => y.DoctorInstructions))
                                                .ReverseMap();
        }
    }
}
