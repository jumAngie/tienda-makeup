using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class CategoriaViewModel
    {
        [Display(Name = "ID")]
        public int cat_Id { get; set; }

        [Display(Name = "Descripción")]
        public string cat_Descripcion { get; set; }

        //AUDITORIA

        [Display(Name = "Usuario Creación")]
        public string cat_UsuCrea { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime cat_FechaCrea { get; set; }

        [Display(Name = "Usuario Modificación")]
        public string cat_UsuModi { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime cat_FechaModi { get; set; }
    }
}
