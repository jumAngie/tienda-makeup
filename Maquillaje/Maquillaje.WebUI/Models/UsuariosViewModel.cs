using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class UsuariosViewModel
    {
        [Display(Name = "ID")]
        public int usu_ID { get; set; }

        [Display(Name = "Usuario")]
        public string usu_Usuario { get; set; }

        [Display(Name = "Empleado")]
        public string Empleado { get; set; }

        [Display(Name = "Admin")]
        public bool usu_EsAdmin { get; set; }
    }
}
