using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Models
{
    public class ContactModel : DbContext
    {
        [Required, Display(Name = "Sender Name")]
        public string SenderName { get; set; }
        [Required, Display(Name = "Sender Email"), EmailAddress]
        public string SenderEmail { get; set; }
        [Required]
        public string Message { get; set; }
    }
}