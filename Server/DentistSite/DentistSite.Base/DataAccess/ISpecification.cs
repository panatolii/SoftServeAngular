using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Farmtool.Base.DataAccess
{
    /// <summary>
    /// Defines behavior of the specification types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Determines whether specification conditions are fullfilled by given entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>
        /// <c>true</c> if given entity attributes satisfy given specification; otherwise, <c>false</c>
        /// </returns>
        bool IsSatisfiedBy(T entity);

        /// <summary>
        /// Gets the predicate
        /// </summary>
        /// <value>The predicate</value>
        Expression<Func<T, bool>> Predicate { get; }
    }
}
