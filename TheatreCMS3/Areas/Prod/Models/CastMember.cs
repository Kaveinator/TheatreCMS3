using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CastMember
    {
        //properties for cast member
       public int CastMemberId { get; set; }  
       public string Name { get; set; }   
       public int? YearJoined { get; set; }    
       public string MainRole { get; set; }   
       public string Bio { get; set; }    
        //byte Photo { get; set; }    
       public bool CurrentMember { get; set; }
       public string Character { get; set; }  
       public int?  CastYearLeft { get; set; }  
       public int? DebutYear { get; set; } 

        //position enum 
        enum PositionEnum
        {
            Actor,
            Director,
            Technician,
            StageManager,
            Other 
        }

      
        
    }
}