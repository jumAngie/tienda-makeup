using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class ClientesViewModel
    {
        [Display(Name = "ID")]
        public int cli_ID { get; set; }

        [Display(Name = "Nombre")]
        public string cli_Nombre { get; set; }

        [Display(Name = "Identidad")]

        public string cli_DNI { get; set; }

        [Display(Name = "F. Nacimiento")]

        public Date cli_FechaNacimiento { get; set; }

        [Display(Name = "Sexo")]

        public string cli_sexo { get; set; }

        [Display(Name = "Teléfono")]

        public string cli_Telefono { get; set; }

        [Display(Name = "Municipio")]

        public string cli_Municipio { get; set; }

        [Display(Name = "Estado Civil")]

        public string cli_EstadoCivil { get; set; }

        [Display(Name = "Apellido")]
        public string cli_Apellido { get; set; }
        [Display(Name = "Sexo")]
        public string cli_Sexo { get; set; }
    }
}
