using System;
using System.Collections.Generic;

namespace DarehService.API.Models
{
  public class Offer
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<string> OfferKinds { get; set; }
    public string Description { get; set; }
    public string EffectsOnBodyDescription { get; set; }
    public IEnumerable<string> EffectsOnBody { get; set; }
    public string IndicationsDescription { get; set; }
    public IEnumerable<string> Indications { get; set; }
    public string ContraindicationsDescription { get; set; }
    public IEnumerable<string> Contraindications { get; set; }
    public double Price { get; set; }
  }
}