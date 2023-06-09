﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class tbEmpleados
    {
        public tbEmpleados()
        {
            tbUsuarios = new HashSet<tbUsuarios>();
            tbVentas = new HashSet<tbVentas>();
        }

        public int emp_ID { get; set; }
        public string emp_Nombre { get; set; }
        public string emp_Apellido { get; set; }
        public string emp_DNI { get; set; }
        public DateTime emp_FechaNacimiento { get; set; }
        public string emp_Sexo { get; set; }
        public string emp_Telefono { get; set; }
        public int emp_Municipio { get; set; }
        public string emp_Correo { get; set; }
        public int emp_EstadoCivil { get; set; }
        public int emp_Sucursal { get; set; }
        public int emp_UsuarioCrea { get; set; }
        public DateTime? emp_FechaCrea { get; set; }
        public int? emp_UsuarioModi { get; set; }
        public DateTime? emp_FechaModi { get; set; }
        public bool? emp_Estado { get; set; }

        public virtual tbEstadosCiviles emp_EstadoCivilNavigation { get; set; }
        public virtual tbMunicipios emp_MunicipioNavigation { get; set; }
        public virtual tbSucursales emp_SucursalNavigation { get; set; }
        public virtual tbUsuarios emp_UsuarioCreaNavigation { get; set; }
        public virtual tbUsuarios emp_UsuarioModiNavigation { get; set; }
        public virtual ICollection<tbUsuarios> tbUsuarios { get; set; }
        public virtual ICollection<tbVentas> tbVentas { get; set; }
    }
}