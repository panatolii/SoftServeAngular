using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistSite.Domain.Entities.Base;
using Microsoft.AspNet.Identity;

namespace DentistSite.Domain.Entities
{
  public class User:EntityBase, IUser<int>
  {
    public string UserName { get; set; }
    public string Password { get; set; }
  }
}
