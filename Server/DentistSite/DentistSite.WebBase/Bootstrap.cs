using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistSite.Base;
using DentistSite.Bussines;
using DentistSite.DataAccess;
using NLog;

namespace DentistSite.WebBase
{
  public static class Bootstrap
  {
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public static void LoadModules()
    {
      Logger.Info("Ninject Modules loading...");

      try
      {
        if (!NinjectKernel.Current.HasModule(typeof(DataAcessModule).FullName))
          NinjectKernel.Current.Load(new[] { new DataAcessModule() });
        if (!NinjectKernel.Current.HasModule(typeof(BusinessModule).FullName))
          NinjectKernel.Current.Load(new[] { new BusinessModule() });
        if (!NinjectKernel.Current.HasModule(typeof(WebModule).FullName))
          NinjectKernel.Current.Load(new[] { new WebModule() });
      }
      catch (Exception e)
      {
        Logger.Error(e, "Error when loading Ninject Modules.");
        throw;
      }

      Logger.Info("Ninject Modules loaded.");
    }


  }
}
