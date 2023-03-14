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
    }
}
