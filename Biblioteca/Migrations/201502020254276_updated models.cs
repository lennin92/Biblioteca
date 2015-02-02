namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Libro", "Tag_tagId", "dbo.Tag");
            DropIndex("dbo.Libro", new[] { "Tag_tagId" });
            CreateTable(
                "dbo.libro_autor",
                c => new
                    {
                        isbn = c.String(nullable: false, maxLength: 128),
                        autorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.isbn, t.autorId })
                .ForeignKey("dbo.Libro", t => t.isbn, cascadeDelete: true)
                .ForeignKey("dbo.Autor", t => t.autorId, cascadeDelete: true)
                .Index(t => t.isbn)
                .Index(t => t.autorId);
            
            CreateTable(
                "dbo.TagLibro",
                c => new
                    {
                        Tag_tagId = c.Int(nullable: false),
                        Libro_isbn = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Tag_tagId, t.Libro_isbn })
                .ForeignKey("dbo.Tag", t => t.Tag_tagId, cascadeDelete: true)
                .ForeignKey("dbo.Libro", t => t.Libro_isbn, cascadeDelete: true)
                .Index(t => t.Tag_tagId)
                .Index(t => t.Libro_isbn);
            
            DropColumn("dbo.Libro", "Tag_tagId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Libro", "Tag_tagId", c => c.Int());
            DropForeignKey("dbo.TagLibro", "Libro_isbn", "dbo.Libro");
            DropForeignKey("dbo.TagLibro", "Tag_tagId", "dbo.Tag");
            DropForeignKey("dbo.libro_autor", "autorId", "dbo.Autor");
            DropForeignKey("dbo.libro_autor", "isbn", "dbo.Libro");
            DropIndex("dbo.TagLibro", new[] { "Libro_isbn" });
            DropIndex("dbo.TagLibro", new[] { "Tag_tagId" });
            DropIndex("dbo.libro_autor", new[] { "autorId" });
            DropIndex("dbo.libro_autor", new[] { "isbn" });
            DropTable("dbo.TagLibro");
            DropTable("dbo.libro_autor");
            CreateIndex("dbo.Libro", "Tag_tagId");
            AddForeignKey("dbo.Libro", "Tag_tagId", "dbo.Tag", "tagId");
        }
    }
}
