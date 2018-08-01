using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistSite.DataAccess.Abstraction;
using Ninject.Modules;

namespace DentistSite.DataAccess
{
  public class DataAcessModule : NinjectModule
  {
    public override void Load()
    {
      Bind(typeof(IRepository<>)).To(typeof(Repository<>));
    }
  }
}
