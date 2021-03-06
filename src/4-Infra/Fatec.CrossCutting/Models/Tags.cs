﻿using Fatec.CrossCutting.Helper;
using Fatec.CrossCutting.Models.Vagas;
using System;
using System.Collections.Generic;

namespace Fatec.CrossCutting.Models
{
    public class Tags
    {
        public Tags()
        {
            VagaEmprego = new HashSet<VagaEmprego>();
            VagaEstagio = new HashSet<VagaEstagio>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; } = DataHelper.GetHoraBrasilia();

        public bool Ativo { get; set; }

        public virtual ICollection<VagaEmprego> VagaEmprego { get; set; }
        public virtual ICollection<VagaEstagio> VagaEstagio { get; set; }
    }
}