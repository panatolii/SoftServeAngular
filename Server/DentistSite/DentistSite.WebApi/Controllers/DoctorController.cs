using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DentistSite.Bussines.Abstraction;
using DentistSite.Domain.Entities;
using DentistSite.WebBase.Controllers;
using Ninject;

namespace DentistSite.WebApi.Controllers
{
  [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "POST, PUT, DELETE, OPTIONS")]
  public class DoctorController : BaseApiController<Doctor>
  {
      
  }
}
