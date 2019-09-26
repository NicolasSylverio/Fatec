using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.CrossCutting.Models.Vagas;
using Fatec.DataBase.Context;
using Fatec.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Fatec.DataBase.Repository
{
    public class VagaEmpregoRepository : RepositoryBase<VagaEmprego>, IVagaEmpregoRepository
    {
        public VagaEmpregoRepository(IntranetFatecContext context) : base(context)
        {
        }

        public override void Add(VagaEmprego obj)
        {
            var tags = obj.TagsId;

            obj.Tags = Db
                .Tags
                .Where(x => tags.Contains(x.Id))
                .ToList();

            base.Add(obj);
        }

        public virtual ResultadoPaginacao<VagaEmprego> GetAll(Paginacao paginacao)
        {
            var obj = DbSet.AsQueryable();

            var totalDeRegistros = obj.Count();

            var totalPorPagina = paginacao.TodosRegistros ? totalDeRegistros : paginacao.TotalPorPagina;

            var entity = obj.AsNoTracking()
                .OrderByDescending(x => x.DataHoraCadastro)
                .Skip(paginacao.TotalPaginacao)
                .Take(totalPorPagina)
                .ToList();

            return new ResultadoPaginacao<VagaEmprego>
            {
                Resultados = entity,
                Total = totalDeRegistros,
                Pagina = paginacao.Pagina,
                TotalPaginas = paginacao.TotalPaginacao,
                TotalPorPagina = totalPorPagina > 0 ? totalPorPagina : 1
            };
        }

        public ResultadoPaginacao<VagaEmprego> GetAllByTituloTags(string titulo, IEnumerable<int> tags, Paginacao paginacao)
        {
            var query = DbSet.Where(x => x.DataValidade < DateTime.Now);

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                query = query.Where(x => x.Titulo.ToLower().Contains(titulo));
            }

            if (tags != null && !tags.Any())
            {
                query = query.Where(x => x.Tags.Any(a => tags.Contains(a.Id)));
            }

            var totalDeRegistros = query.Count();

            var totalPorPagina = paginacao.TodosRegistros ? totalDeRegistros : paginacao.TotalPorPagina;

            var entity = query.AsNoTracking()
                .OrderBy(x => x.Titulo)
                .Skip(paginacao.TotalPaginacao)
                .Take(totalPorPagina)
                .ToList();

            return new ResultadoPaginacao<VagaEmprego>
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