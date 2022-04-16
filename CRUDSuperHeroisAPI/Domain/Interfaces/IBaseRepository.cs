using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CRUDSuperHeroisAPI.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void AddRange(ICollection<TEntity> obj);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllWith(params Expression<Func<TEntity, object>>[] includes);
        void Update(TEntity obj);
        void Remove(int id);
        int SaveChanges();

        IQueryable<TEntity> GetParam(Expression<Func<TEntity, bool>> predicate);
    }
}
