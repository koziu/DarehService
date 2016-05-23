using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DarehService.API.Models.Enums
{
  [JsonConverter(typeof(StringEnumConverter))]
  public enum OrderStatus
  {
    
  }
}