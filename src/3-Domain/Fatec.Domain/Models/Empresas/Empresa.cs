﻿using Fatec.Domain.Models.Vagas;
using Fatec.Domain.Services;
using System;
using System.Collections.Generic;

namespace Fatec.Domain.Models.Empresas
{
    public class Empresa
    {
        public Empresa()
        {
            VagaEmprego = new HashSet<VagaEmprego>();
            VagaEstagio = new HashSet<VagaEstagio>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string UrlSite { get; set; }

        public DateTime DataCadastro { get; set; } = DateService.PegaHoraBrasilia();

        public virtual ICollection<VagaEmprego> VagaEmprego { get; set; }
        public virtual ICollection<VagaEstagio> VagaEstagio { get; set; }
    }
}