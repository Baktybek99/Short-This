using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_DAL.Data
{
    /// <summary>
    /// Класс отвечаюший за таблицы в бд
    /// </summary>
    public class IHospitalDbContext : IdentityDbContext<User>
    {
        public IHospitalDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Nurse> Nurses { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Departament> Departaments { get; set; }

        public DbSet<DoctorInstruction> DoctorInstructions { get; set; }

        public DbSet<MedicalCard> MedicalCards { get; set; }

        public DbSet<PatientAccounting> PatientAccountings { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<TaskOfJuniorNurse> TaskOfJuniorNurses { get; set; }

        public DbSet<PatientDischarge> PatientDischarge { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var user = builder.Entity<User>();
            builder.Entity<Room>().HasIndex(x => x.RoomNumber).IsUnique();
            user.HasIndex(x => x.Email).IsUnique();
            user.Property(x => x.Email).IsRequired();

        }
    }
}
