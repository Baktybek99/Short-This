using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.Nurse;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Profiles
{
    /// <summary>
    /// Класс для того чтоб мапить данные медсестры
    /// </summary>
    public class NurseProfile : Profile
    {
        public NurseProfile()
        {
            CreateMap<GiveTaskNurseVM,Nurse>();
            CreateMap<Nurse, GiveTaskNurseVM>()
                                                .ForMember(x => x.FullName,opt => opt.MapFrom(y => $"{y.FirstName}-{y.LastName}-{y.Patronomyc}"));
        }
    }
}
