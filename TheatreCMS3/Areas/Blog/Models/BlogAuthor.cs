namespace TheatreCMS3.Areas.Blog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BlogAuthor
    {
        public int BlogAuthorId { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public DateTime Joined { get; set; }

        public DateTime Left { get; set; }
    }
}
