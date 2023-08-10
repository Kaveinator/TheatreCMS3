using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RequestManager : ApplicationUser
    {
        public int RejectedRequests { get; set; }
        public int AcceptedRequests { get; set; }
    }
}