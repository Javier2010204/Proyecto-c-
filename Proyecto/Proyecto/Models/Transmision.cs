using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Transmision
    {
        [Key]
        public int idTransmision { get; set; }
        [Display(Name = "Nombre"), Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }
        
    }
}