using Innovative_Hospital_BLL.ViewModels;
using Innovative_Hospital_BLL.ViewModels.MedicalCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.MedicalCardService
{
    public interface IMedicalCardService
    {
        Task Create(CreateAndEditMedicalCardVM model);
        Task Edit(CreateAndEditMedicalCardVM model);
        Task<FullMedicalCardInfoVM> GetById(int id);
        Task<CreateAndEditMedicalCardVM> GetForEdit(int id);
    }
}
