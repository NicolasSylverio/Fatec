using Fatec.Application.ViewModels;
using System.Collections.Generic;

namespace Fatec.Application.Interface
{
    public interface IVagaEmpregoAppService : IAppServiceBase<VagaEmpregoViewModel>
    {
        IEnumerable<VagaEmpregoViewModel> GetAllByTituloTags(string titulo, IEnumerable<int> tags);
    }
}