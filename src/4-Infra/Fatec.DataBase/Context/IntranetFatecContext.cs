﻿using Fatec.CrossCutting.Interfaces;
using Fatec.CrossCutting.Models;
using Fatec.CrossCutting.Models.Empresas;
using Fatec.CrossCutting.Models.Identity;
using Fatec.CrossCutting.Models.Vagas;
using Fatec.DataBase.Map;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Fatec.DataBase.Context
{
    public class IntranetFatecContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public IntranetFatecContext()
            : base("IntranetFatecContext")
        {
        }

        public IntranetFatecContext(string connectionString)
           : base(connectionString)
        {

        }

        public static IntranetFatecContext Create()
        {
            return new IntranetFatecContext();
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

            base.OnModelCreating(modelBuilder);
        }

        // Domain
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<VagaEmprego> VagaEmprego { get; set; }
        public DbSet<VagaEstagio> VagaEstagio { get; set; }

        // Identity
        public DbSet<IdentityUserLogin> UserLogins { get; set; }
        public DbSet<IdentityUserClaim> UserClaims { get; set; }
        public DbSet<IdentityUserRole> UserRoles { get; set; }
    }
}