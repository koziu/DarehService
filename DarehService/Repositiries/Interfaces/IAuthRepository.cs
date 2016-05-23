using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarehService.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DarehService.API.Repositiries.Interfaces
{
  public interface IAuthRepository : IDisposable
  {
    Task<IdentityResult> RegisterUser(UserModel userModel);
    Task<IdentityUser> FindUser(string userName, string password);
    Task<IdentityUser> FindUserById(string id);
  }
}
