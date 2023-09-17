using AutoMapper;
using Innovative_Hospital_BLL.ViewModels;
using Innovative_Hospital_BLL.ViewModels.MedicalCard;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Profiles
{
    public class MedicalCardProfile : Profile
    {
        public MedicalCardProfile()
        {
            CreateMap<MedicalCard, MedicalCardVM>().ReverseMap();
            CreateMap<MedicalCard, FullMedicalCardInfoVM>().ReverseMap();
            CreateMap<MedicalCard, CreateAndEditMedicalCardVM>()
                                                                .ForMember(x => x.IdMedicalCard, opt => opt.MapFrom(y => y.Id)) 
                                                                .ReverseMap();



        }
    }
}
