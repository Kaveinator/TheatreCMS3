namespace TheatreCMS3.Areas.Rent.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class RentalHistory
    {
        [Key]
        public int RentalHistoryId { get; set; }
        public bool RentalDamaged { get; set; }
        public string DamagesIncurred { get; set; }
        public string Rental { get; set; }



    }
}
