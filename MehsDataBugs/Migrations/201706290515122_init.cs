namespace MehsDataBugs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bug",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Image = c.Binary(),
                        Description = c.String(),
                        Status = c.String(),
                        BugRegistredDate = c.DateTime(nullable: false),
                        BugClosedDate = c.DateTime(),
                        AppId = c.Guid(),
                        UserRegId = c.Guid(),
                        UserSolId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BugNotification",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Sender = c.String(),
                        Receiver = c.String(),
                        IssuedDate = c.DateTime(nullable: false),
                        ReadDate = c.DateTime(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BugNotification");
            DropTable("dbo.Bug");
        }
    }
}
