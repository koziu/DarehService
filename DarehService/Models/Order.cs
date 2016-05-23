using System;
using System.Collections.Generic;
using DarehService.API.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DarehService.API.Models
{
  public class Order
  {
    public Guid Id { get; set; }
    public IEnumerable<Offer> Offers { get; set; }
    public double OrderPrice { get; set; }
    public DateTime OrderDate { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public OrderStatus OrderStatus { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public PaymentTypes Type { get; set; }
  }
}