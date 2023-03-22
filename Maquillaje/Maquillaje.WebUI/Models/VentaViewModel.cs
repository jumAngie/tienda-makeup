using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class VentaViewModel
    {
        [Display(Name = "ID")]
        public int ven_Id { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "*")]
        public int ven_Cliente { get; set; }
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "*")]
        public string cliente { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "*")]
        public int ven_Empleado { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "*")]
        public string empleado { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "*")]
        public DateTime? ven_Fecha { get; set; }

        [Display(Name = "Sucursal")]
        public int ven_Sucursal { get; set; }

        [Display(Name = "Método de pago")]
        [Required(ErrorMessage = "*")]
        public int ven_MetodoPago { get; set; }
        [Display(Name = "Método de pago")]
        [Required(ErrorMessage = "*")]
        public string metodo { get; set; }

        [Display(Name = "Usuario Creación")]
        public int? ven_UsuCrea { get; set; }


        [Display(Name = "Usuario Creación")]
        public string crea { get; set; }


        [Display(Name = "Fecha Creación")]
        public DateTime? ven_FechaCrea { get; set; }


        [Display(Name = "Usuario Modificación")]
        public int? ven_UsuModi { get; set; }


        [Display(Name = "Usuario Modificación")]
        public string modi { get; set; }


        [Display(Name = "Fecha Modficación")]
        public DateTime? ven_FechaModi { get; set; }


        [Display(Name = "Estado")]
        public bool? ven_Estado { get; set; }

        public virtual tbClientes clie { get; set; }
        public virtual tbEmpleados empe { get; set; }
        public virtual tbMetodoPago meto { get; set; }
        public virtual tbCategorias cate { get; set; }
    }
}

