using ISOCertificate.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ISOCertificate.DAL
{
    public class DbInitializer
    {
        public static async Task Seed(CertificateDbContext context,
           UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Role.Admin))
                await roleManager.CreateAsync(new IdentityRole(Role.Admin));

            if (!await roleManager.RoleExistsAsync(Role.User))
                await roleManager.CreateAsync(new IdentityRole(Role.User));

            if (!await roleManager.RoleExistsAsync(Role.SuperAdmin))
                await roleManager.CreateAsync(new IdentityRole(Role.SuperAdmin));

            if (await userManager.FindByNameAsync("SuperAdmin") == null)
            {
                var admin = new ApplicationUser
                {
                    Email = "admin@morpho.az",
                    UserName = "admin",
                    PhoneNumber = "+9945555555",
                    PhoneNumberConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "Firuza123!");

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, Role.SuperAdmin);

                await context.SaveChangesAsync();
            }
        }
    }
}
