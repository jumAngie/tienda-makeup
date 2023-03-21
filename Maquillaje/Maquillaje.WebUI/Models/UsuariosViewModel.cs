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


        [Display(Name = "Usuario Creación")]
        public string usu_UsuarioCrea { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime? usu_FechaCrea { get; set; }

        [Display(Name = "Usuario Modificación")]
        public string usu_UsuarioModi { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime? usu_FechaModi { get; set; }
    }
}
