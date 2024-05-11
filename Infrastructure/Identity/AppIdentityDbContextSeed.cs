using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager){

            if(!userManager.Users.Any()){
                var user = new AppUser
                {
                    DisplayName = "Harshit",
                    Email = "harshit@test.com",
                    UserName ="harshit@test.com",
                    IsAdmin = 0,
                    
                };
                await userManager.CreateAsync(user,"Pa$$w0rd");
                var adminUser = new AppUser
                {
                    DisplayName = "Admin",
                    Email = "admin@example.com",
                    UserName ="admin@example.com",
                    IsAdmin =1
                };
                await userManager.CreateAsync(adminUser,"Pa$$w0rd");
            }
        }
        
    }
}