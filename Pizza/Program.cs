using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Pizza.Database;

namespace Pizza
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();


            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                    context.Database.EnsureCreated();
                    if (!context.Users.Any())
                    {
                        var adminUser = new IdentityUser
                        {
                            UserName = "Admin",
                            Email = "elizaveta3523@gmail.com"
                        };
                        var managerUser = new IdentityUser
                        {
                            UserName = "Manager",
                            Email = "elizaveta3523@gmail.com"
                        };
                        var res1 = userManager.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
                        var res2 = userManager.CreateAsync(managerUser, "password").GetAwaiter().GetResult();

                        var adminClaim = new Claim(ClaimTypes.Role, "Admin");
                        var managerClaim = new Claim(ClaimTypes.Role, "Manager");

                        userManager.AddClaimAsync(adminUser, adminClaim).GetAwaiter().GetResult();
                        userManager.AddClaimAsync(managerUser, managerClaim).GetAwaiter().GetResult();

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .UseNLog();
    }
}
