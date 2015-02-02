using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Autor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int autorId {get; set;}
        public String nombres { get; set; }
        public String apellidos { get; set; }
        public String nacionalidad { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }

    }
}