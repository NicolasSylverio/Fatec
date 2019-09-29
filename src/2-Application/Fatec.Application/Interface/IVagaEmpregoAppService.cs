using Fatec.Application.ViewModels;
using System.Collections.Generic;
using Fatec.CrossCutting.Models.PaginacaoHelper;

namespace Fatec.Application.Interface
{
    public interface IVagaEmpregoAppService : IAppServiceBase<VagaEmpregoViewModel>
    {
        VagasFiltroViewModel<VagaEmpregoViewModel> GetAll(Paginacao paginacao);

        VagasFiltroViewModel<VagaEmpregoViewModel> GetAllByTituloTags(string titulo, int tags, Paginacao paginacao);
    }
}