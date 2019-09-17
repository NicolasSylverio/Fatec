﻿using Fatec.Domain.Models.Empresas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fatec.Domain.Services;

namespace Fatec.Domain.Models.Vagas
{
    public class VagaEstagio
    {
        public VagaEstagio()
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