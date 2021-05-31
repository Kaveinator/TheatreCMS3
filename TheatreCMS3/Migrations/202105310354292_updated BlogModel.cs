namespace TheatreCMS3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedBlogModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogAuthors",
                c => new
                    {
                        BlogAuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bio = c.String(),
                        Joined = c.DateTime(nullable: false),
                        Left = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogAuthorId);
            
            CreateTable(
                "dbo.BlogPhotoes",
                c => new
                    {
                        BlogPhotoId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.BlogPhotoId);
            
            CreateTable(
                "dbo.CastMembers",
                c => new
                    {
                        CastMemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        YearJoined = c.Int(nullable: false),
                        MainRole = c.Int(nullable: false),
                        Bio = c.String(),
                        Photo = c.Binary(),
                        CurrentMember = c.Boolean(nullable: false),
                        Character = c.String(),
                        CastYearLeft = c.Int(nullable: false),
                        DebutYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CastMemberId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.CastMembers");
            DropTable("dbo.BlogPhotoes");
            DropTable("dbo.BlogAuthors");
        }
    }
}
