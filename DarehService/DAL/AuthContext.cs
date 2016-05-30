using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DarehService.API.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DarehService.API.DAL
{
  public class AuthContext : IdentityDbContext<IdentityUser>
  {
    public AuthContext() : base("AuthContext")
    {
      
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
  }
}