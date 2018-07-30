using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using DentistSite.Base;
using DentistSite.DataAccess;
using DentistSite.DataAccess.EntityFramework;

namespace DentistSite.WebBase
{
  public class DentistDbContextFactory : DbContextProviderFactory
  {

    public static readonly string ConnectionString = WebConfigurationManager.ConnectionStrings["DentistDb"].ConnectionString;

    public override DbContext Context
    {
      get { return (HttpContext.Current.With(ct => ct.Items["Context"] as DentistDbContext) ?? (Context = new DentistDbContext(ConnectionString))); }
      protected set { HttpContext.Current.DoVoid(ct => ct.Items["Context"] = value); }
    }

    public override void ReCreate()
    {
      Context = null;
    }


  }
}
