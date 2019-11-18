using Fatec.CrossCutting.Models.Identity;
using Fatec.DataBase.Context;
using Fatec.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Fatec.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            CreateRolesAndUsers();
        }

        // In this method we will create default User roles and Admin user for login   
        private void CreateRolesAndUsers()
        {
            var context = new IntranetFatecContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("administrador"))
            {
                using (var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    // first we create Admin rool   
                    var role = new IdentityRole
                    {
                        Name = "administrador"
                    };

                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website                  

                    var user = new ApplicationUser
                    {
                        UserName = "nicolas",
                        Email = "nicolas_sylveriopereira@hotmail.com"
                    };

                    string userPWD = "01Senha!";

                    var chkUser = UserManager.Create(user, userPWD);

                    //Add default User to Role Admin   
                    if (chkUser.Succeeded)
                    {
                        _ = UserManager.AddToRole(user.Id, "administrador");

                    }
                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("usuario"))
            {
                var role = new IdentityRole
                {
                    Name = "usuario"
                };

                roleManager.Create(role);
            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("visitante"))
            {
                var role = new IdentityRole
                {
                    Name = "visitante"
                };

                roleManager.Create(role);
            }
        }
    }
}
