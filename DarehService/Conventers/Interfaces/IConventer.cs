namespace DarehService.API.Conventers.Interfaces
{
  public interface IConverter<in TSource, out TDestination>
  {
    TDestination Convert(TSource source);
  }
}