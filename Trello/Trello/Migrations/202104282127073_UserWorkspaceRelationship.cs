namespace Trello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserWorkspaceRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workspaces", "User_ID", c => c.Int());
            CreateIndex("dbo.Workspaces", "User_ID");
            AddForeignKey("dbo.Workspaces", "User_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workspaces", "User_ID", "dbo.Users");
            DropIndex("dbo.Workspaces", new[] { "User_ID" });
            DropColumn("dbo.Workspaces", "User_ID");
        }
    }
}
