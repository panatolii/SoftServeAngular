using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DentistSite.Base
{
  public static class NinjectKernel
  {
    private static IKernel kernel;

    public static IKernel Current
    {
      get { return kernel ?? (kernel = new StandardKernel()); }
    }

    public static void Reset()
    {
      kernel = new StandardKernel();
    }
  }
}
