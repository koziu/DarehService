using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using DarehService.API.Models;
using DarehService.API.Repositiries.Interfaces;
using DarehService.API.TestData;

namespace DarehService.API.Controllers
{
  [EnableCors("*", "*", "*", SupportsCredentials = true)]
  public class ClientController : ApiController
  {
    private readonly ICrudRepository<Client> _repository;

    public ClientController(ICrudRepository<Client> repository)
    {
      _repository = repository;
    }
    // GET: api/Client
    public IEnumerable<Client> Get()
    {
      return _repository.GetAll();
    }

    // GET: api/Client/5
    public IHttpActionResult Get(string id)
    {
      var client = ClientTestData.Clients.FirstOrDefault(x => x.Id == id);
      if (client == null)
      {
        return NotFound();
      }
      return Ok(client);
    }

    // POST: api/Client
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Client/5
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/Client/5
    public void Delete(string id)
    {
      ClientTestData.Clients.Remove(ClientTestData.Clients.FirstOrDefault(x => x.Id == id));
    }
  }
}