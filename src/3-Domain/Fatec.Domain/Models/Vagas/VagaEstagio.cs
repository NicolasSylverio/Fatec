using Fatec.Domain.Models.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatec.Domain.Models.Vagas
{
    public class VagaEstagio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Descricao { get; set; }
        public virtual Empresa Empresa { get; set; }
        public string UrlImagem { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataValidade { get; set; }
    }
}