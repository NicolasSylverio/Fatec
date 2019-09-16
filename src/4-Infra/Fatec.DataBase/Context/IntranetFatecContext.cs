using Fatec.CrossCutting.Interfaces;
using Fatec.Domain.Models.Empresas;
using Fatec.Domain.Models.Tags;
using Fatec.Domain.Models.Vagas;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Fatec.Infra.DataBase.Context
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class IntranetFatecContext : DbContext, IDbContext
    {
        public IntranetFatecContext()
            : base("IntranetFatecContext")
        {
        }

        public IntranetFatecContext(string connectionString)
           : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<VagaEmprego> VagaEmpresa { get; set; }
        public DbSet<VagaEstagio> VagaEstagio { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Tags> Tags { get; set; }
    }
}