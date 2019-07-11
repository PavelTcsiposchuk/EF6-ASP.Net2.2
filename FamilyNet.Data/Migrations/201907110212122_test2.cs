namespace FamilyNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CharityMakers", "testmigrate");
            DropColumn("dbo.Orphans", "testmigrate");
            DropColumn("dbo.Representatives", "testmigrate");
            DropColumn("dbo.Volunteers", "testmigrate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Volunteers", "testmigrate", c => c.String());
            AddColumn("dbo.Representatives", "testmigrate", c => c.String());
            AddColumn("dbo.Orphans", "testmigrate", c => c.String());
            AddColumn("dbo.CharityMakers", "testmigrate", c => c.String());
        }
    }
}
