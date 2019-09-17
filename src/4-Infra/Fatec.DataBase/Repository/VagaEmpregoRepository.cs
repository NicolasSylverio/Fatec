using Fatec.DataBase.Context;
using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Vagas;

namespace Fatec.DataBase.Repository
{
    public class VagaEmpregoRepository : RepositoryBase<VagaEmprego>, IVagaEmpregoRepository
    {
        public VagaEmpregoRepository(IntranetFatecContext context) : base(context)
        {
        }
    }
}