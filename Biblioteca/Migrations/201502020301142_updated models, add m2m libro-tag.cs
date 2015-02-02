namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelsaddm2mlibrotag : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagLibro", newName: "libro_tag");
            RenameColumn(table: "dbo.libro_tag", name: "Tag_tagId", newName: "tagId");
            RenameColumn(table: "dbo.libro_tag", name: "Libro_isbn", newName: "isbn");
            RenameIndex(table: "dbo.libro_tag", name: "IX_Libro_isbn", newName: "IX_isbn");
            RenameIndex(table: "dbo.libro_tag", name: "IX_Tag_tagId", newName: "IX_tagId");
            DropPrimaryKey("dbo.libro_tag");
            AddPrimaryKey("dbo.libro_tag", new[] { "isbn", "tagId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.libro_tag");
            AddPrimaryKey("dbo.libro_tag", new[] { "Tag_tagId", "Libro_isbn" });
            RenameIndex(table: "dbo.libro_tag", name: "IX_tagId", newName: "IX_Tag_tagId");
            RenameIndex(table: "dbo.libro_tag", name: "IX_isbn", newName: "IX_Libro_isbn");
            RenameColumn(table: "dbo.libro_tag", name: "isbn", newName: "Libro_isbn");
            RenameColumn(table: "dbo.libro_tag", name: "tagId", newName: "Tag_tagId");
            RenameTable(name: "dbo.libro_tag", newName: "TagLibro");
        }
    }
}
