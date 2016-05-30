using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DarehService.API.Models.Enums;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DarehService.API.Models
{
  public class UserModel : IdentityUser
  {
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    public ApplicationTypes ApplicationType { get; set; }
    public bool Active { get; set; }
    public int RefreshTokenLifeTime { get; set; }
    [MaxLength(100)]
    public string AllowedOrigin { get; set; }
  }
}