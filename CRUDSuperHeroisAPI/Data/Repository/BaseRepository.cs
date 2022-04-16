using CRUDSuperHeroisAPI.Data;
using CRUDSuperHeroisAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CRUDSuperHeroisAPI.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly SuperHeroisContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(SuperHeroisContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void AddRange(ICollection<TEntity> obj)
        {
            DbSet.AddRange(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> GetAllWith(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = null;

            foreach (var include in includes)
            {
                query = DbSet.Include(include);
            }

            return query ?? DbSet;
        }

        public IQueryable<TEntity> GetParam(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
