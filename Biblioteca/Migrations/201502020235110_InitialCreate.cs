namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        autorId = c.Int(nullable: false, identity: true),
                        nombres = c.String(),
                        apellidos = c.String(),
                        nacionalidad = c.String(),
                        fechaNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.autorId);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        GeneroId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                    })
                .PrimaryKey(t => t.GeneroId);
            
            CreateTable(
                "dbo.Libro",
                c => new
                    {
                        isbn = c.String(nullable: false, maxLength: 128),
                        titulo = c.String(),
                        descripcion = c.String(),
                        genero_GeneroId = c.Int(),
                        Tag_tagId = c.Int(),
                    })
                .PrimaryKey(t => t.isbn)
                .ForeignKey("dbo.Genero", t => t.genero_GeneroId)
                .ForeignKey("dbo.Tag", t => t.Tag_tagId)
                .Index(t => t.genero_GeneroId)
                .Index(t => t.Tag_tagId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        tagId = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.tagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libro", "Tag_tagId", "dbo.Tag");
            DropForeignKey("dbo.Libro", "genero_GeneroId", "dbo.Genero");
            DropIndex("dbo.Libro", new[] { "Tag_tagId" });
            DropIndex("dbo.Libro", new[] { "genero_GeneroId" });
            DropTable("dbo.Tag");
            DropTable("dbo.Libro");
            DropTable("dbo.Genero");
            DropTable("dbo.Autor");
        }
    }
}
