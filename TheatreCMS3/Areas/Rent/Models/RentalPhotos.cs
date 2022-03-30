using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    
    public class RentalPhotos
    {
        [Key]
        public int RentalPhotoId { get; set; }
        public string RentalsName { get; set; }
        public bool Damaged { get; set; }
        public byte[] RentalPhoto { get; set; }
        public string Details { get; set; }
    }
}