using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DentistSite.Domain.Entities.Base;

namespace DentistSite.Bussines.Abstraction
{
    public interface IQueryService<TEntity>
        where TEntity : EntityBase
    {
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, object>>[] prefetches = null,
            string sortExpression = null, int pageIndex = 0, int pageSize = int.MaxValue, bool useDefaultPredicates = true);
       

        IEnumerable<TOutputEntity> CustomList<TOutputEntity>(Func<TEntity, TOutputEntity> getOutputType, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, object>>[] prefetches = null);

        int ListCount(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[] prefetches = null);
      
    }
}
