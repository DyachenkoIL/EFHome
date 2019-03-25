namespace EFTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        LeaderId = c.Int(nullable: false),
                        Leader_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Users", t => t.Leader_UserId)
                .Index(t => t.Leader_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstNane = c.String(nullable: false),
                        LastName = c.String(),
                        Position = c.String(),
                        GroupId = c.Int(),
                        Group_GroupId = c.Int(),
                        Group_GroupId1 = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId1)
                .Index(t => t.Group_GroupId)
                .Index(t => t.Group_GroupId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Group_GroupId1", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Leader_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.Users", new[] { "Group_GroupId1" });
            DropIndex("dbo.Users", new[] { "Group_GroupId" });
            DropIndex("dbo.Groups", new[] { "Leader_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Groups");
        }
    }
}
