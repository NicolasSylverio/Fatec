using System;
using System.Collections.Generic;
using Fatec.CrossCutting.Models.PaginacaoHelper;

namespace Fatec.DataBase.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int obj);
    }
}