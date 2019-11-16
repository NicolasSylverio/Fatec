using Fatec.CrossCutting.Helper;
using Fatec.CrossCutting.Models.Empresas;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.DataBase.Context;
using Fatec.DataBase.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace Fatec.DataBase.Repository
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(IntranetFatecContext context)
            : base(context)
        {
        }

        public override void Add(Empresa obj)
        {
            obj.DataCadastro = DataHelper.GetHoraBrasilia();

            base.Add(obj);
        }

        public override void Update(Empresa obj)
        {
            var objeto = Db.Set<Empresa>().Find(obj.Id);

            objeto.Nome = obj.Nome;
            objeto.Email = obj.Email;
            objeto.Telefone = obj.Telefone;
            objeto.UrlSite = obj.UrlSite;

            Db.Entry(objeto).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public ResultadoPaginacao<Empresa> GetAll(Paginacao paginacao)
        {
            var obj = DbSet.AsQueryable();

            var totalDeRegistros = obj.Count();

            var totalPorPagina = paginacao.TodosRegistros ? totalDeRegistros : paginacao.TotalPorPagina;

            var entity = obj.AsNoTracking()
                .OrderByDescending(x => x.DataCadastro)
                .Skip(paginacao.TotalPaginacao)
                .Take(totalPorPagina)
                .ToList();

            return new ResultadoPaginacao<Empresa>
            {
                Resultados = entity,
                Total = totalDeRegistros,
                Pagina = paginacao.Pagina,
                TotalPaginas = paginacao.TotalPaginacao,
                TotalPorPagina = totalPorPagina > 0 ? totalPorPagina : 1
            };
        }
    }
}