using System;
using System.Linq.Expressions;
using DentistSite.Domain.Entities.Base;

namespace DentistSite.Bussines.Abstraction
{
    public interface IService<TEntity> : IQueryService<TEntity>
        where TEntity : EntityBase
    {
        TEntity GetById(int id, params Expression<Func<TEntity, object>>[] prefetches);

        TEntity GetByExpression(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] prefetches);

        void ExecuteByEntity(Expression<Func<TEntity, bool>> predicate, Action<TEntity> action,
            params Expression<Func<TEntity, object>>[] prefetches);

        void Save(TEntity entity, bool isNew = false);

         void Remove(TEntity entity);

    }
}