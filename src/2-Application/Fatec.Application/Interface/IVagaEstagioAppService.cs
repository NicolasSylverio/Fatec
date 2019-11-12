using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.PaginacaoHelper;

namespace Fatec.Application.Interface
{
    public interface IVagaEstagioAppService : IAppServiceBase<VagaEstagioViewModel> 
    {
        VagasFiltroViewModel<VagaEstagioViewModel> GetAllByTituloTags(string titulo, int tags, Paginacao paginacao);
    }
}