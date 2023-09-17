using AutoMapper;
using Innovative_Hospital_BLL.ViewModels.DoctorViewModels;
using Innovative_Hospital_BLL.ViewModels.PatientViewModels;
using Innovative_Hospital_BLL.ViewModels.Rooms;
using Innovative_Hospital_DAL.Data;
using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.Register
{
    /// <summary>
    /// Здечь будет прописан основной функционал регистраутуры
    /// </summary>
    public class RegistryService : IRegistryService
    {
        private readonly IHospitalDbContext _context;
        private readonly UserManager<User> _patientManager;
        private readonly IMapper _mapper;
        //private readonly IMessageService _messageService;
        public RegistryService(IHospitalDbContext context, IMapper mapper, UserManager<User> patientManager/*, IMessageService messageService*/)
        {
            _context = context;
            _mapper = mapper;
            _patientManager = patientManager;
            //_messageService = messageService;
        }

        /// <summary>
        /// Для создания аккаунта пациенту
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreatePatient(CreatePatientVM model)
        {
            var patient = _mapper.Map<Patient>(model);
            var createPatient = await _patientManager.CreateAsync(patient, model.Password);
            if (createPatient.Succeeded)
            {
                await _patientManager.AddToRoleAsync(patient, "Patient");
                // await _messageService.SendWelcomeAsync(model.Email,$"{model.FirstName} {model.LastName}");
            }
        }


        /// <summary>
        /// Взять всех пациентов 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<PatientsNotFullInfoVM> GetPatient(Func<Patient, bool> predicate = null)
        {
            var patients = _context.Patients.Include(x => x.MedicalCard).Where(predicate);
            return _mapper.Map<IEnumerable<Patient>, List<PatientsNotFullInfoVM>>(patients);
        }
        

        /// <summary>
        /// Для поставления на учет пациенты
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Registration(RegistrationPatientVM model)
        {
            _context.PatientAccountings.Add(_mapper.Map<PatientAccounting>(model));
            var patient = await _context.Patients.FindAsync(model.PatientId);
            patient.IsInTheHospital = true;
            var room = await _context.Rooms.FindAsync(model.RoomId);
            room.FreeBads--;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Возварщает полное имя доктора и его ID
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<DoctorNameIdVM> GetDoctorId(Func<Doctor, bool> predicate = null)
        {
            var doctors = _context.Doctors.Where(predicate);
            return _mapper.Map<IEnumerable<Doctor>, List<DoctorNameIdVM>>(doctors);

        }

        /// <summary>
        /// Возврщает название комнаты и его IdMedicalCard
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<RoomVM> GetRoomId(Func<Room, bool> predicate = null)
        {
            var rooms = _context.Rooms.Where(predicate);
            return _mapper.Map<IEnumerable<Room>, List<RoomVM>>(rooms);
        }

        /// <summary>
        /// Возрващает отделения
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Departament>> GetDepartaments()
        {
            return await _context.Departaments.ToListAsync();
        }

        public async Task<PatientsNotFullInfoVM> GetPatientById(string id)
        {
            return _mapper.Map<PatientsNotFullInfoVM>(await _context.Patients.FindAsync(id));
        }
        public Patient  CurrentPatient(Func<Patient, bool> predicate = null)
        {
            var patients = _context.Patients.Where(predicate);
            return (Patient)patients;
        }
    }
}
