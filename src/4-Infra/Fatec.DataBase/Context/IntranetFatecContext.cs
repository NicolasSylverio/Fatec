using Fatec.Domain.Models.Vagas;
using MySql.Data.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Fatec.Infra.DataBase.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class IntranetFatecContext : DbContext
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

        public DbSet<VagaEstagio> VagaEstagio { get; set; }
    }
}