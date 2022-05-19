namespace POS_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1stDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactsID = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Designation = c.String(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ContactsID)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        City = c.String(),
                        ComercialName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                        Price = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                        Category = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Store_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .ForeignKey("dbo.Stores", t => t.Store_ID)
                .Index(t => t.Id)
                .Index(t => t.Store_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Store_ID", "dbo.Stores");
            DropForeignKey("dbo.Employee", "Id", "dbo.People");
            DropForeignKey("dbo.Customer", "Id", "dbo.People");
            DropForeignKey("dbo.Contacts", "Person_Id", "dbo.People");
            DropIndex("dbo.Employee", new[] { "Store_ID" });
            DropIndex("dbo.Employee", new[] { "Id" });
            DropIndex("dbo.Customer", new[] { "Id" });
            DropIndex("dbo.Contacts", new[] { "Person_Id" });
            DropTable("dbo.Employee");
            DropTable("dbo.Customer");
            DropTable("dbo.Products");
            DropTable("dbo.Stores");
            DropTable("dbo.Contacts");
            DropTable("dbo.People");
        }
    }
}
