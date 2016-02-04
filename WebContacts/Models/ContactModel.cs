using System;
using System.ComponentModel.DataAnnotations;

namespace WebContacts.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "*")]
        public string Position { get; set; }
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        public string PhoneNumber { get; set; }
    }
}