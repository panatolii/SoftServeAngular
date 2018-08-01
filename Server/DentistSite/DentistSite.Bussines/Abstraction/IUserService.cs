using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DentistSite.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace DentistSite.Bussines.Abstraction
{
  public interface IUserService:IDisposable
  {
    Task<User> FindAsync(string userName, string password);
    Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType);
  }

  class UserService : UserManager<User, int>,  IUserService
  {
    public UserService(IUserStore<User, int> store) : base(store)
    {
    }

    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType)
    {
      var identity = await base.CreateIdentityAsync(user, authenticationType);

      //this._userStore.RemoveInvalidAccessTokens();


      return identity;
    }
  }
}
