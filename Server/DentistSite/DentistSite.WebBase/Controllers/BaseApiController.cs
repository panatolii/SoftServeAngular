using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DentistSite.Bussines.Abstraction;
using DentistSite.Domain.Entities.Base;
using Ninject;

namespace DentistSite.WebBase.Controllers
{
  [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "POST, PUT, DELETE, OPTIONS")]
  public class BaseApiController<TEntity>: ApiController where TEntity : EntityBase
  {
    [Inject]
    public IService<TEntity> Service { get; set; }

    [HttpGet]
    public TEntity[] Get()
    {
      var entities = Service.List().ToArray();
      return entities;
    }
  }

  [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "POST, PUT, DELETE, OPTIONS")]
  public class BaseEditApiController<TEntity> : ApiController where TEntity : EntityBase
  {
    public IService<TEntity> Service { get; set; }

    [HttpGet]
    public TEntity[] Get()
    {
      var entities = Service.List().ToArray();
      return entities;
    }

    // POST api/values
    public void Post([FromBody]TEntity entity)
    {
      Service.Save(entity);
    }

    // PUT api/values/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    public void Delete(int id)
    {
      var entity = Service.GetById(id);
      Service.Remove(entity);
    }
  }
}
