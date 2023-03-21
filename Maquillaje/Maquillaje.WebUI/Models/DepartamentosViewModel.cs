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



        [Display(Name = "Usuario Creación")]
        public string dep_UsuarioCrea { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime? dep_FechaCrea { get; set; }

        [Display(Name = "Usuario Modificación")]
        public string dep_UsuarioModi { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime? dep_FechaModi { get; set; }
    }
}
