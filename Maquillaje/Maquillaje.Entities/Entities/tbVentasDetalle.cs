﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class tbVentasDetalle
    {
        public int vde_Id { get; set; }
        public int vde_VentaId { get; set; }
        public int vde_Producto { get; set; }
        public int vde_Cantidad { get; set; }
        public int? vde_UsuCrea { get; set; }
        public DateTime? vde_FechaCrea { get; set; }
        public int? vde_UsuModi { get; set; }
        public DateTime? vde_FechaModi { get; set; }
        public bool? vde_Estado { get; set; }

        public virtual tbProductos vde_ProductoNavigation { get; set; }
        public virtual tbUsuarios vde_UsuCreaNavigation { get; set; }
        public virtual tbUsuarios vde_UsuModiNavigation { get; set; }
        public virtual tbVentas vde_Venta { get; set; }
    }
}