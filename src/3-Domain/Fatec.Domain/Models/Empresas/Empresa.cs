using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fatec.Domain.Models.Empresas
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Nome", TypeName = "VARCHAR")]
        public string Nome { get; set; }

        [EmailAddress]
        [MaxLength(200)]
        [Column("Email", TypeName = "VARCHAR")]
        public string Email { get; set; }

        [MaxLength(15)]
        [Column("Telefone", TypeName = "VARCHAR")]
        public string Telefone { get; set; }

        [MaxLength(512)]
        [Column("UrlSite", TypeName = "VARCHAR")]
        public string UrlSite { get; set; }

        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;
    }
}