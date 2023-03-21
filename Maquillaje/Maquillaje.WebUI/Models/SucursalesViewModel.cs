using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class SucursalesViewModel
    {
        [Display(Name = "ID")]
        public int suc_Id { get; set; }

        [Display(Name = "Sucursal")]
        public string suc_Descripcion { get; set; }

        [Display(Name = "Municipio")]
        public string suc_Municipio { get; set; }


        //AUDITORIA

        [Display(Name = "Usuario Creación")]
        public string suc_UsuCrea { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime? suc_FechaCrea { get; set; }

        [Display(Name = "Usuario Modificación")]
        public string suc_UsuModi { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime? suc_FechaModi { get; set; }
    }
}
