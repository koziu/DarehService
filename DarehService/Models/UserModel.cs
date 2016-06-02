using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DarehService.API.Models
{
  public class UserModel : IdentityUser
  {
    //[Required]
    public string FirstName { get; set; }

    public string SecondName { get; set; }

    //[Required]
    public string Surname { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    //[Required]
    public Address CorrespondenceAddress { get; set; }

    //[Required]
    public Address RegisteredAddress { get; set; }

    public DateTime RegisterDate { get; set; }
    public DateTime LastLogOnDate { get; set; }
  }
}