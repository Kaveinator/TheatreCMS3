using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class Production
    {

        public int ProductionID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Playwright { get; set; }
        public int Runtime { get; set; }
        public DateTime OpeningDay { get; set; }
        public DateTime ClosingDay { get; set; }
        public DateTime ShowTimeEve { get; set; }
        public DateTime? ShowTimeMat { get; set; }
        public int Season { get; set; }
        public bool IsWorldPremiere { get; set; }
        public string TicketLink { get; set; }
        public bool IsCurrentlyShowing { get; set; }//leaving off here. Need to scaffold the CRUD pages tomorrow.
    }
}