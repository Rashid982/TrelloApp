namespace Trello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Workspaces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Number = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ListBoards",
                c => new
                    {
                        List_ID = c.Int(nullable: false),
                        Board_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.List_ID, t.Board_ID })
                .ForeignKey("dbo.Lists", t => t.List_ID, cascadeDelete: true)
                .ForeignKey("dbo.Boards", t => t.Board_ID, cascadeDelete: true)
                .Index(t => t.List_ID)
                .Index(t => t.Board_ID);
            
            CreateTable(
                "dbo.CardLists",
                c => new
                    {
                        Card_ID = c.Int(nullable: false),
                        List_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Card_ID, t.List_ID })
                .ForeignKey("dbo.Cards", t => t.Card_ID, cascadeDelete: true)
                .ForeignKey("dbo.Lists", t => t.List_ID, cascadeDelete: true)
                .Index(t => t.Card_ID)
                .Index(t => t.List_ID);
            
            CreateTable(
                "dbo.WorkspaceBoards",
                c => new
                    {
                        Workspace_ID = c.Int(nullable: false),
                        Board_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Workspace_ID, t.Board_ID })
                .ForeignKey("dbo.Workspaces", t => t.Workspace_ID, cascadeDelete: true)
                .ForeignKey("dbo.Boards", t => t.Board_ID, cascadeDelete: true)
                .Index(t => t.Workspace_ID)
                .Index(t => t.Board_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkspaceBoards", "Board_ID", "dbo.Boards");
            DropForeignKey("dbo.WorkspaceBoards", "Workspace_ID", "dbo.Workspaces");
            DropForeignKey("dbo.CardLists", "List_ID", "dbo.Lists");
            DropForeignKey("dbo.CardLists", "Card_ID", "dbo.Cards");
            DropForeignKey("dbo.ListBoards", "Board_ID", "dbo.Boards");
            DropForeignKey("dbo.ListBoards", "List_ID", "dbo.Lists");
            DropIndex("dbo.WorkspaceBoards", new[] { "Board_ID" });
            DropIndex("dbo.WorkspaceBoards", new[] { "Workspace_ID" });
            DropIndex("dbo.CardLists", new[] { "List_ID" });
            DropIndex("dbo.CardLists", new[] { "Card_ID" });
            DropIndex("dbo.ListBoards", new[] { "Board_ID" });
            DropIndex("dbo.ListBoards", new[] { "List_ID" });
            DropTable("dbo.WorkspaceBoards");
            DropTable("dbo.CardLists");
            DropTable("dbo.ListBoards");
            DropTable("dbo.Users");
            DropTable("dbo.Workspaces");
            DropTable("dbo.Cards");
            DropTable("dbo.Lists");
            DropTable("dbo.Boards");
        }
    }
}
