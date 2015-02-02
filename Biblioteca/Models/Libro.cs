using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Libro
    {   
        [Key] public String isbn { get; set; }
        public String titulo { get; set; }
        public int GeneroId { get; set; }
        public Genero genero { get; set; }
        public String descripcion { get; set; }

        public virtual ICollection<Autor> Autores {get; set;}
        public virtual ICollection<Tag> Tags { get; set; }

    }

}