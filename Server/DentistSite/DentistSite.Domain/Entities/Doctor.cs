using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistSite.Domain.Entities.Base;

namespace DentistSite.Domain.Entities
{
  public class Doctor:EntityBase
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public byte [] Image { get; set; }

    public string Description { get; set; }
  }
}
