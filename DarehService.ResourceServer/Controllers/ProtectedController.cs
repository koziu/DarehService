using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace DarehService.ResourceServer.Controllers
{
  [Authorize]
  [RoutePrefix("api/protected")]
  public class ProtectedController : ApiController
  {
    [Route("")]
    public IEnumerable<object> Get()
    {
      var identity = User.Identity as ClaimsIdentity;

      if (identity != null)
        return identity.Claims.Select(c => new
        {
          Type = c.Type,
          Value = c.Value
        });
      return null;
    }
  }
}