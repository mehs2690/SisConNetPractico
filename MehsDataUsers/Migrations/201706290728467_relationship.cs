namespace MehsDataUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPocoApplicationPocoes",
                c => new
                    {
                        UserPoco_Id = c.Guid(nullable: false),
                        ApplicationPoco_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserPoco_Id, t.ApplicationPoco_Id })
                .ForeignKey("dbo.Userm", t => t.UserPoco_Id, cascadeDelete: true)
                .ForeignKey("dbo.Applicationm", t => t.ApplicationPoco_Id, cascadeDelete: true)
                .Index(t => t.UserPoco_Id)
                .Index(t => t.ApplicationPoco_Id);
            
            AddColumn("dbo.Menum", "UserRefId", c => c.Guid());
            CreateIndex("dbo.Menum", "UserRefId");
            AddForeignKey("dbo.Menum", "UserRefId", "dbo.Userm", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menum", "UserRefId", "dbo.Userm");
            DropForeignKey("dbo.UserPocoApplicationPocoes", "ApplicationPoco_Id", "dbo.Applicationm");
            DropForeignKey("dbo.UserPocoApplicationPocoes", "UserPoco_Id", "dbo.Userm");
            DropIndex("dbo.UserPocoApplicationPocoes", new[] { "ApplicationPoco_Id" });
            DropIndex("dbo.UserPocoApplicationPocoes", new[] { "UserPoco_Id" });
            DropIndex("dbo.Menum", new[] { "UserRefId" });
            DropColumn("dbo.Menum", "UserRefId");
            DropTable("dbo.UserPocoApplicationPocoes");
        }
    }
}
