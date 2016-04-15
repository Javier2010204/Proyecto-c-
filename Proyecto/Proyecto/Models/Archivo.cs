using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Archivo
    {
        [Key]
        public int idArchivo { get; set; }
        public string nombre { get; set; }
        public string contentType { get; set; }
        public FileType tipo { get; set; }
        public Byte[] contenido { get; set; }
        public virtual Automovil automovil { get; set; }
    }
}