using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistSite.DataAccess;
using DentistSite.DataAccess.EntityFramework;
using Ninject.Modules;

namespace DentistSite.WebBase
{
  public class WebModule : NinjectModule
  {
    public override void Load()
    {
      Bind<DbContextProviderFactory>().To<DentistDbContextFactory>();

    }
  }
}
