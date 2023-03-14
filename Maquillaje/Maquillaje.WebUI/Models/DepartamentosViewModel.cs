using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class DepartamentosViewModel
    {
        [Display(Name = "ID")]
        public int dep_ID { get; set; }

        [Display(Name = "DEscripcion")]
        public string dep_Descripcion { get; set; }
    }
}
