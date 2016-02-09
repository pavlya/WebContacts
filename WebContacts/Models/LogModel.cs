using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebContacts.Models
{
    public class LogModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime date { get; set; }
        public string logEvent { get; set; }
        public string Username { get; set; }
        public string description { get; set; }
    }
}
