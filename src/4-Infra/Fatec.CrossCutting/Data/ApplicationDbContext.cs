using Fatec.CrossCutting.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fatec.Infra.CrossCutting.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
