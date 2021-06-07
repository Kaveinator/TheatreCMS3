using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Models
{
    public class Donation
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public double Amount { get; set; }
        public string Comments { get; set; }
        public virtual ICollection<Donate> Donated { get; set; }

    }
}