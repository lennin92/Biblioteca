using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public partial class Genero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GeneroId { get; set; }
        public String Titulo { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }

}