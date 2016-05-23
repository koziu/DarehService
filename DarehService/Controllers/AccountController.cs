using System.Threading.Tasks;
using System.Web.Http;
using DarehService.API.Models;
using DarehService.API.Repositiries;
using DarehService.API.Repositiries.Interfaces;
using Microsoft.AspNet.Identity;

namespace DarehService.API.Controllers
{
  [RoutePrefix("api/Account")]
  public class AccountController : ApiController
  {
    private readonly IAuthRepository _repository;

    public AccountController(IAuthRepository repository)
    {
      _repository = repository;
    }

    // POST api/Account/Register
    [AllowAnonymous]
    [Route("Register")]
    public async Task<IHttpActionResult> Register(UserModel userModel)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IdentityResult result = await _repository.RegisterUser(userModel);

      var errorResult = GetErrorResult(result);

      if (errorResult != null)
      {
        return errorResult;
      }

      return Ok();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _repository.Dispose();
      }

      base.Dispose(disposing);
    }

    private IHttpActionResult GetErrorResult(IdentityResult result)
    {
      if (result == null)
      {
        return InternalServerError();
      }

      if (!result.Succeeded)
      {
        if (result.Errors != null)
        {
          foreach (string error in result.Errors)
          {
            ModelState.AddModelError("", error);
          }
        }

        if (ModelState.IsValid)
        {
          // No ModelState errors are available to send, so just return an empty BadRequest.
          return BadRequest();
        }

        return BadRequest(ModelState);
      }

      return null;
    }
  }
}