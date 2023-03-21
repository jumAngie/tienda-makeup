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

        //AUDITORIA

        [Display(Name = "Usuario Creación")]
        public string met_UsuCrea { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime? met_FechaCrea { get; set; }

        [Display(Name = "Usuario Modificación")]
        public string met_UsuModi { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime? met_FechaModi { get; set; }
    }
}
