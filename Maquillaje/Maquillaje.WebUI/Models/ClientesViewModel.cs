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
        [Required(ErrorMessage = "*")]
        public string cli_Nombre { get; set; }

        [Display(Name = "Identidad")]
        [Required(ErrorMessage = "*")]

        public string cli_DNI { get; set; }

        [Display(Name = "F. Nacimiento")]
        [Required(ErrorMessage = "*")]

        public DateTime cli_FechaNacimiento { get; set; }

        [Display(Name = "Sexo")]
        public string cli_sexo { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "*")]

        public string cli_Telefono { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "*")]

        public string cli_Municipio { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "*")]
        public string depto { get; set; }

        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "*")]

        public string cli_EstadoCivil { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "*")]
        public string cli_Apellido { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "*")]
        public string cli_Sexo { get; set; }
    }
}
