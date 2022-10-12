using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Models
{
    public partial class Contact
    {
        [DisplayName("First & Last Name *")]
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        [DisplayName("Message *")]
        public string Message { get; set; }
    }
}