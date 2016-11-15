namespace HomeCrud.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingpersonentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Identification = c.String(),
                        Home_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Homes", t => t.Home_Id)
                .Index(t => t.Home_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Home_Id", "dbo.Homes");
            DropIndex("dbo.People", new[] { "Home_Id" });
            DropTable("dbo.People");
        }
    }
}
