using System;
using System.Collections.Generic;

namespace DarehService.API.Models
{
  public class ClientOrders
  {
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public IEnumerable<Order> Orders { get; set; }
  }
}