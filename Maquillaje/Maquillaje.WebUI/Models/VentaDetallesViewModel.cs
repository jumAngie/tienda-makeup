using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class VentaDetallesViewModel
    {
        [Display(Name = "ID")]
        public int vde_Id { get; set; }

        [Display(Name = "Venta")]
        public int vde_VentaId { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "*")]
        public int vde_Producto { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "*")]
        public int vde_Cantidad { get; set; }
        public int? vde_UsuCrea { get; set; }
        public DateTime? vde_FechaCrea { get; set; }
        public int? vde_UsuModi { get; set; }
        public DateTime? vde_FechaModi { get; set; }
        public bool? vde_Estado { get; set; }


        [Display(Name = "Categoría")]
        public virtual tbCategorias cate { get; set; }

        [NotMapped]
        public string esEditar { get; set; }
    }
}
