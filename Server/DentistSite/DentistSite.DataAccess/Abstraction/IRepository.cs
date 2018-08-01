using System;
using System.Linq;
using System.Linq.Expressions;
using DentistSite.Domain.Entities.Base;
using Farmtool.Base.DataAccess;

namespace DentistSite.DataAccess.Abstraction
{
  /// <summary>
  /// Defines generic behaviors of base repository type: 
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
  /// <typeparam name="T">Entity which is domain aggregate root </typeparam>
  /// <remarks>
  /// <seealso  cref="http://martinfowler.com/eaaCatalog/repository.html">Repository pattern</seealso>
  /// <seealso cref="http://en.wikipedia.org/wiki/Specification_pattern">Specification pattern</seealso>
  /// <seealso cref="http://dddstepbystep.com/wikis/ddd/aggregate-root.aspx">Aggregate Root pattern</seealso>
  /// <seealso cref="http://martinfowler.com/eaaCatalog/identityMap.html">Id Map pattern</seealso>
  /// </remarks>
  public interface IRepository<T> : IQueryable<T>, IDisposable
  {
    /// <summary>
    /// Saves the specified entity to repository
    /// </summary>
    /// <param name="entity">The entity</param>
    void Add(T entity);

    /// <summary>
    /// Commits to DB repository
    /// </summary>
    void Commit();

    /// <summary>
    /// Save Changes but don't discard yet
    /// </summary>
    void SaveDraft();

    /// <summary>
    /// Accept all changes
    /// </summary>
    void AcceptAllChanges();

    /// <summary>
    /// Queries the repository using given specification.
    /// </summary>
    /// <param name="specification">The specification defining query criterias</param>
    /// <returns>Collection of entities fullfilling specification criterias</returns>
    IQueryable<T> Query(ISpecification<T> specification);
    /// <summary>
    /// Removes the specified entity from repository
    /// </summary>
    /// <param name="entity">The entity</param>
    void Remove(T entity);

    /// <summary>
    /// Set prefetches for repository(example: lazy load connected objects)
    /// </summary>
    /// <param name="prefetches">Array of expressions</param>
    void SetPrefetches(params Expression<Func<T, object>>[] prefetches);

    void SetState<T>(T instance, int state)
        where T : EntityBase;
  }
}
