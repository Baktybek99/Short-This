using Innovative_Hospital_BLL.ViewModels.DoctorViewModels;
using Innovative_Hospital_BLL.ViewModels.PatientViewModels;
using Innovative_Hospital_BLL.ViewModels.Rooms;
using Innovative_Hospital_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.Register
{
    /// <summary>
    /// Здечь будет прописан основной функционал регистраутуры
    /// </summary>
    public interface IRegistryService
    {
        Task CreatePatient(CreatePatientVM model);
        Task Registration(RegistrationPatientVM model);
        IEnumerable<PatientsNotFullInfoVM> GetPatient(Func<Patient, bool> predicate = null);
        IEnumerable<DoctorNameIdVM> GetDoctorId(Func<Doctor, bool> predicate = null);
        IEnumerable<RoomVM> GetRoomId(Func<Room, bool> predicate = null);
        Task<IEnumerable<Departament>> GetDepartaments();
        Task<PatientsNotFullInfoVM> GetPatientById(string id);
        Patient CurrentPatient(Func<Patient, bool> predicate = null);
    }
}
