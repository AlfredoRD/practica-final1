using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Almacen23.Models
{
    public class Cliente
    {
        [Required]
        [Display(Name = "Ingresar nombre")]

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public decimal Telefono { get; set; }
        public string Correo { get; set; }
        public string Tipo_de_Clientw { get; set; }
    }
}