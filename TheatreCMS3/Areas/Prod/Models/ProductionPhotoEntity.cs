using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Prod.Models {
    public class ProductionPhotoEntity {
        [Key] public long ProPhotoId { get; set; }
        //public byte[] PhotoFile { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}