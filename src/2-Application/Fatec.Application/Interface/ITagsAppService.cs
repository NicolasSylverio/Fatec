using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.PaginacaoHelper;

namespace Fatec.Application.Interface
{
    public interface ITagsAppService : IAppServiceBase<TagsViewModel>
    {
        PaginacaoViewModel<TagsViewModel> GetAll(Paginacao paginacao);
    }
}