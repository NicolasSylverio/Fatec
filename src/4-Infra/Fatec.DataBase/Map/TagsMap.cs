using Fatec.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Fatec.DataBase.Map
{
    public class TagsMap : EntityTypeConfiguration<Tags>
    {
        public TagsMap()
        {
            ToTable("Tags");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(12)
                .IsRequired()
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_Nome") { IsUnique = true }));

            Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.DataCadastro)
                .HasColumnName("DataCadastro");

            Property(x => x.Ativo)
                .IsRequired();

            HasMany(x => x.VagaEmprego)
                .WithMany(x => x.Tags)
                .Map(x =>
                    {
                        x.ToTable("VagaEmpregoTags");
                        x.MapLeftKey("TagId");
                        x.MapRightKey("VagaEmpregoId");
                    });

            HasMany(x => x.VagaEstagio)
                .WithMany(x => x.Tags)
                .Map(x =>
                {
                    x.ToTable("VagaEstagioTags");
                    x.MapLeftKey("TagId");
                    x.MapRightKey("VagaEstagioId");
                });
        }
    }
}