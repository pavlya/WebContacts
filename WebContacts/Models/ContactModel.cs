using System;
using System.Collections.Generic;
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
        [RegularExpression(@"^[a-zA-Z0-9.-]{1,20}@[a-zA-Z0-9]{1,20}\.[A-Za-z]{2,4}", ErrorMessage = "Wrong email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string PhoneNumber { get; set; }
        
        public virtual ICollection<File> Files { get; set; }

    }
}