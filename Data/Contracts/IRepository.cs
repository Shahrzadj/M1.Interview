﻿using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Personnel.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        TEntity GetById(params object[] ids);
        void Add(TEntity entity, bool saveNow = true);
        void Delete(TEntity entity, bool saveNow = true);
        void Update(TEntity entity, bool saveNow = true);
    }
}
