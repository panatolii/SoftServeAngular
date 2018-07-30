using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentistSite.Bussines.Abstraction;
using DentistSite.Domain.Entities;
using Ninject;

namespace DentistSite.WebApi.Controllers
{
  public class HomeController : Controller
  {
   
    public ActionResult Index()
    {
     

      return View();
    }
  }
}
