using System.ComponentModel.DataAnnotations;

namespace WebContacts.Models
{
    public class RegistrationModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "User name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[a-za-z0-9.-]{1,20}@[a-za-z0-9]{1,20}\.[a-za-z]{2,4}", ErrorMessage = "wrong email format")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        //[RegularExpression(@"^[a-zA-Z0-9.-]{1,20}@[a-zA-Z0-9]{1,20}\.[A-Za-z]{2,4}", ErrorMessage = "Wrong email format")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        public string ConfirmEmail { get; set; }
    }
}
