using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fatec.Domain.Models.Empresas
{
    [Table("Empresa")]
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string UrlSite { get; set; }
        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;
    }
}