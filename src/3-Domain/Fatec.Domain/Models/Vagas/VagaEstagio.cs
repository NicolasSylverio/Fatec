using Fatec.Domain.Models.Empresas;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fatec.Domain.Models.Vagas
{
    [Table("VagaEstagio")]
    public class VagaEstagio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Descricao { get; set; }
        public virtual Empresa Empresa { get; set; }
        public string UrlImagem { get; set; }
        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;
        public DateTime DataValidade { get; set; }
    }
}