namespace MehsDataUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTypeRefMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menum", "UserTypeRefId", c => c.Int());
            CreateIndex("dbo.Menum", "UserTypeRefId");
            AddForeignKey("dbo.Menum", "UserTypeRefId", "dbo.UsermCatalog", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menum", "UserTypeRefId", "dbo.UsermCatalog");
            DropIndex("dbo.Menum", new[] { "UserTypeRefId" });
            DropColumn("dbo.Menum", "UserTypeRefId");
        }
    }
}
