using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Modelo
    {
        [Key]
        public int idModelo { get; set; }
        [Display(Name = "Nombre"), Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }
        public virtual List<Automovil> automovil { get; set; }
    }
}