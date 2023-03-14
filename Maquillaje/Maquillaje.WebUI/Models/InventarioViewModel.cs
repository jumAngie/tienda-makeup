using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class InventarioViewModel
    {
        [Display(Name = "ID")]
        public int inv_Id { get; set; }

        [Display(Name = "Articulo")]
        public string pro_Nombre { get; set; }

        [Display(Name = "Cantidad")]
        public int inv_Cantidad { get; set; }
    }
}
