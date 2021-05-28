namespace Trello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListBoards", "List_ID", "dbo.Lists");
            DropForeignKey("dbo.ListBoards", "Board_ID", "dbo.Boards");
            DropForeignKey("dbo.CardLists", "Card_ID", "dbo.Cards");
            DropForeignKey("dbo.CardLists", "List_ID", "dbo.Lists");
            DropForeignKey("dbo.WorkspaceBoards", "Workspace_ID", "dbo.Workspaces");
            DropForeignKey("dbo.WorkspaceBoards", "Board_ID", "dbo.Boards");
            DropIndex("dbo.ListBoards", new[] { "List_ID" });
            DropIndex("dbo.ListBoards", new[] { "Board_ID" });
            DropIndex("dbo.CardLists", new[] { "Card_ID" });
            DropIndex("dbo.CardLists", new[] { "List_ID" });
            DropIndex("dbo.WorkspaceBoards", new[] { "Workspace_ID" });
            DropIndex("dbo.WorkspaceBoards", new[] { "Board_ID" });
            AddColumn("dbo.Boards", "Workspace_ID", c => c.Int());
            AddColumn("dbo.Lists", "Board_ID", c => c.Int());
            AddColumn("dbo.Cards", "List_ID", c => c.Int());
            CreateIndex("dbo.Boards", "Workspace_ID");
            CreateIndex("dbo.Lists", "Board_ID");
            CreateIndex("dbo.Cards", "List_ID");
            AddForeignKey("dbo.Lists", "Board_ID", "dbo.Boards", "ID");
            AddForeignKey("dbo.Cards", "List_ID", "dbo.Lists", "ID");
            AddForeignKey("dbo.Boards", "Workspace_ID", "dbo.Workspaces", "ID");
            DropTable("dbo.ListBoards");
            DropTable("dbo.CardLists");
            DropTable("dbo.WorkspaceBoards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkspaceBoards",
                c => new
                    {
                        Workspace_ID = c.Int(nullable: false),
                        Board_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Workspace_ID, t.Board_ID });
            
            CreateTable(
                "dbo.CardLists",
                c => new
                    {
                        Card_ID = c.Int(nullable: false),
                        List_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Card_ID, t.List_ID });
            
            CreateTable(
                "dbo.ListBoards",
                c => new
                    {
                        List_ID = c.Int(nullable: false),
                        Board_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.List_ID, t.Board_ID });
            
            DropForeignKey("dbo.Boards", "Workspace_ID", "dbo.Workspaces");
            DropForeignKey("dbo.Cards", "List_ID", "dbo.Lists");
            DropForeignKey("dbo.Lists", "Board_ID", "dbo.Boards");
            DropIndex("dbo.Cards", new[] { "List_ID" });
            DropIndex("dbo.Lists", new[] { "Board_ID" });
            DropIndex("dbo.Boards", new[] { "Workspace_ID" });
            DropColumn("dbo.Cards", "List_ID");
            DropColumn("dbo.Lists", "Board_ID");
            DropColumn("dbo.Boards", "Workspace_ID");
            CreateIndex("dbo.WorkspaceBoards", "Board_ID");
            CreateIndex("dbo.WorkspaceBoards", "Workspace_ID");
            CreateIndex("dbo.CardLists", "List_ID");
            CreateIndex("dbo.CardLists", "Card_ID");
            CreateIndex("dbo.ListBoards", "Board_ID");
            CreateIndex("dbo.ListBoards", "List_ID");
            AddForeignKey("dbo.WorkspaceBoards", "Board_ID", "dbo.Boards", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WorkspaceBoards", "Workspace_ID", "dbo.Workspaces", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CardLists", "List_ID", "dbo.Lists", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CardLists", "Card_ID", "dbo.Cards", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ListBoards", "Board_ID", "dbo.Boards", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ListBoards", "List_ID", "dbo.Lists", "ID", cascadeDelete: true);
        }
    }
}
