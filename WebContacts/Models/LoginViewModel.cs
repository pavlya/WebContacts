using System.ComponentModel.DataAnnotations;

namespace WebContacts.Models
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
