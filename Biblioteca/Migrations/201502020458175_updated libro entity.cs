namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedlibroentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Libro", "genero_GeneroId", "dbo.Genero");
            DropIndex("dbo.Libro", new[] { "genero_GeneroId" });
            RenameColumn(table: "dbo.Libro", name: "genero_GeneroId", newName: "GeneroId");
            AlterColumn("dbo.Libro", "GeneroId", c => c.Int(nullable: false));
            CreateIndex("dbo.Libro", "GeneroId");
            AddForeignKey("dbo.Libro", "GeneroId", "dbo.Genero", "GeneroId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libro", "GeneroId", "dbo.Genero");
            DropIndex("dbo.Libro", new[] { "GeneroId" });
            AlterColumn("dbo.Libro", "GeneroId", c => c.Int());
            RenameColumn(table: "dbo.Libro", name: "GeneroId", newName: "genero_GeneroId");
            CreateIndex("dbo.Libro", "genero_GeneroId");
            AddForeignKey("dbo.Libro", "genero_GeneroId", "dbo.Genero", "GeneroId");
        }
    }
}
