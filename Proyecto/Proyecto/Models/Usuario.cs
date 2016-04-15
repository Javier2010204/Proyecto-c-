using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Display(Name = "Nombre"), Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string nombre { get; set; }
        [Display(Name = "Correo"), Required(ErrorMessage = "El correo es un campo obligatorio"),
                                DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un correo valido")]
        public string correo { get; set; }
        [Display(Name = "Direccion")]
        public string direccion { get; set; }
        [Display(Name = "Telefono"), StringLength(12, MinimumLength = 8, ErrorMessage = "El telefono debe contener 8 o 12 caracteres"),
                                    Required(ErrorMessage = "El campo telefono es obligatorio")]
        public string telefono { get; set; }

        [Display(Name = "Contraseña"), DataType(DataType.Password), Required(ErrorMessage = "El campo contraseña es obligatorio")]
        public string contraseña { get; set; }
        [Compare("contraseña", ErrorMessage = "La contraseñas no son iguales"), DataType(DataType.Password)]
        public string confirmarContraseña { get; set; }

        public virtual Rol rol { get; set; }

        public virtual List<Compra> compras { get; set; }
    }
}