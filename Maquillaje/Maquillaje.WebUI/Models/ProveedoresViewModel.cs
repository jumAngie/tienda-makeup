using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class ProveedoresViewModel
    {
        [Display(Name = "ID")]
        public int prv_ID { get; set; }


        [Display(Name = "Nombre Compañía")]
        [Required(ErrorMessage = "*")]
        public string prv_NombreCompañia { get; set; }

        [Display(Name = "Nombre Contacto")]
        [Required(ErrorMessage = "*")]
        public string prv_NombreContacto { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "*")]
        public string prv_TelefonoContacto { get; set; }

        [Display(Name = "Direccion Empresa")]
        [Required(ErrorMessage = "*")]
        public string prv_DireccionEmpresa { get; set; }

        [Display(Name = "Direccion Contacto")]
        [Required(ErrorMessage = "*")]
        public string prv_DireccionContacto { get; set; }

        [Display(Name = "Sexo Contacto")]
        [Required(ErrorMessage = "*")]
        public string prv_SexoContacto { get; set; }
    }
}
