using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

    public async Task<IdentityResult> RegisterUser(UserModel userModel)
    {
      var user = new IdentityUser
      {
        UserName = userModel.UserName
      };

      var result = await _userManager.CreateAsync(user, userModel.Password);

      return result;
    }

    public async Task<IdentityUser> FindUser(string userName, string password)
    {
      var user = await _userManager.FindAsync(userName, password);

      return user;
    }

    public async Task<IdentityUser> FindUserById(string id)
    {
      var user = await _userManager.FindByIdAsync(id);

      return user;
    }

    public async Task<bool> AddRefreshToken(RefreshToken refreshToken)
    {
      var existingRefreshToken = await _context.RefreshTokens.SingleOrDefaultAsync(r => r.Subject == refreshToken.Subject && r.ClientId == refreshToken.ClientId);
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
  }
}