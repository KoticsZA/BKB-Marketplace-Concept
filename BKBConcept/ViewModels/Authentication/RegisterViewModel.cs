using System.ComponentModel.DataAnnotations;

namespace BKBConcept.ViewModels.Authentication
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="You must enter your email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="You must enter your firstname")]
        [StringLength(25, MinimumLength =2, ErrorMessage ="Your firstname/s is too long")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "You must enter your Lastname")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Your Lastname is too long")]
        public string Lastname { get; set; }
        public IFormFile? ProfileImage { get; set; }
        [Required(ErrorMessage ="You must create a password to keep your account secure")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "You must re-enter password to keep make sure it was entered correctly.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage="You must choose a role")]
        public string Role { get; set; }
        public string? Bio { get; set; }
        public IFormFile? NationalId { get; set; }
    }
}
