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
    Task<IdentityResult> RegisterUser(UserModel client);
    Task<IdentityUser> FindUser(string userName, string password);    
    Client FindClient(string id);    
    Task<bool> AddRefreshToken(RefreshToken refreshToken);
    Task<bool> RemoveRefreshToken(string refreshTokenId);
    Task<bool> RemoveRefreshToken(RefreshToken refreshToken);
    Task<RefreshToken> FindRefreshToken(string refreshTokenId);
    List<RefreshToken> GetAllRefreshTokens();

  }
}
