namespace HomeCrud.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingNameAdressToHome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Homes", "Name", c => c.String());
            AddColumn("dbo.Homes", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Homes", "Address");
            DropColumn("dbo.Homes", "Name");
        }
    }
}
