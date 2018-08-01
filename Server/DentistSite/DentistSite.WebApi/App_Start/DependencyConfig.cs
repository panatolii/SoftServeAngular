using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using DentistSite.Base;

namespace DentistSite.WebApi.App_Start
{
  public class DependencyConfig
  {
    public static void RegisterDependency()
    {
      DependencyResolver.SetResolver(new NinjectDependencyResolver());
      GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(NinjectKernel.Current);
    }
  }
}