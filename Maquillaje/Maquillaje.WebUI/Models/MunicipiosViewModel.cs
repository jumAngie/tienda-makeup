using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class MunicipiosViewModel
    {
        [Display(Name = "ID")]
        public int mun_ID { get; set; }

        [Display(Name = "Departamento")]
        public string mun_depID { get; set; }

        [Display(Name = "Municipio")]
        public string mun_Descripcion { get; set; }


        //AUDITORIA

        [Display(Name = "Usuario Creación")]
        public string mun_UsuarioCrea { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime? mun_FechaCrea { get; set; }

        [Display(Name = "Usuario Modificación")]
        public string mun_UsuarioModi { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime? mun_FechaModi { get; set; }
    }
}
