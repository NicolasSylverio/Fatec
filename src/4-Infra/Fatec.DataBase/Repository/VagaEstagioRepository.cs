using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.CrossCutting.Models.Vagas;
using Fatec.DataBase.Context;
using Fatec.DataBase.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace Fatec.DataBase.Repository
{
    public class VagaEstagioRepository : RepositoryBase<VagaEstagio>, IVagaEstagioRepository
    {
        public VagaEstagioRepository(IntranetFatecContext context)
            : base(context)
        {
        }

        public override void Update(VagaEstagio obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public override void Add(VagaEstagio obj)
        {
            var tags = obj.TagsId;

            obj.Tags = Db
                .Tags
                .Where(x => tags.Contains(x.Id))
                .ToList();

            base.Add(obj);
        }

        public ResultadoPaginacao<VagaEstagio> GetAll(Paginacao paginacao)
        {
            var obj = DbSet.AsQueryable();

            var totalDeRegistros = obj.Count();

            var totalPorPagina = paginacao.TodosRegistros ? totalDeRegistros : paginacao.TotalPorPagina;

            var entity = obj.AsNoTracking()
                .OrderByDescending(x => x.DataHoraCadastro)
                .Skip(paginacao.TotalPaginacao)
                .Take(totalPorPagina)
                .ToList();

            return new ResultadoPaginacao<VagaEstagio>
            {
                Resultados = entity,
                Total = totalDeRegistros,
                Pagina = paginacao.Pagina,
                TotalPaginas = paginacao.TotalPaginacao,
                TotalPorPagina = totalPorPagina > 0 ? totalPorPagina : 1
            };
        }

        public ResultadoPaginacao<VagaEstagio> GetAllByTituloTags(string titulo, int tags, Paginacao paginacao)
        {
            var query = DbSet.Where(x => x.DataValidade < DateTime.Now);

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                query = query.Where(x => x.Titulo.ToLower().Contains(titulo));
            }

            if (tags != 0)
            {
                query = query.Where(x => x.Tags.Any(a => a.Id == tags));
            }

            var totalDeRegistros = query.Count();

            var totalPorPagina = paginacao.TodosRegistros ? totalDeRegistros : paginacao.TotalPorPagina;

            var entity = query.AsNoTracking()
                .OrderBy(x => x.Titulo)
                .Skip(paginacao.TotalPaginacao)
                .Take(totalPorPagina)
                .ToList();

            return new ResultadoPaginacao<VagaEstagio>
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