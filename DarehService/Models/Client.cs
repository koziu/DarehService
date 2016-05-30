using System;
using System.ComponentModel.DataAnnotations;

namespace DarehService.API.Models
{
  public class Client : UserModel
  {
    [Required]
    public string FirstName { get; set; }

    public string SecondName { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    public Address CorrespondenceAddress { get; set; }

    [Required]
    public Address RegisteredAddress { get; set; }

    public DateTime RegisterDate { get; set; }
    public DateTime LastLogOnDate { get; set; }
  }
}