using System;
using System.Collections.Generic;

namespace Fatec.Application.Interface
{
    public interface IAppServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int obj);
    }
}