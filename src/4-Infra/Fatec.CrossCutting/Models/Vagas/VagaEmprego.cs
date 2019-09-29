using Fatec.CrossCutting.Helper;
using Fatec.CrossCutting.Models.Empresas;
using System;
using System.Collections.Generic;

namespace Fatec.CrossCutting.Models.Vagas
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

        public DateTime DataHoraCadastro { get; set; } = DataHelper.GetHoraBrasilia();

        public DateTime DataValidade { get; set; }

        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<int> TagsId { get; set; }

        public virtual ICollection<Tags> Tags { get; set; }
    }
}