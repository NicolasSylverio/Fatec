using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Fatec.DataBase.Context
{
    public class Context : DbContext
    {
        public Context() : base("ConnectionString")

        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}