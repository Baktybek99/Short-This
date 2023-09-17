using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.Discharge;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Profiles
{
    public class PatientDischargeProfile : Profile
    {
        public PatientDischargeProfile()
        {
            CreateMap<PatientDischarge, PatientDischargeVM>()
                                                            .ForMember(x => x.ArrivalDate, opt => opt.MapFrom(y => y.PatientAccounting.ArrivalDate))
                                                            .ForMember(x => x.DateOfDischarge, opt => opt.MapFrom(y => y.PatientAccounting.DateOfDischarge));
                                                            

            CreateMap<PatientDischargeVM, PatientDischarge>();
        }
    }
}
