using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.PaginacaoHelper;

namespace Fatec.Application.Interface
{
    public interface IEmpresaAppService : IAppServiceBase<EmpresaViewModel>
    {
        PaginacaoViewModel<EmpresaViewModel> GetAll(Paginacao paginacao);
    }
}