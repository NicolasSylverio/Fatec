using Fatec.Domain.Models.Empresas;
using Fatec.Domain.Services;
using System;
using System.Collections.Generic;

namespace Fatec.Domain.Models.Vagas
{
    public class VagaEmprego
    {
        public VagaEmprego()
        {
            Tags = new HashSet<Tags>();
        }

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Subtitulo { get; set; }

        public string Descricao { get; set; }

        public string UrlImagem { get; set; }

        public DateTime DataHoraCadastro { get; set; } = DateService.PegaHoraBrasilia();

        public DateTime DataValidade { get; set; }

        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Tags> Tags { get; set; }
    }
}