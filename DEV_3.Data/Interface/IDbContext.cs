using System.Data.Entity;

namespace DEV_3.Data.Interface
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity:class;
        int SaveChanges();
        void Dispose();
    }
}
