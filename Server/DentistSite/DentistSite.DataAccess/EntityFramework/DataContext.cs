using System.Data.Common;
using System.Data.Entity;

namespace DentistSite.DataAccess.EntityFramework
{
    public class DataContext: DbContext
    {
        protected virtual string DefaultSchema { get { return null; } }

        protected DataContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        protected DataContext(DbConnection connection) : base(connection, true) { }
        
    }
}