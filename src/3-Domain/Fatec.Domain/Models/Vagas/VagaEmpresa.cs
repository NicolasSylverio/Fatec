using Fatec.Domain.Models.Empresas;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fatec.Domain.Models.Vagas
{
    [Table("VagaEmprego")]
    public class VagaEmprego
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Titulo", TypeName = "VARCHAR")]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Subtitulo", TypeName = "VARCHAR")]
        public string Subtitulo { get; set; }

        [Required]
        [MaxLength(512)]
        [Column("Descricao", TypeName = "VARCHAR")]
        public string Descricao { get; set; }

        public virtual Empresa Empresa { get; set; }

        [MaxLength(512)]
        [Column("UrlImagem", TypeName = "VARCHAR")]
        public string UrlImagem { get; set; }

        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;

        public DateTime DataValidade { get; set; }
    }
}