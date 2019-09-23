using Fatec.CrossCutting.Models.Empresas;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Fatec.DataBase.Map
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            ToTable("Empresa");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_Nome") { IsUnique = true }));

            Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("VARCHAR")
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.UrlSite)
                .HasColumnName("UrlSite")
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);

            Property(x => x.DataCadastro)
                .HasColumnName("DataCadastro");

            HasMany(x => x.VagaEmprego)
                .WithRequired(x => x.Empresa)
                .HasForeignKey(x => x.EmpresaId);

            HasMany(x => x.VagaEstagio)
                .WithRequired(x => x.Empresa)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}