using Innovative_Hospital_BLL.StaticClasses;
using Innovative_Hospital_DAL.Data;
using Innovative_Hospital_DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Innovative_Hospital
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serives = scope.ServiceProvider;
                try
                {
                    var context = serives.GetRequiredService<IHospitalDbContext>();                  
                    await context.Database.MigrateAsync();

                    var userManger = serives.GetRequiredService<UserManager<User>>();
                    var rolesManager = serives.GetRequiredService<RoleManager<IdentityRole>>();
                    await RoleInitializer.InitializeAsync(userManger,rolesManager);
                    await context.Seed(userManger, rolesManager);
                }
                catch (Exception ex)
                {
                    var logger = serives.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error during db seed");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
