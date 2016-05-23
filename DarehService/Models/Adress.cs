using System.ComponentModel.DataAnnotations;

namespace DarehService.API.Models
{
  public class Address
  {
    [Required]
    public string StreetName { get; set; }
    public string LocalNumber { get; set; }
    [Required]
    public string StreetNumber { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string PostalCode { get; set; }
    [Required]
    public string Community { get; set; }//gmina
    [Required]
    public string County { get; set; }//powiat
    [Required]
    public string Province { get; set; }
    [Required]
    public string Country { get; set; }
  }
}