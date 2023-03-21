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

        //AUDITORIA

        [Display(Name = "Usuario Creación")]
        public string est_UsuarioCrea { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime? est_FechaCrea { get; set; }

        [Display(Name = "Usuario Modificación")]
        public string est_UsuarioModi { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime? est_FechaModi { get; set; }
    }
}
