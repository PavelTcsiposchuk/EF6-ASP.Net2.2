namespace FamilyNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharityMakers", "testmigrate", c => c.String());
            AddColumn("dbo.Orphans", "testmigrate", c => c.String());
            AddColumn("dbo.Representatives", "testmigrate", c => c.String());
            AddColumn("dbo.Volunteers", "testmigrate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteers", "testmigrate");
            DropColumn("dbo.Representatives", "testmigrate");
            DropColumn("dbo.Orphans", "testmigrate");
            DropColumn("dbo.CharityMakers", "testmigrate");
        }
    }
}
