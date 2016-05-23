using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarehService.MVC.Conventers.Interfaces
{
  public interface IConverter<in TSource, out TDestination>
  {
    TDestination Convert(TSource source);
  }
}