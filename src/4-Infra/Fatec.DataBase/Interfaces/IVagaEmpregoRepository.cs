using Fatec.CrossCutting.Models.Vagas;
using System.Collections.Generic;

namespace Fatec.DataBase.Interfaces
{
    public interface IVagaEmpregoRepository : IRepositoryBase<VagaEmprego>
    {
        IEnumerable<VagaEmprego> GetAllByTituloTags(string titulo, IEnumerable<int> tags);
    }
}