using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace BKBConcept.ViewModels.Authentication
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="You must enter your email address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}