using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.CrossCutting.Models.Vagas;

namespace Fatec.DataBase.Interfaces
{
    public interface IVagaEstagioRepository : IRepositoryBase<VagaEstagio>
    {
        ResultadoPaginacao<VagaEstagio> GetAll(Paginacao paginacao);

        ResultadoPaginacao<VagaEstagio> GetAllByTituloTags(string titulo, int tags, Paginacao paginacao);
    }
}