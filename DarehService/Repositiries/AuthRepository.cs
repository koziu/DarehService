using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using DarehService.API.DAL;
using DarehService.API.Models;
using DarehService.API.Repositiries.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DarehService.API.Repositiries
{
  public class AuthRepository : IAuthRepository
  {
    private readonly AuthContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthRepository()
    {
      _context = new AuthContext();
       _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
    }

    public void Dispose()
    {
      _context.Dispose();
      _userManager.Dispose();
    }

    public async Task<IdentityResult> RegisterUser(UserModel client)
    {
      var user = new IdentityUser
      {
        UserName = client.UserName,
      };

      var result = await _userManager.CreateAsync(user, client.Password);

      return result;
    }

    public async Task<IdentityUser> FindUser(string userName, string password)
    {
      var user = await _userManager.FindAsync(userName, password);

      return user;
    }

    public Client FindClient(string clientId)
    {
      var client =  _context.Clients.Find(clientId);

      return client;
    }

    public async Task<bool> AddRefreshToken(RefreshToken refreshToken)
    {
      var existingRefreshToken =
        await
          _context.RefreshTokens.SingleOrDefaultAsync(
            r => r.Subject == refreshToken.Subject && r.ClientId == refreshToken.ClientId);
      if (existingRefreshToken != null)
      {
        var result = await RemoveRefreshToken(existingRefreshToken);
      }

      _context.RefreshTokens.Add(refreshToken);

      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveRefreshToken(string refreshTokenId)
    {
      var refreshToken = await _context.RefreshTokens.FindAsync(refreshTokenId);

      if (refreshToken != null)
      {
        _context.RefreshTokens.Remove(refreshToken);
        return await _context.SaveChangesAsync() > 0;
      }

      return false;
    }

    public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
    {
      _context.RefreshTokens.Remove(refreshToken);

      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
    {
      var refreshToken = await _context.RefreshTokens.FindAsync(refreshTokenId);

      return refreshToken;
    }

    public List<RefreshToken> GetAllRefreshTokens()
    {
      return _context.RefreshTokens.ToList();
    }

    public async Task<IdentityUser> FindAsync(UserLoginInfo loginInfo)
    {
      var user = await _userManager.FindAsync(loginInfo);

      return user;
    }

    public async Task<IdentityResult> CreateAsync(IdentityUser user)
    {
      var result = await _userManager.CreateAsync(user);

      return result;
    }

    public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
    {
      var result = await _userManager.AddLoginAsync(userId, login);

      return result;
    }
  }
}