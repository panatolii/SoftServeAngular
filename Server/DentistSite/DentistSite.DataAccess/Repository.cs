using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using DentistSite.Base.Helpers;
using DentistSite.DataAccess.Abstraction;
using DentistSite.DataAccess.EntityFramework;
using DentistSite.Domain.Entities.Base;
using Farmtool.Base.DataAccess;

namespace DentistSite.DataAccess
{
  /// <summary>
  /// Defines abstract repository type and implements behaviours of <see cref="IRepository{T}">IRepository</see>: 
  /// <list type="string">
  /// <listheader>Behaviors:</listheader>
  /// <item>
  /// Adding and removing of Repository collection members  
  /// </item>
  /// <item>
  /// Persisting transient repository entities
  /// </item>
  /// <item>
  /// Removing repository entities from Id Map 'cache'
  /// </item>
  /// <item>
  /// Two major quering mechanism:
  /// <para>
  /// Interface behavior contract inherits behavior of the <see cref="T:System.Linq.IQueryable" /> interface which allows usage of Linq statements over repository content
  /// </para>
  /// <para>
  /// Another important interface behavior is that defines requirement that all of the implementor classes have enable querying by a class implementing <see cref="T:TL.DataAccess.Abstraction.ISpecification`1" /> interface
  /// which should be prefered way of how to perform complex and reusable querying on repository contents 
  /// </para>
  /// </item>
  /// </list>
  /// </summary>
  /// <typeparam name="T">Entity which is domain aggregate root</typeparam>
  /// <remarks>
  /// <seealso cref="http://martinfowler.com/eaaCatalog/repository.html">Repository pattern</seealso>
  /// <seealso cref="http://en.wikipedia.org/wiki/Specification_pattern">Specification pattern</seealso>
  /// <seealso cref="http://dddstepbystep.com/wikis/ddd/aggregate-root.aspx">Aggregate Root pattern</seealso>
  /// <seealso cref="http://martinfowler.com/eaaCatalog/identityMap.html">Id Map pattern</seealso>
  /// </remarks>
  public class Repository<T> : IRepository<T>, IDisposable
      where T : EntityBase
  {
    //public Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    private readonly DbContextProviderFactory _factory;
    private DbContext _context;
    private Expression<Func<T, object>>[] Prefetches { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:EarthIntegrate.CmsSystem.DataAccess.Repository`1" /> class
    /// </summary>
    public Repository(DbContextProviderFactory factory)
    {
      _factory = factory;
      _context = factory.Context;
    }

    /// <summary>
    /// Set prefetches for repository(example: lazy load connected objects)
    /// </summary>
    /// <param name="prefetches">Array of expressions</param>
    public void SetPrefetches(params Expression<Func<T, object>>[] prefetches)
    {
      Prefetches = prefetches;
    }

    /// <summary>
    /// Saves the specified entity to repository
    /// </summary>
    /// <param name="entity">The entity</param>
    public void Add(T entity)
    {
      /* // TODO: add input parameters check
       if (entity.Id == default(int))
       {
           _context.Set<T>().Add(entity);
       }
       else
       {
           _context.Set<T>().Attach(entity);
           _context.Entry(entity).State = EntityState.Modified;

       }
*/


      var entry = _context.Entry(entity);
      if (!entity.Id.Equals(default(int)) && entry.State == EntityState.Detached)
      {
        var set = this._context.Set<T>();
        T attachedEntity = set.Local.SingleOrDefault(x => x.Id.Equals(entity.Id));

        if (attachedEntity != null)
        {
          var attachedEntry = _context.Entry(attachedEntity);
          attachedEntry.CurrentValues.SetValues(entity);

        }
        else
        {
          entry.State = EntityState.Modified; // This should attach entity
        }
      }
      else
      {
        this._context.Set<T>().Attach(entity);
        if (entity.Id.Equals(default(int)))
        {
          this._context.Entry(entity).State = EntityState.Added;
        }
        else
        {
          this._context.Entry(entity).State = EntityState.Modified;
        }
      }




    }

    /// <summary>
    /// Commits to DB repository
    /// </summary>
    public void Commit()
    {
      ExceptionHelper.HandleError(() => _context.SaveChanges(), RefreshContext);
    }

    /// <summary>
    /// Save Changes but don't discard yet
    /// </summary>
    public void SaveDraft()
    {
      /*ExceptionHelper.HandleError(
          () =>
          {
              var objectContext = (_context as IObjectContextAdapter).ObjectContext;
              objectContext.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
          }, RefreshContext);*/
      throw new NotImplementedException();
    }

    /// <summary>
    /// Accept all changes
    /// </summary>
    public void AcceptAllChanges()
    {
      ExceptionHelper.HandleError(
          () =>
          {
            var objectContext = (_context as IObjectContextAdapter).ObjectContext;
            objectContext.AcceptAllChanges();
          });
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
      ExceptionHelper.HandleError(() => _context.SaveChanges());
      //_context.Dispose();

    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
    /// </returns>
    /// <filterpriority>1</filterpriority>
    public IEnumerator<T> GetEnumerator()
    {
      return RepositoryQuery.GetEnumerator();
    }

    /// <summary>
    /// Queries the repository using given specification.
    /// </summary>
    /// <param name="specification">The specification defining query criterias</param>
    /// <returns>
    /// Collection of entities fullfilling specification criterias
    /// </returns>
    public IQueryable<T> Query(ISpecification<T> specification)
    {
      return specification == null || specification.Predicate == null
          ? RepositoryQuery
          : RepositoryQuery.Where(specification.Predicate);
    }

    /// <summary>
    /// Removes the specified entity from repository
    /// </summary>
    /// <param name="entity">The entity.</param>
    public void Remove(T entity)
    {
      // TODO: add input parameters check
      _context.Set<T>().Attach(entity);
      _context.Set<T>().Remove(entity);
    }

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
    /// </returns>
    /// <filterpriority>2</filterpriority>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return RepositoryQuery.GetEnumerator();
    }

    /// <summary>
    /// Gets the type of the element(s) that are returned when the expression tree associated with this instance of <see cref="T:System.Linq.IQueryable" /> is executed.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Type" /> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.
    /// </returns>
    public Type ElementType
    {
      get { return RepositoryQuery.ElementType; }
    }

    /// <summary>
    /// Gets the expression tree that is associated with the instance of <see cref="T:System.Linq.IQueryable" />.
    /// </summary>
    /// <returns>
    /// The <see cref="T:System.Linq.Preferences.Expression" /> that is associated with this instance of <see cref="T:System.Linq.IQueryable" />.
    /// </returns>
    public System.Linq.Expressions.Expression Expression
    {
      get { return RepositoryQuery.Expression; }
    }

    /// <summary>
    /// Gets the query provider that is associated with this data source.
    /// </summary>
    /// <returns>
    /// The <see cref="T:System.Linq.IQueryProvider" /> that is associated with this data source.
    /// </returns>
    public IQueryProvider Provider
    {
      get { return RepositoryQuery.Provider; }
    }

    /// <summary>
    /// Gets the repository query.
    /// </summary>
    /// <value>The repository query.</value>
    private IQueryable<T> RepositoryQuery
    {
      get
      {
        IQueryable<T> dbSet = _context.Set<T>().AsNoTracking();

        // set prefences for eager loading
        return Prefetches == null ? dbSet : Prefetches.Aggregate(dbSet, (current, expression) => current.Include(expression));
      }
    }

    public void SetState<T>(T instance, int state)
        where T : EntityBase
    {
      ExceptionHelper.HandleError(() =>
      {
        _context.Entry(instance).State =
            (EntityState)Enum.ToObject(typeof(EntityState), state);
      }, true);
    }

    public void ExtractSql<T1>(IQueryable<T1> query, out string sql, out ObjectParameterCollection parameters)
    {
      var objectContext = ((IObjectContextAdapter)this._context).ObjectContext;
      var iqueryable = objectContext.CreateObjectSet<T>() as IQueryable;
      var provider = iqueryable.Provider;
      var res = provider.CreateQuery(query.Expression) as ObjectQuery;
      sql = res.ToTraceString();
      parameters = res.Parameters;
    }

    private void RefreshContext()
    {
      //ExceptionHelper.HandleError(() => _context.Dispose(), true);
      var context = ((IObjectContextAdapter)this._context).ObjectContext;
      var refreshableObjects = this._context.ChangeTracker.Entries().Where(e => e.State == (EntityState.Unchanged | EntityState.Deleted | EntityState.Modified)).Select(c => c.Entity).ToList();
      context.Refresh(RefreshMode.StoreWins, refreshableObjects);
    }
  }
}
