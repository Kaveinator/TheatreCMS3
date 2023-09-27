using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class HistoryManager : TheatreCMS3.Models.ApplicationUser
    {
        public int RestrictedUsers { get; set; }
        public int RentalReplacementRequests { get; set; }


        public static HistoryManager createManagers()
        {

            HistoryManager manager = new HistoryManager
                {
                    UserName = "TestUser",
                    RestrictedUsers = 3,
                    RentalReplacementRequests = 4
                };

            return manager;


        }
        

        
    }


   
}