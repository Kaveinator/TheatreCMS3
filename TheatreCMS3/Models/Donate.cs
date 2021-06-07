using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Models
{
    public class Donate
    {
        public int DonateID { get; set; }
        public int DonationID { get; set; }

        public virtual Donation Donation { get; set; }
    }
}