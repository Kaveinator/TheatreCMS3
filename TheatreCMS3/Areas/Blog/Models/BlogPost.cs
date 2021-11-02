using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

// This model represents a blog post that a blog writer or author would create and users could interact with.
    // 1. Properties: <pl> + BlogPostId: int, Title: string, Contents: string, Posted: DateTime, Author: string.
    // 2. Ensure that the model is added to the database correctly: After running update-database, you should be able to find a table in the database corresponding to the BlogPost model.
    // 3. scaffold the CRUD pages for this model (Use Visual Studio and EntityFramework to create the Index, Edit, Create, Details, and Delete pages).
    // 4. Ensure that each page can be reached and BlogPost can be created, edited, and deleted.

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPost
    {
        [Key]                                  // The Key attribute can be applied to a property to make it a key property in an entity class and the corresponding column to a primary key column in the database.
        public int BlogPostId  { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime DateTime { get; set; }
        public string Author { get; set; }
    }

    
    

}