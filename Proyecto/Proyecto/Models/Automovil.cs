using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Automovil
    {
        [Key]
        public int idAutomovil { get; set; }
        [Display(Name = "Precio"), Required(ErrorMessage = "El campo es obligatorio")]
        public Decimal precio { get; set; }
        [Display(Name = "Color")]
        public string color { get; set; }
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
        [Display(Name = "Estado")]
        public string estado { get; set; }

        public string transmision { get; set; }

        public int idMarca { get; set; }
        public int idModelo { get; set; }
        public int idCombustible{get;set;}
       
        public virtual Marca marca { get; set; }
        public virtual Modelo modelo { get; set; }
        public virtual Combustible combustible { get; set; }

        public virtual List<Archivo> archivos { get; set; }

    }
}