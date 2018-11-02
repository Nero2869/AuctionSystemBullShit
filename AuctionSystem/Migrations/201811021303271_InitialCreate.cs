namespace AuctionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auction",
                c => new
                    {
                        AuctionID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        AuctionTitle = c.String(nullable: false, maxLength: 100),
                        AuctionOwner = c.String(),
                        AuctionDescription = c.String(),
                        AuctionDateAdd = c.DateTime(nullable: false),
                        AuctionPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AuctionID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        CategoryDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        AuctionID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        BuyoutPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderItemID)
                .ForeignKey("dbo.Auction", t => t.AuctionID, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.AuctionID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        PostCode = c.String(nullable: false, maxLength: 6),
                        TelephoneNumber = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        OrderAddDate = c.DateTime(nullable: false),
                        OrderState = c.Int(nullable: false),
                        OrderSumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "OrderID", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "AuctionID", "dbo.Auction");
            DropForeignKey("dbo.Auction", "CategoryID", "dbo.Category");
            DropIndex("dbo.OrderItem", new[] { "AuctionID" });
            DropIndex("dbo.OrderItem", new[] { "OrderID" });
            DropIndex("dbo.Auction", new[] { "CategoryID" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Category");
            DropTable("dbo.Auction");
        }
    }
}
