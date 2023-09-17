using Innovative_Hospital_DAL.Data;
using Innovative_Hospital_DAL.Enums;
using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.StaticClasses
{
    /// <summary>
    /// класс заполнения начальных данных пользователей
    /// </summary>
    public static class DbInitializer
    {
        private static IdentityResult createUser;
        private static string password = "123";
        public static async Task Seed(this IHospitalDbContext context, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!context.Departaments.Any())
            {
                var dep1 = new Departament
                {
                    Name = "Хирургическое отделение",
                    IsClosed = false
                };
                var dep2 = new Departament
                {
                    Name = "Кардиологическое отделение",
                    IsClosed = false,
                };
                context.Departaments.AddRange(dep1, dep2);
                context.SaveChanges();
                var room1 = new Room
                {
                    RoomNumber = 1,
                    DepartamentId = dep1.Id,
                    MaxBads = 5,
                    FreeBads = 4
                };
                var room2 = new Room
                {
                    RoomNumber = 120,
                    DepartamentId = dep2.Id,
                    MaxBads = 5,
                    FreeBads = 4
                };
                context.Rooms.AddRange(room1, room2);
                context.SaveChanges();
                var doctor1 = new Doctor
                {
                    FirstName = "Асылбек",
                    LastName = "Карыпов",
                    Patronomyc = "Асанкулович",
                    Sex = Sex.Man,
                    DateOfBirth = DateTime.Now,
                    Email = "doctor1@gmail.com",
                    UserName = "doctor1@gmail.com",
                    DepartamentId = dep1.Id,
                    DateOfEmployment = DateTime.Now,
                    Description = "ГлавВрач",
                    IsFired = false,
                    ImagePath = "/Files/доктор1.jpg"
                };
                createUser = await userManager.CreateAsync(doctor1, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(doctor1, RoleInitializer.roleDoctor);
                }
                var doctor2 = new Doctor
                {
                    FirstName = "Лысый",
                    LastName = "Из",
                    Patronomyc = "Браззерс",
                    Sex = Sex.Man,
                    DateOfBirth = DateTime.Now,
                    Email = "doctor2@gmail.com",
                    UserName = "doctor2@gmail.com",
                    DepartamentId = dep2.Id,
                    DateOfEmployment = DateTime.Now,
                    Description = "ГлавВрач",
                    IsFired = false,
                    ImagePath = "/Files/Лысый.jpg"

                };

                createUser = await userManager.CreateAsync(doctor2, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(doctor2, RoleInitializer.roleDoctor);
                }
                var seniorNurse1 = new Nurse
                {
                    FirstName = "Жанна",
                    LastName = "Николаевна",
                    DateOfBirth = DateTime.Now,
                    Sex = Sex.Woman,
                    Email = "nurse1@gmail.com",
                    UserName = "nurse1@gmail.com",
                    DateOfEmployment = DateTime.Now,
                    Description = "Старшая медсестра",
                    Position = PositionEmployee.Senior_Nurse,
                    IsFired = false,
                    ImagePath = "/Files/медсестра1.jpg"

                };
                createUser = await userManager.CreateAsync(seniorNurse1, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(seniorNurse1, RoleInitializer.roleSeniorNurse);
                }
                var seniorNurse2 = new Nurse
                {
                    FirstName = "Елена",
                    LastName = "Сергеевна",
                    DateOfBirth = DateTime.Now,
                    Sex = Sex.Woman,
                    Email = "nurse2@gmail.com",
                    UserName = "nurse2@gmail.com",
                    DateOfEmployment = DateTime.Now,
                    Description = "Старшая медсестра",
                    Position = PositionEmployee.Senior_Nurse,
                    IsFired = false
                };
                createUser = await userManager.CreateAsync(seniorNurse2, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(seniorNurse2, RoleInitializer.roleSeniorNurse);
                }
                var juniorNurse3 = new Nurse
                {
                    FirstName = "Айгуль",
                    Sex = Sex.Woman,
                    LastName = "Аманова",
                    DateOfBirth = DateTime.Now,
                    Email = "nurse3@gmail.com",
                    UserName = "nurse3@gmail.com",
                    DateOfEmployment = DateTime.Now,
                    Description = "Младшая медсестра",
                    Position = PositionEmployee.Junior_Nurse,
                    IsFired = false,
                    ImagePath = "/Files/медсестра3.jpg"

                };
                createUser = await userManager.CreateAsync(juniorNurse3, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(juniorNurse3, RoleInitializer.roleJuniorNurse);
                }
                var juniorNurse4 = new Nurse
                {
                    FirstName = "Самара",
                    LastName = "Каримова",
                    DateOfBirth = DateTime.Now,
                    Sex = Sex.Woman,
                    Email = "nurse4@gmail.com",
                    UserName = "nurse4@gmail.com",
                    DateOfEmployment = DateTime.Now,
                    Description = "Младшая медсестра",
                    Position = PositionEmployee.Junior_Nurse,
                    IsFired = false,
                    ImagePath = "/Files/медсестра4.jpg"
                };
                createUser = await userManager.CreateAsync(juniorNurse4, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(juniorNurse4, RoleInitializer.roleJuniorNurse);
                }
                var juniorNurse5 = new Nurse
                {
                    FirstName = "Назима",
                    Sex = Sex.Woman,
                    LastName = "Эрнисова",
                    DateOfBirth = DateTime.Now,
                    Email = "nazi@gmail.com",
                    UserName = "nazi@gmail.com",
                    DateOfEmployment = DateTime.Now,
                    Description = "Младшая медсестра",
                    Position = PositionEmployee.Junior_Nurse,
                    ImagePath = "/Files/nazi.jpg",
                    IsFired = false
                };
                createUser = await userManager.CreateAsync(juniorNurse5, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(juniorNurse5, RoleInitializer.roleJuniorNurse);
                }
                var patient1 = new Patient
                {
                    FirstName = "Эрлан",
                    LastName = "Джумагулов",
                    Sex = Sex.Man,
                    DateOfBirth = DateTime.Now,
                    Email = "patient1@gmail.com",
                    UserName = "patient1@gmail.com",
                    ImagePath = "/Files/пациент1.jpg",
                    IsInTheHospital = true,
                    MedicalCard = new MedicalCard
                    {                       
                        Diseases = "Болел Covid19,переболел спидом,Абсцесс,",
                        Allergy = "Алергия на девушек,на пчел,мед",
                        BloodType = BloodType.O,
                        Weight = 80,
                        Height = 180
                    }
                };
                createUser = await userManager.CreateAsync(patient1, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(patient1, RoleInitializer.rolePatient);
                }                

                var patient2 = new Patient
                {
                    FirstName = "Майя",
                    LastName = "Асанова",
                    Sex = Sex.Woman,
                    DateOfBirth = DateTime.Now,
                    Email = "maia@gmail.com",
                    UserName = "maia@gmail.com",
                    ImagePath = "/Files/пациент2.jpg",
                    IsInTheHospital = true,
                    MedicalCard = new MedicalCard
                    {
                        Diseases = "Диабет,Гипофизарный нанизм,Преждевременное половое созревание",
                        Allergy = "Аллергия на мужчин,на воду,хлорку",
                        BloodType = BloodType.A,
                        Weight = 68,
                        Height = 169
                    }
                };
                createUser = await userManager.CreateAsync(patient2, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(patient2, RoleInitializer.rolePatient);
                }               

                var patient3 = new Patient
                {
                    FirstName = "Варвара",
                    Sex = Sex.Woman,
                    LastName = "Щербакова",
                    DateOfBirth = DateTime.Now,
                    Email = "patient3@gmail.com",
                    UserName = "patient3@gmail.com",
                    ImagePath = "/Files/пациент3.jpg",
                    MedicalCard = new MedicalCard
                    {
                        Diseases = "Аддисонова болезнь,Острая перемежающая порфирия,Муковисцидоз,Хронический вирусный гепатит С",
                        Allergy = "аллергия на саму себя",
                        BloodType = BloodType.AB,
                        Weight = 70,
                        Height = 172
                    }
                };
                createUser = await userManager.CreateAsync(patient3, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(patient3, RoleInitializer.rolePatient);
                }               

                var patient4 = new Patient
                {
                    FirstName = "Павел",
                    Sex = Sex.Man,
                    LastName = "Воля",
                    DateOfBirth = DateTime.Now,
                    Email = "patient4@gmail.com",
                    UserName = "patient4@gmail.com",
                    ImagePath = "/Files/пациент4.jpg",
                    MedicalCard = new MedicalCard
                    {
                        Diseases = "Злокачественные новообразования,Гематологические заболевания, гемобластозы, цитопения, наследственные гемопатии",
                        Allergy = "Аллергии Пищевая,Пыльцевая ",
                        BloodType = BloodType.AB,
                        Weight = 80,
                        Height = 160
                    }
                };
                createUser = await userManager.CreateAsync(patient4, password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(patient4, RoleInitializer.rolePatient);
                }
                context.SaveChanges();

                var acc1 = new PatientAccounting
                {
                    PatientId = patient1.Id,
                    DoctorId = doctor1.Id,
                    DepartamentId = dep1.Id,
                    RoomId = room1.Id,
                    FullNamePatient = $"{patient1.FirstName} {patient1.LastName} {patient1.Patronomyc}",
                    ArrivalDate = DateTime.Now,
                    DateOfDischarge = null,
                    IsDischarged = false,
                    ImagePath = patient1.ImagePath,
                    MedicalCardId = patient1.MedicalCardId
                };
                var acc2 = new PatientAccounting
                {
                    PatientId = patient2.Id,
                    DoctorId = doctor2.Id,
                    DepartamentId = dep2.Id,
                    RoomId = room2.Id,
                    FullNamePatient = $"{patient2.FirstName} {patient2.LastName} {patient2.Patronomyc}",
                    ArrivalDate = DateTime.Now,
                    DateOfDischarge = null,
                    IsDischarged = false,
                    ImagePath = patient2.ImagePath,
                    MedicalCardId = patient2.MedicalCardId
                };
                context.PatientAccountings.AddRange(acc1, acc2);
                context.SaveChanges();
                var instruct1 = new DoctorInstruction
                {
                    PatientId = patient1.Id,
                    DoctorId = doctor1.Id,
                    AccountingId = acc1.Id,
                    Analyzes = "Общий анализ мочи. Общий анализ крови",
                    Diagnosis = "Аппендицит",
                    Treatment = "Левофлоксацин 500 мг 1 раз в сутки 7дней" +
                                "Метронидазол 500мг 3 раза в сутки 7 дней"
                };
                var instruct2 = new DoctorInstruction
                {
                    PatientId = patient2.Id,
                    DoctorId = doctor2.Id,
                    AccountingId = acc2.Id,
                    Analyzes = "Общий анализ мочи. Общий анализ крови. Узи брюшной полости",
                    Diagnosis = "Кишечная инфекция",
                    Treatment = "Физ раствор 250мг 1 раз в сутки 7дней внутривенно" +
                                "Цефтриаксон  3 раза в сутки 7 дней внутримышечно"
                };
                context.DoctorInstructions.AddRange(instruct1, instruct2);
                context.SaveChanges();
                List<TaskOfJuniorNurse> tasks = new List<TaskOfJuniorNurse>
                {
                    new TaskOfJuniorNurse
                    {
                        AccountingId = acc1.Id,
                        SeniorNurseId= seniorNurse1.Id,
                        JuniorNurseId = juniorNurse3.Id,
                        Task="Взять анализ мочи",
                        DateOfCreateTask=DateTime.Now,
                        TaskDateTime=DateTime.Today,
                        IsCompleted=false,
                    },
                    new TaskOfJuniorNurse
                    {
                        AccountingId = acc1.Id,
                        SeniorNurseId= seniorNurse1.Id,
                        JuniorNurseId = juniorNurse4.Id,
                        Task="Взять анализ крови",
                        DateOfCreateTask=DateTime.Now,
                        TaskDateTime=DateTime.Today,
                        IsCompleted=false,
                    },
                    new TaskOfJuniorNurse
                    {
                        AccountingId = acc2.Id,
                        SeniorNurseId= seniorNurse2.Id,
                        JuniorNurseId = juniorNurse5.Id,
                        Task="Внутримышечно ввести цефтриаксон 50мг",
                        DateOfCreateTask=DateTime.Now,
                        TaskDateTime=DateTime.Now.AddDays(1),
                        IsCompleted=false,
                    },
                };
                context.TaskOfJuniorNurses.AddRange(tasks);
                context.SaveChanges();
            }
        }
    }
}
