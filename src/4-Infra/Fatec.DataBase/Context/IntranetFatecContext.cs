using Fatec.CrossCutting.Interfaces;
using Fatec.DataBase.Map;
using Fatec.Domain.Models;
using Fatec.Domain.Models.Empresas;
using Fatec.Domain.Models.Vagas;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Fatec.DataBase.Context
{
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
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new TagsMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new VagaEmpregoMap());
            modelBuilder.Configurations.Add(new VagaEstagioMap());
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<VagaEmprego> VagaEmpresa { get; set; }
        public DbSet<VagaEstagio> VagaEstagio { get; set; }
    }
}