using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwoMinds.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
