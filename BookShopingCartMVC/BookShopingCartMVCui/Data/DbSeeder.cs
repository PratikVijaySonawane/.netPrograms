using BookShopingCartMVCui.Constants;
using Microsoft.AspNetCore.Identity;

namespace BookShopingCartMVCui.Data
{
    public class DbSeeder
    {
        /* Declaring the Method */
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            /* Creating the Instance Of the UserManager and  RoleManager */
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();

            /* Adding the Role into the Database */
            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));

            /* Creating the Object of the Admin */
            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
            };

            /* Finding the User in DB by Email */
            var userInDb = await userMgr.FindByEmailAsync(admin.Email); 
            if(userInDb is  null)
            {
                await userMgr.CreateAsync(admin, "Admin@123");
                await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());    
            }          
        }

    }
}
