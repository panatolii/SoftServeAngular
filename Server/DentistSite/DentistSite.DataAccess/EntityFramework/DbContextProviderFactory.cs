using System.Data.Entity;

namespace DentistSite.DataAccess.EntityFramework
{
    public abstract class DbContextProviderFactory
    {
        public abstract DbContext Context { get; protected set; }
        public abstract void ReCreate();
    }
}
