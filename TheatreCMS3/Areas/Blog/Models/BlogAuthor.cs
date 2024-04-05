using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Models
{
    public class BlogAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public int Joined { get; set; }
        public int Left { get; set; }

    }
}