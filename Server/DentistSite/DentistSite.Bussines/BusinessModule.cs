using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistSite.Bussines.Abstraction;
using DentistSite.Bussines.Services;
using Ninject.Modules;

namespace DentistSite.Bussines
{
  public class BusinessModule : NinjectModule
  {
    public override void Load()
    {
      this.Bind(typeof(IService<>)).To(typeof(Service<>));
    }
  }
}
