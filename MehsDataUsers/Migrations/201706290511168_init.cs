namespace MehsDataUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicationm",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Activate = c.Boolean(nullable: false),
                        Estatus = c.String(),
                        Url = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Order = c.Int(nullable: false),
                        Icon = c.String(),
                        StyleClass = c.String(),
                        EventOn = c.String(),
                        Estatus = c.String(),
                        OptionType = c.String(),
                        ImageUrl = c.String(),
                        Alt = c.String(),
                        ParentRefId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menum", t => t.ParentRefId)
                .Index(t => t.Order)
                .Index(t => t.ParentRefId);
            
            CreateTable(
                "dbo.Profilem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Estatus = c.String(),
                        Range = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ApplicationId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Userm",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Type = c.String(),
                        Estatus = c.String(),
                        SignUpDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsermCatalog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Status = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menum", "ParentRefId", "dbo.Menum");
            DropIndex("dbo.Menum", new[] { "ParentRefId" });
            DropIndex("dbo.Menum", new[] { "Order" });
            DropTable("dbo.UsermCatalog");
            DropTable("dbo.Userm");
            DropTable("dbo.Profilem");
            DropTable("dbo.Menum");
            DropTable("dbo.Applicationm");
        }
    }
}
