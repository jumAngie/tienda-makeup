using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class VentasViewModel
    {
        [Display(Name = "ID")]
        public int ven_Id { get; set; }

        [Display(Name = "Cliente")]

        public string ven_Cliente { get; set; }

        [Display(Name = "Empleado")]

        public string ven_Empleado { get; set; }

        [Display(Name = "Fecha")]

        public DateTime? ven_Fecha { get; set; }

        [Display(Name = "Sucursal")]

        public string suc_Descripcion { get; set; }

        [Display(Name = "Metodo de Pago")]

        public string met_Descripcion { get; set; }
    }
}
