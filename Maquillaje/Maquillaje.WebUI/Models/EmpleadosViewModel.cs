using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class EmpleadosViewModel
    {

        [Display(Name = "ID")]
        public int emp_ID { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "*")]
        public string emp_Nombre { get; set; }


        [Display(Name = "Identidad")]
        [Required(ErrorMessage = "*")]
        public string emp_DNI { get; set; }
        [Display(Name = "F. Nacimiento")]
        [Required(ErrorMessage = "*")]
        public DateTime emp_FechaNacimiento { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "*")]
        public string emp_Sexo { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "*")]
        public string emp_Telefono { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "*")]
        public string emp_Municipio { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "*")]
        public string emp_Correo { get; set; }

        [Display(Name = "Estados Civiles")]
        [Required(ErrorMessage = "*")]
        public string emp_EstadoCivil { get; set; }

        [Display(Name = "Sucursal")]
        [Required(ErrorMessage = "*")]
        public string emp_Sucursal { get; set; }


        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "*")]
        public string emp_Apellido { get; set; }


        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "*")]
        public string depto { get; set; }
    }
}
