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
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        public Position Position { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[a-zA-Z0-9.-]{1,20}@[a-zA-Z0-9]{1,20}\.[A-Za-z]{2,4}", ErrorMessage = "Wrong email format")]
        public string Email { get; set; }

        // using regexp for phone number format checking
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"\+?((([\d]{0,3})\-[\d]{6,})|([\d]{7,20}))", ErrorMessage = "Wrong phone number format")]
        public string PhoneNumber { get; set; }
        
        public virtual ICollection<File> Files { get; set; }

    }

    public enum Position
    {
        Developer,
        Designer,
        Helpdesk,
        IT_Specialist,
        QA_Specialist
    }
}