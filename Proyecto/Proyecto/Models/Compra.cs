using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Compra
    {
        [Key]
        public int idCompra { get; set; }
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }
        public virtual List<Automovil> automoviles { get; set; }
    }
}