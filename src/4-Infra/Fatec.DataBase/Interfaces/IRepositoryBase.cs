using Fatec.CrossCutting.Models.PaginacaoHelper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Fatec.DataBase.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int obj);
        ResultadoPaginacao<TEntity> GetAll<TKey>(Paginacao paginacao, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> order);
    }
}