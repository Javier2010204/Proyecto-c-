using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        [Display(Name = "Nombre"), Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string nombre { get; set; }
        [Display(Name = "Descripcion"), Required(ErrorMessage = "La descripcion es un campo obligatorio")]
        public string descripcion { get; set; }

        public virtual List<Usuario> usuarios { get; set; }
    }
}