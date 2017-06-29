namespace MehsDataUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipNew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menum", "UserRefId", "dbo.Userm");
            DropIndex("dbo.Menum", new[] { "UserRefId" });
            CreateTable(
                "dbo.UserCatalogPocoUserPocoes",
                c => new
                    {
                        UserCatalogPoco_Id = c.Int(nullable: false),
                        UserPoco_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserCatalogPoco_Id, t.UserPoco_Id })
                .ForeignKey("dbo.UsermCatalog", t => t.UserCatalogPoco_Id, cascadeDelete: true)
                .ForeignKey("dbo.Userm", t => t.UserPoco_Id, cascadeDelete: true)
                .Index(t => t.UserCatalogPoco_Id)
                .Index(t => t.UserPoco_Id);
            
            DropColumn("dbo.Menum", "UserRefId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menum", "UserRefId", c => c.Guid());
            DropForeignKey("dbo.UserCatalogPocoUserPocoes", "UserPoco_Id", "dbo.Userm");
            DropForeignKey("dbo.UserCatalogPocoUserPocoes", "UserCatalogPoco_Id", "dbo.UsermCatalog");
            DropIndex("dbo.UserCatalogPocoUserPocoes", new[] { "UserPoco_Id" });
            DropIndex("dbo.UserCatalogPocoUserPocoes", new[] { "UserCatalogPoco_Id" });
            DropTable("dbo.UserCatalogPocoUserPocoes");
            CreateIndex("dbo.Menum", "UserRefId");
            AddForeignKey("dbo.Menum", "UserRefId", "dbo.Userm", "Id");
        }
    }
}
