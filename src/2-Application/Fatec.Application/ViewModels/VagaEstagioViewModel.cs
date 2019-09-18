using Fatec.Domain.Services;
using System;
using System.Collections.Generic;

namespace Fatec.Application.ViewModels
{
    public class VagaEstagioViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Descricao { get; set; }
        public EmpresaViewModel Empresa { get; set; }
        public string UrlImagem { get; set; }
        public DateTime DataHoraCadastro { get; set; } = DateService.PegaHoraBrasilia();
        public DateTime DataValidade { get; set; }
    }
}