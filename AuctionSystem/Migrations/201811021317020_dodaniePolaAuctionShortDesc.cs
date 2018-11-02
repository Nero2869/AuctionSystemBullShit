namespace AuctionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniePolaAuctionShortDesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auction", "AuctionShortDesc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auction", "AuctionShortDesc");
        }
    }
}
