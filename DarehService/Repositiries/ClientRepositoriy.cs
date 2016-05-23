using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DarehService.API.Models;
using DarehService.API.Repositiries.Interfaces;

namespace DarehService.API.Repositiries
{
  public class ClientRepositoriy : ICrudRepository<Client>
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Client> GetAll()
    {
      return TestData.ClientTestData.Clients;
    }

    public Client GetById(Guid id)
    {
      throw new NotImplementedException();
    }

    public Client Get(Client entity)
    {
      throw new NotImplementedException();
    }

    public void Insert(Client entity)
    {
      throw new NotImplementedException();
    }

    public void Update(Client entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(Client entity)
    {
      throw new NotImplementedException();
    }

    public void SaveChanges()
    {
      throw new NotImplementedException();
    }
  }
}