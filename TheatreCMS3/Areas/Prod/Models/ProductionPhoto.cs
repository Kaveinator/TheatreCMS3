using System;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionPhoto
    {
        [Key]
        public int ProPhotoId { get; set; }

        // public byte[] PhotoFile { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}