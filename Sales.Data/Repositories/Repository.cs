using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sales.Common.Utilities;
using Sales.Data.Contracts;

namespace Sales.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly SalesDbContext DbContext;
        public DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public Repository(SalesDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); 
        }


        #region Sync Methods
        public virtual void Add(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Add(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Update(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }
        public virtual void Delete(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Remove(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }
        #endregion

    }
}
