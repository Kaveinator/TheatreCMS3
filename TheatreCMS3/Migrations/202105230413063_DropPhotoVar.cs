namespace TheatreCMS3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropPhotoVar : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CastMembers", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CastMembers", "Photo", c => c.Binary());
        }
    }
}
