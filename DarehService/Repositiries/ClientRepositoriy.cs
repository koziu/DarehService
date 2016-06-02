using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DarehService.API.DAL;
using DarehService.API.Models;
using DarehService.API.Repositiries.Interfaces;

namespace DarehService.API.Repositiries
{
  public class ClientRepositoriy : ICrudRepository<UserModel>
  {
    private AuthContext _context;

    public ClientRepositoriy()
    {
      _context = new AuthContext();
    }
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<UserModel> GetAll()
    {
      return TestData.ClientTestData.Clients;
    }

    //public async Task<UserModel> GetById(string id)
    //{
    //  return await _context.UserModels.FindAsync(id);
    //}

    //public async Task<UserModel> Get(UserModel entity)
    //{
    //  return await _context.UserModels.FindAsync(entity);
    //}

    public Task<bool> Insert(UserModel entity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Update(UserModel entity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Delete(UserModel entity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> SaveChanges()
    {
      throw new NotImplementedException();
    }
  }
}