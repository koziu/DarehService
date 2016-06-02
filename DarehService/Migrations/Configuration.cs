using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DarehService.API.DAL;
using DarehService.API.Helpers;
using DarehService.API.Models;

namespace DarehService.API.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<AuthContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(AuthContext context)
    {
      if (context.Clients.Any())
      {
        return;
      }

      context.Clients.AddRange(BuildClientList());
      context.SaveChanges();
    }

    private IEnumerable<Client> BuildClientList()
    {
      var clientsList = new List<Client>
      {
        new Client
        {
          Id = "ngAuthApp",
          Secret = MainHelper.GetHash("qwerty@123"),
          Name = "AngularJS front-end Application",
          ApplicationType = Models.Enums.ApplicationTypes.JavaScript,
          Active = true,
          RefreshTokenLifeTime = 7200,
          AllowedOrigin = "http://localhost:53988/"
        },
        new Client
        {
          Id = "consoleApp",
          Secret = MainHelper.GetHash("123@qwerty"),
          Name = "Console Application",
          ApplicationType = Models.Enums.ApplicationTypes.NativeConfidential,
          Active = true,
          RefreshTokenLifeTime = 14400,
          AllowedOrigin = "*"
        }
      };

      return clientsList;
    }
  }
}