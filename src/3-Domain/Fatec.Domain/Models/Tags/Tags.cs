using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fatec.Domain.Models.Tags
{
    [Table("Tags")]
    public class Tags
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("Nome", TypeName = "VARCHAR")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Descricao", TypeName = "VARCHAR")]
        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Required]
        public bool Ativo { get; set; }
    }
}