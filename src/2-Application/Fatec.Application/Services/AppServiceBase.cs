using Fatec.Application.Interface;
using Fatec.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Fatec.Application.Services
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _entity;

        public AppServiceBase(IRepositoryBase<TEntity> entity)
        {
            _entity = entity;
        }

        public void Add(TEntity obj)
        {
            _entity.Add(obj);
        }

        public void Dispose()
        {
            _entity.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entity.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _entity.GetById(id);
        }

        public void Remove(int obj)
        {
            _entity.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _entity.Update(obj);
        }
    }
}