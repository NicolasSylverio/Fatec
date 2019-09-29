using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Fatec.CrossCutting.Models.Vagas;

namespace Fatec.DataBase.Map
{
    public class VagaEstagioMap : EntityTypeConfiguration<VagaEstagio>
    {
        public VagaEstagioMap()
        {
            ToTable("VagaEstagio");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_Nome") { IsUnique = true }));

            Property(x => x.Subtitulo)
                .HasColumnName("Subtitulo")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(512)
                .IsRequired();

            Property(x => x.UrlImagem)
                .HasColumnName("UrlImagem")
                .HasColumnType("VARCHAR")
                .HasMaxLength(512)
                .IsRequired();

            Property(x => x.DataHoraCadastro)
                .HasColumnName("DataHoraCadastro");

            Property(x => x.DataValidade)
                .HasColumnName("DataValidade");

            Property(x => x.EmpresaId)
                .HasColumnName("EmpresaId")
                .IsRequired();

            HasRequired(x => x.Empresa)
                .WithMany(x => x.VagaEstagio)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}