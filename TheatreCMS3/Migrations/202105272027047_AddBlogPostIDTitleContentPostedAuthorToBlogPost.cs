namespace TheatreCMS3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogPostIDTitleContentPostedAuthorToBlogPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        BlogPostID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Posted = c.DateTime(nullable: false),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.BlogPostID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogPosts");
        }
    }
}
