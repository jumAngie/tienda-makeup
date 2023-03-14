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

        public string emp_Nombre { get; set; }


        [Display(Name = "Identidad")]

        public string emp_DNI { get; set; }
        [Display(Name = "F. Nacimiento")]

        public DateTime emp_FechaNacimiento { get; set; }

        [Display(Name = "Sexo")]

        public string emp_Sexo { get; set; }

        [Display(Name = "Teléfono")]

        public string emp_Telefono { get; set; }

        [Display(Name = "Municipio")]

        public int emp_Municipio { get; set; }

        [Display(Name = "Correo")]

        public string emp_Correo { get; set; }

        [Display(Name = "Estados Civiles")]

        public int emp_EstadoCivil { get; set; }

        [Display(Name = "Sucursal")]

        public int emp_Sucursal { get; set; }
    }
}
