using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class MetodoPagoViewModel
    {
        [Display(Name = "ID")]
        public int met_Id { get; set; }

        [Display(Name = "Descripcion")]
        public string met_Descripcion { get; set; }
    }
}
