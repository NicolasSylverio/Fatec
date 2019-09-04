using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Fatec.Infra.DataBase.Context
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
