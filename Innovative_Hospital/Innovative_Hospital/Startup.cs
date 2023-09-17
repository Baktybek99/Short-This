using Innovative_Hospital_BLL.Profiles;
using Innovative_Hospital_BLL.Services;
using Innovative_Hospital_BLL.Services.Accounting;
using Innovative_Hospital_BLL.Services.Admin;
using Innovative_Hospital_BLL.Services.DoctorInstructionServices;
using Innovative_Hospital_BLL.Services.MedicalCardService;
using Innovative_Hospital_BLL.Services.Message;
using Innovative_Hospital_BLL.Services.NurseServices;
using Innovative_Hospital_BLL.Services.PatientDischargesServieces;
using Innovative_Hospital_BLL.Services.Register;
using Innovative_Hospital_DAL.Data;
using Innovative_Hospital_DAL.Interfaces;
using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Innovative_Hospital
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// сюда добавляешь свои автомаперы
        /// </summary>
        private Assembly[] assemblies = new Assembly[]
        {
            //Пример
            //typeof(*Название Класса*).Assembly,
            typeof(PatientProfile).Assembly,
            typeof(NurseProfile).Assembly,
            typeof(TaskProfile).Assembly,
            typeof(DoctorInstructionProfile).Assembly,
            typeof(MedicalCardProfile).Assembly,
            typeof(AdminProfile).Assembly,
            typeof(PatientDischargeProfile).Assembly
        };

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ///Регистрация базы данных
            services.AddDbContext<IHospitalDbContext>(x =>
                                                    x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRegistryService, RegistryService>()
                    .AddScoped<IMessageService, MessageService>()
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<INurseService, NurseService>()
                    .AddScoped<IAccountingService, AccountingService>()
                    .AddScoped<IDoctorInstructionService, DoctorInstructionService>()
                    .AddScoped<IMedicalCardService, MedicalCardService>()
                    .AddScoped<IAdminService, AdminService>()
                    .AddTransient<IPatientDischargeService, PatientDischargeService>();
            


            ///Для отключения валидации пароля
            services.AddIdentity<User, IdentityRole>(x =>
            {
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequiredLength = 3;
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<IHospitalDbContext>();

            ///Регистрация автомаперов
            services.AddAutoMapper(assemblies);

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
