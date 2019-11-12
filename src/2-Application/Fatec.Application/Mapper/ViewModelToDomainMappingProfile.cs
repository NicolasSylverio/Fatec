using AutoMapper;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models;
using Fatec.CrossCutting.Models.Empresas;
using Fatec.CrossCutting.Models.Vagas;

namespace Fatec.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VagaEstagioViewModel, VagaEstagio>();
            CreateMap<VagaEmpregoViewModel, VagaEmprego>();
            CreateMap<EmpresaViewModel, Empresa>();
            CreateMap<TagsViewModel, Tags>();
        }
    }
}