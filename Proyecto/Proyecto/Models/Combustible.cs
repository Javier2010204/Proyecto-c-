using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Combustible
    {
        [Key]
        public int idCombustible { get; set; }
        [Display(Name = "Nombre"), Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string nombre { get; set; }
        public virtual List<Automovil> automoviles { get; set; }
    }
}