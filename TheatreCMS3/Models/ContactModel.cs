using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Models
{
    public class ContactModel : DbContext
    {
        [Required, Display(Name = "First and Last Name")]
        public string SenderName { get; set; }
        [Required, Display(Name = "Email Address"), EmailAddress]
        public string SenderEmail { get; set; }
        [Required, Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required, Display(Name = "Message")]
        public string Message { get; set; }
    }
}