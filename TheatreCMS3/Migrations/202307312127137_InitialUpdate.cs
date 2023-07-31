namespace TheatreCMS3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "RentalEquipment_RentalId", "dbo.Rentals");
            DropForeignKey("dbo.Rentals", "RentalRoom_RentalId", "dbo.Rentals");
            DropIndex("dbo.Rentals", new[] { "RentalEquipment_RentalId" });
            DropIndex("dbo.Rentals", new[] { "RentalRoom_RentalId" });
            CreateTable(
                "dbo.CalendarEvents",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        AllDay = c.Boolean(nullable: false),
                        TicketsAvailable = c.Int(nullable: false),
                        IsProduction = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
            AddColumn("dbo.RentalHistories", "SelectedRentalId", c => c.Int(nullable: false));
            AddColumn("dbo.RentalHistories", "Rental_RentalId", c => c.Int());
            AddColumn("dbo.RentalPhotoes", "Votes", c => c.Int(nullable: false));
            AddColumn("dbo.RentalPhotoes", "UpVotes", c => c.Int(nullable: false));
            CreateIndex("dbo.RentalHistories", "Rental_RentalId");
            AddForeignKey("dbo.RentalHistories", "Rental_RentalId", "dbo.Rentals", "RentalId");
            DropColumn("dbo.RentalHistories", "Rental");
            DropColumn("dbo.Rentals", "RentalEquipment_RentalId");
            DropColumn("dbo.Rentals", "RentalRoom_RentalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "RentalRoom_RentalId", c => c.Int());
            AddColumn("dbo.Rentals", "RentalEquipment_RentalId", c => c.Int());
            AddColumn("dbo.RentalHistories", "Rental", c => c.String());
            DropForeignKey("dbo.RentalHistories", "Rental_RentalId", "dbo.Rentals");
            DropIndex("dbo.RentalHistories", new[] { "Rental_RentalId" });
            DropColumn("dbo.RentalPhotoes", "UpVotes");
            DropColumn("dbo.RentalPhotoes", "Votes");
            DropColumn("dbo.RentalHistories", "Rental_RentalId");
            DropColumn("dbo.RentalHistories", "SelectedRentalId");
            DropTable("dbo.CalendarEvents");
            CreateIndex("dbo.Rentals", "RentalRoom_RentalId");
            CreateIndex("dbo.Rentals", "RentalEquipment_RentalId");
            AddForeignKey("dbo.Rentals", "RentalRoom_RentalId", "dbo.Rentals", "RentalId");
            AddForeignKey("dbo.Rentals", "RentalEquipment_RentalId", "dbo.Rentals", "RentalId");
        }
    }
}
