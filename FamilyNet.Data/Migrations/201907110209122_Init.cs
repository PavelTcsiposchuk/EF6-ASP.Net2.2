namespace FamilyNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharityMakers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Birthday = c.DateTime(nullable: false),
                        Rating = c.Single(nullable: false),
                        PathToAvatar = c.String(),
                        Address_ID = c.Int(),
                        Contacts_ID = c.Int(),
                        FullName_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Contacts", t => t.Contacts_ID)
                .ForeignKey("dbo.FullNames", t => t.FullName_ID, cascadeDelete: true)
                .Index(t => t.Address_ID)
                .Index(t => t.Contacts_ID)
                .Index(t => t.FullName_ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        House = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        DonationItem_ID = c.Int(nullable: false),
                        CharityMaker_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DonationItems", t => t.DonationItem_ID, cascadeDelete: true)
                .ForeignKey("dbo.CharityMakers", t => t.CharityMaker_ID)
                .Index(t => t.DonationItem_ID)
                .Index(t => t.CharityMaker_ID);
            
            CreateTable(
                "dbo.DonationItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DonationItemTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentId = c.Int(nullable: false),
                        ChildId = c.Int(nullable: false),
                        DonationItem_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DonationItems", t => t.DonationItem_ID)
                .Index(t => t.DonationItem_ID);
            
            CreateTable(
                "dbo.FullNames",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(nullable: false),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orphanages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        Avatar = c.String(),
                        Adress_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Adress_ID, cascadeDelete: true)
                .Index(t => t.Adress_ID);
            
            CreateTable(
                "dbo.Orphans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Birthday = c.DateTime(nullable: false),
                        Rating = c.Single(nullable: false),
                        PathToAvatar = c.String(),
                        Address_ID = c.Int(),
                        Contacts_ID = c.Int(),
                        FullName_ID = c.Int(nullable: false),
                        Orphanage_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Contacts", t => t.Contacts_ID)
                .ForeignKey("dbo.FullNames", t => t.FullName_ID, cascadeDelete: true)
                .ForeignKey("dbo.Orphanages", t => t.Orphanage_ID, cascadeDelete: true)
                .Index(t => t.Address_ID)
                .Index(t => t.Contacts_ID)
                .Index(t => t.FullName_ID)
                .Index(t => t.Orphanage_ID);
            
            CreateTable(
                "dbo.AuctionLots",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        AuctionLotItem_ID = c.Int(),
                        Orphan_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AuctionLotItems", t => t.AuctionLotItem_ID)
                .ForeignKey("dbo.Orphans", t => t.Orphan_ID)
                .Index(t => t.AuctionLotItem_ID)
                .Index(t => t.Orphan_ID);
            
            CreateTable(
                "dbo.AuctionLotItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AuctionLotItemTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentId = c.Int(nullable: false),
                        ChildId = c.Int(nullable: false),
                        AuctionLotItem_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AuctionLotItems", t => t.AuctionLotItem_ID)
                .Index(t => t.AuctionLotItem_ID);
            
            CreateTable(
                "dbo.Representatives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Birthday = c.DateTime(nullable: false),
                        Rating = c.Single(nullable: false),
                        PathToAvatar = c.String(),
                        Address_ID = c.Int(),
                        Contacts_ID = c.Int(),
                        FullName_ID = c.Int(nullable: false),
                        Orphanage_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Contacts", t => t.Contacts_ID)
                .ForeignKey("dbo.FullNames", t => t.FullName_ID, cascadeDelete: true)
                .ForeignKey("dbo.Orphanages", t => t.Orphanage_ID, cascadeDelete: true)
                .Index(t => t.Address_ID)
                .Index(t => t.Contacts_ID)
                .Index(t => t.FullName_ID)
                .Index(t => t.Orphanage_ID);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Birthday = c.DateTime(nullable: false),
                        Rating = c.Single(nullable: false),
                        PathToAvatar = c.String(),
                        Address_ID = c.Int(),
                        Contacts_ID = c.Int(),
                        FullName_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Contacts", t => t.Contacts_ID)
                .ForeignKey("dbo.FullNames", t => t.FullName_ID, cascadeDelete: true)
                .Index(t => t.Address_ID)
                .Index(t => t.Contacts_ID)
                .Index(t => t.FullName_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Volunteers", "FullName_ID", "dbo.FullNames");
            DropForeignKey("dbo.Volunteers", "Contacts_ID", "dbo.Contacts");
            DropForeignKey("dbo.Volunteers", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Representatives", "Orphanage_ID", "dbo.Orphanages");
            DropForeignKey("dbo.Representatives", "FullName_ID", "dbo.FullNames");
            DropForeignKey("dbo.Representatives", "Contacts_ID", "dbo.Contacts");
            DropForeignKey("dbo.Representatives", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Orphans", "Orphanage_ID", "dbo.Orphanages");
            DropForeignKey("dbo.Orphans", "FullName_ID", "dbo.FullNames");
            DropForeignKey("dbo.Orphans", "Contacts_ID", "dbo.Contacts");
            DropForeignKey("dbo.AuctionLots", "Orphan_ID", "dbo.Orphans");
            DropForeignKey("dbo.AuctionLots", "AuctionLotItem_ID", "dbo.AuctionLotItems");
            DropForeignKey("dbo.AuctionLotItemTypes", "AuctionLotItem_ID", "dbo.AuctionLotItems");
            DropForeignKey("dbo.Orphans", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Orphanages", "Adress_ID", "dbo.Addresses");
            DropForeignKey("dbo.CharityMakers", "FullName_ID", "dbo.FullNames");
            DropForeignKey("dbo.Donations", "CharityMaker_ID", "dbo.CharityMakers");
            DropForeignKey("dbo.Donations", "DonationItem_ID", "dbo.DonationItems");
            DropForeignKey("dbo.DonationItemTypes", "DonationItem_ID", "dbo.DonationItems");
            DropForeignKey("dbo.CharityMakers", "Contacts_ID", "dbo.Contacts");
            DropForeignKey("dbo.CharityMakers", "Address_ID", "dbo.Addresses");
            DropIndex("dbo.Volunteers", new[] { "FullName_ID" });
            DropIndex("dbo.Volunteers", new[] { "Contacts_ID" });
            DropIndex("dbo.Volunteers", new[] { "Address_ID" });
            DropIndex("dbo.Representatives", new[] { "Orphanage_ID" });
            DropIndex("dbo.Representatives", new[] { "FullName_ID" });
            DropIndex("dbo.Representatives", new[] { "Contacts_ID" });
            DropIndex("dbo.Representatives", new[] { "Address_ID" });
            DropIndex("dbo.AuctionLotItemTypes", new[] { "AuctionLotItem_ID" });
            DropIndex("dbo.AuctionLots", new[] { "Orphan_ID" });
            DropIndex("dbo.AuctionLots", new[] { "AuctionLotItem_ID" });
            DropIndex("dbo.Orphans", new[] { "Orphanage_ID" });
            DropIndex("dbo.Orphans", new[] { "FullName_ID" });
            DropIndex("dbo.Orphans", new[] { "Contacts_ID" });
            DropIndex("dbo.Orphans", new[] { "Address_ID" });
            DropIndex("dbo.Orphanages", new[] { "Adress_ID" });
            DropIndex("dbo.DonationItemTypes", new[] { "DonationItem_ID" });
            DropIndex("dbo.Donations", new[] { "CharityMaker_ID" });
            DropIndex("dbo.Donations", new[] { "DonationItem_ID" });
            DropIndex("dbo.CharityMakers", new[] { "FullName_ID" });
            DropIndex("dbo.CharityMakers", new[] { "Contacts_ID" });
            DropIndex("dbo.CharityMakers", new[] { "Address_ID" });
            DropTable("dbo.Volunteers");
            DropTable("dbo.Representatives");
            DropTable("dbo.AuctionLotItemTypes");
            DropTable("dbo.AuctionLotItems");
            DropTable("dbo.AuctionLots");
            DropTable("dbo.Orphans");
            DropTable("dbo.Orphanages");
            DropTable("dbo.FullNames");
            DropTable("dbo.DonationItemTypes");
            DropTable("dbo.DonationItems");
            DropTable("dbo.Donations");
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
            DropTable("dbo.CharityMakers");
        }
    }
}
