using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Biblioteca.DAL
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext() : base("biblioteca") { }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /* creacion de relaciones m2m */
            
            // LIBRO *<=>* AUTOR
            modelBuilder.Entity<Libro>()
                .HasMany<Autor>(l => l.Autores)
                .WithMany(a => a.Libros)
                .Map(t => {
                    t.MapLeftKey("isbn");
                    t.MapRightKey("autorId");
                    t.ToTable("libro_autor");
                });

            // LIBRO *<==>* TAG
            modelBuilder.Entity<Libro>()
                .HasMany<Tag>(l => l.Tags)
                .WithMany(t => t.Libros)
                .Map(t => {
                    t.MapLeftKey("isbn");
                    t.MapRightKey("tagId");
                    t.ToTable("libro_tag");
                });
            
        }

    }
}