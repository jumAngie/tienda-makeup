﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class tbEstadosCiviles
    {
        public tbEstadosCiviles()
        {
            tbClientes = new HashSet<tbClientes>();
            tbEmpleados = new HashSet<tbEmpleados>();
        }

        public int est_ID { get; set; }
        public string est_Descripcion { get; set; }
        public int est_UsuarioCrea { get; set; }
        public DateTime? est_FechaCrea { get; set; }
        public int? est_UsuarioModi { get; set; }
        public DateTime? est_FechaModi { get; set; }

        public virtual tbUsuarios est_UsuarioCreaNavigation { get; set; }
        public virtual tbUsuarios est_UsuarioModiNavigation { get; set; }
        public virtual ICollection<tbClientes> tbClientes { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
    }
}