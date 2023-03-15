namespace TheatreCMS3.Areas.Blog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TheatreCMS3.Models;

    public class HeadAuthor : ApplicationUser
    {
        public int ViewsPerMonth { get; set; }
        public int AuthorsHired { get; set; }
        public int AuthorsLetGo { get; set; }

    }
}

