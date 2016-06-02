using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using DarehService.API.Models;
using DarehService.API.Repositiries;
using DarehService.API.Repositiries.Interfaces;
using Ninject;

namespace DarehService.API.Config
{
  public static class NinjectConfig
  {
    public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
    {
      var kernel = new StandardKernel();
      kernel.Load(Assembly.GetExecutingAssembly());

      RegisterServices(kernel);

      return kernel;
    });

    private static void RegisterServices(KernelBase kernel)
    {
      kernel.Bind<IAuthRepository>().To<AuthRepository>();
      kernel.Bind<ICrudRepository<UserModel>>().To<ClientRepositoriy>();
    }

  }
}