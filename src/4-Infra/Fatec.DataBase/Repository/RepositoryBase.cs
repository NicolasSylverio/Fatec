using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.DataBase.Context;
using Fatec.DataBase.Interfaces;

namespace Fatec.DataBase.Repository
{

    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IntranetFatecContext Db;

        public RepositoryBase(IntranetFatecContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual void Remove(int id)
        {
            var obj = Db.Set<TEntity>().Find(id);
            Db.Entry(obj).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public ResultadoPaginacao<TEntity> GetAll<TKey>(Paginacao paginacao, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> order)
        {
            var obj = DbSet.AsQueryable();

            var totalDeRegistros = obj.Count();

            var totalPorPagina = paginacao.TodosRegistros ? totalDeRegistros : paginacao.TotalPorPagina;

            var entity = obj.AsNoTracking()
                .Where(predicate)
                .OrderByDescending(order)
                .Skip(paginacao.TotalPaginacao)
                .Take(totalPorPagina)
                .ToList();

            return new ResultadoPaginacao<TEntity>
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