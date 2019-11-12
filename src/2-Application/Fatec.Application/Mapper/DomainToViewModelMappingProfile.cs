using AutoMapper;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models;
using Fatec.CrossCutting.Models.Empresas;
using Fatec.CrossCutting.Models.Vagas;

namespace Fatec.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<VagaEstagio, VagaEstagioViewModel>();
            CreateMap<VagaEmprego, VagaEmpregoViewModel>();
            CreateMap<Tags, TagsViewModel>();
            CreateMap<Empresa, EmpresaViewModel>();
        }
    }
}