using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Tag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tagId { get; set; }
        public String descripcion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }

}