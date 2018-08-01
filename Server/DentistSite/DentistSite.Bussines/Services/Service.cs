using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using DentistSite.Base;
using DentistSite.Bussines.Abstraction;
using DentistSite.DataAccess.Abstraction;
using DentistSite.Domain.Entities.Base;
using Ninject;
using NLog;

namespace DentistSite.Bussines.Services
{
    public class Service<TEntity> : IService<TEntity>
       where TEntity : EntityBase
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #region Implementation of IService<TEntity>

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[] prefetches = null, string sortExpression = null, int pageIndex = 0, int pageSize = int.MaxValue, bool useDefaultPredicates = true)
        {
            return List<TEntity>(predicate, prefetches, sortExpression, pageIndex, pageSize);
        }

        public virtual IEnumerable<TOutputEntity> CustomList<TOutputEntity>(Func<TEntity, TOutputEntity> getOutputType, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, object>>[] prefetches = null)
        {
            if (getOutputType == null)
                throw new ArgumentNullException();

            using (var repository = GetRepository<TEntity>())
            {
                repository.SetPrefetches(prefetches);
                var query = repository.Query(null);

                if (predicate != null)
                    query = query.Where(predicate);

                return query.Select(getOutputType).ToList();
            }
        }

        public virtual int ListCount(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[] prefetches = null)
        {
            return ListCount<TEntity>(predicate, prefetches);
        }

        public virtual TEntity GetById(int id, params Expression<Func<TEntity, object>>[] prefetches)
        {
            using (var repository = GetRepository<TEntity>())
            {
                repository.SetPrefetches(prefetches);
                var entity = repository.FirstOrDefault(c => c.Id == id);

                return entity;
            }
        }

        public virtual TEntity GetByExpression(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] prefetches)
        {
            using (var repository = GetRepository<TEntity>())
            {
                repository.SetPrefetches(prefetches);
                return repository.FirstOrDefault(predicate);
            }
        }

        public virtual void ExecuteByEntity(Expression<Func<TEntity, bool>> predicate, Action<TEntity> action, params Expression<Func<TEntity, object>>[] prefetches)
        {
            using (var repository = GetRepository<TEntity>())
            {
                repository.SetPrefetches(prefetches);

                var items = repository.Where(predicate).ToList();
                items.ForEach(item =>
                {
                    action(item);
                    repository.Add(item);
                });
            }
        }

        public virtual void Save(TEntity entity, bool isNew)
        {
            Logger.Info("Saving entity {0}", entity.GetType());

            using (var repository = GetRepository<TEntity>())
            {
                repository.Add(entity);
            }

            Logger.Info("Saving entity {0} successfully", entity.GetType());
        }

        public void Remove(TEntity entity)
        {
            using (var repository = GetRepository<TEntity>())
            {
                repository.Remove(entity);
            }
        }

        #endregion

        protected static IRepository<TEntityType> GetRepository<TEntityType>()
            where TEntityType : EntityBase
        {
            return NinjectKernel.Current.Get<IRepository<TEntityType>>();
        }

        protected IEnumerable<TEntityType> List<TEntityType>(Expression<Func<TEntityType, bool>> predicate, Expression<Func<TEntityType, object>>[] prefetches = null, string sortExpression = null, int pageIndex = 0, int pageSize = int.MaxValue, bool useDefaultPredicates = true)
            where TEntityType : EntityBase
        {
            using (var repository = GetRepository<TEntityType>())
            {
                repository.SetPrefetches(prefetches);
                var query = repository.Query(null);

                if (predicate != null)
                    query = query.Where(predicate);

                query = query.AsQueryable();
                var orderedQuery = string.IsNullOrWhiteSpace(sortExpression)
                                   ? query.OrderBy(c => c.Id)
                                   : query.OrderBy(sortExpression);

                return orderedQuery.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
        }

        protected TEntityType GetObjectById<TEntityType>(Expression<Func<TEntityType, bool>> getExpression, params Expression<Func<TEntityType, object>>[] prefetches)
            where TEntityType : EntityBase
        {
            using (var repository = GetRepository<TEntityType>())
            {
                repository.SetPrefetches(prefetches);

                return repository.FirstOrDefault(getExpression);
            }
        }

        public static int ListCount<TEntityType>(Expression<Func<TEntityType, bool>> predicate, Expression<Func<TEntityType, object>>[] prefetches = null)
            where TEntityType : EntityBase
        {
            using (var repository = GetRepository<TEntityType>())
            {
                repository.SetPrefetches(prefetches);
                var query = repository.Query(null);

                if (predicate != null)
                    query = query.Where(predicate);

                return query.Count();
            }
        }

        protected void SaveObject<TObject>(TObject obj, Action<TObject, TObject> set)
           where TObject : EntityBase, new()
        {
            //create instance
            var newObj = new TObject { Id = obj.Id };
            set(obj, newObj);

            using (var repository = GetRepository<TObject>())
                repository.Add(newObj);

            obj.Id = newObj.Id;
        }
    }
}