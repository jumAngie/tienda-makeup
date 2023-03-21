using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class ProductosViewModel
    {
        [Display(Name = "Producto ID")]
       
        public int pro_Id { get; set; }

        [Display(Name = "Producto Codigo")]
        [Required(ErrorMessage = "*")]
        public string pro_Codigo { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "*")]
        public string pro_Nombre { get; set; }

        [Display(Name = "Stock Inicial")]
        [Required(ErrorMessage = "*")]
        public string pro_StockInicial { get; set; }

        [Display(Name = "Precio Unitario")]
        [Required(ErrorMessage = "*")]
        public decimal? pro_PrecioUnitario { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "*")]
        public string cat_Descripcion { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "*")]
        public int pro_Categoria { get; set; }


        [Display(Name = "Empresa")]
        public string prv_NombreCompañia { get; set; }

        [Display(Name = "Proveedor")]
        public string pro_Proveedor { get; set; }


        //AUDITORIA

        [Display(Name = "Usuario Creación")]
        public string pro_usuCrea { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime? pro_FechaCrea { get; set; }

        [Display(Name = "Usuario Modificación")]
        public string pro_UsuModi { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime? pro_FechaModi { get; set; }
    }
}
