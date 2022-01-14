namespace TheatreCMS3.Areas.Blog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BlogAuthor")]
    public partial class BlogAuthor
    {
        public int BlogAuthorId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Bio { get; set; }

        public DateTime Joined { get; set; }

        public DateTime Left { get; set; }
    }
}
