namespace TheatreCMS3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CastMembers", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CastMembers", "Photo");
        }
    }
}
