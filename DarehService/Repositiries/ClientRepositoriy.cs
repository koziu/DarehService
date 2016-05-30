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
  public class ClientRepositoriy : ICrudRepository<Client>
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

    public IEnumerable<Client> GetAll()
    {
      return TestData.ClientTestData.Clients;
    }

    public async Task<Client> GetById(string id)
    {
      return await _context.Clients.FindAsync(id);
    }

    public async Task<Client> Get(Client entity)
    {
      return await _context.Clients.FindAsync(entity);
    }

    public Task<bool> Insert(Client entity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Update(Client entity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Delete(Client entity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> SaveChanges()
    {
      throw new NotImplementedException();
    }
  }
}