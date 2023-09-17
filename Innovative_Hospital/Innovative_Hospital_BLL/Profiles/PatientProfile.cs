using AutoMapper;
using Innovative_Hospital_BLL.ViewModels;
using Innovative_Hospital_BLL.ViewModels.DoctorViewModels;
using Innovative_Hospital_BLL.ViewModels.PatientViewModels;
using Innovative_Hospital_BLL.ViewModels.Rooms;
using Innovative_Hospital_DAL.Models;

namespace Innovative_Hospital_BLL.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<CreatePatientVM, Patient>()
                                        .ForMember(x => x.UserName,opt => opt.MapFrom(y => y.SetUserName));
            CreateMap<Patient, CreatePatientVM >();

            CreateMap<PatientAccounting,RegistrationPatientVM>();
            CreateMap<RegistrationPatientVM, PatientAccounting>();

            CreateMap<PatientsNotFullInfoVM, Patient>();
            CreateMap<Patient, PatientsNotFullInfoVM>()
                                                .ForMember(x => x.FullName, opt => opt.MapFrom(y => $"{y.FirstName}-{y.LastName}-{y.Patronomyc}"))
                                                //.ForMember(x => x.MedicalCard, opt => opt.MapFrom(y => y.MedicalCard))
                                                //.ForMember(x => x.MedicalCard.IdMedicalCard, opt => opt.MapFrom(y => y.MedicalCard.IdMedicalCard))
                                                //.ForMember(x => x.MedicalCard.PatientId, opt => opt.MapFrom(y => y.MedicalCard.PatientId))
                                                //.ForMember(x => x.MedicalCard.Sex, opt => opt.MapFrom(y => y.Sex))
                                                //.ForMember(x => x.MedicalCard.Diseases, opt => opt.MapFrom(y => y.MedicalCard.Diseases))
                                                //.ForMember(x => x.MedicalCard.Allergy, opt => opt.MapFrom(y => y.MedicalCard.Allergy))
                                                //.ForMember(x => x.MedicalCard.BloodType, opt => opt.MapFrom(y => y.MedicalCard.BloodType))
                                                //.ForMember(x => x.MedicalCard.Weight, opt => opt.MapFrom(y => y.MedicalCard.Weight))
                                                //.ForMember(x => x.MedicalCard.Height, opt => opt.MapFrom(y => y.MedicalCard.Height))
                                                //.AfterMap(x => x.MedicalCard.Diseases, opt => opt.MapFrom(y => y.MedicalCard.Diseases))
                                                // .AfterMap((src, dest) => dest.MedicalCard= src.MedicalCard)                                                
                                                ;

            CreateMap<MedicalCard, MedicalCardVM>();
            CreateMap<MedicalCardVM, MedicalCard>();

            
            CreateMap<Doctor, DoctorNameIdVM>()
                                                .ForMember(x => x.FullName,opt => opt.MapFrom(y => $"{y.FirstName}-{y.LastName}-{y.Patronomyc}"));
            CreateMap<DoctorNameIdVM, Doctor >();

            CreateMap<Room, RoomVM>();
            CreateMap<RoomVM, Room>();

        }
    }
}
