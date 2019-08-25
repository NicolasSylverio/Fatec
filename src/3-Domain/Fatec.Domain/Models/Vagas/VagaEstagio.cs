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
        public string Empresa { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string URLImagem { get; set; }
    }
}