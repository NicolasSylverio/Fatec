using AutoMapper;
using Fatec.Application.ViewModels;

namespace Fatec.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VagaEstagioViewModel, Domain.Models.Vagas.VagaEstagio>();
        }
    }
}