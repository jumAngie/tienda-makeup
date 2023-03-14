using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class EstadosCivilesViewModel
    {
        [Display(Name = "ID")]
        public int est_ID { get; set; }

        [Display(Name = "Descripcion")]
        public string est_Descripcion { get; set; }
    }
}
