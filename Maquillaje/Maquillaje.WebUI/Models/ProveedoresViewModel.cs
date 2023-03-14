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


        [Display(Name = "Compañía")]
        public string prv_NombreCompañia { get; set; }

        [Display(Name = "Contacto")]
        public string prv_NombreContacto { get; set; }

        [Display(Name = "Telefono")]
        public string prv_TelefonoContacto { get; set; }

        [Display(Name = "Municipio")]
        public string prv_Municipio { get; set; }

        [Display(Name = "Direccion Empresa")]
        public string prv_DireccionEmpresa { get; set; }

        [Display(Name = "Direccion Contacto")]
        public string prv_DireccionContacto { get; set; }

        [Display(Name = "Sexo Contacto")]
        public string prv_SexoContacto { get; set; }
    }
}
