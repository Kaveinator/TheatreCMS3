using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CastDirector: ApplicationUser
    {
        public int HiredCastMembers { get; set; }
        public int FiredCastMembers { get; set; }
    }
}