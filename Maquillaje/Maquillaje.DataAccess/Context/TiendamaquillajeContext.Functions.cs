﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Maquillaje.DataAccess.Context;

namespace Maquillaje.DataAccess.Context
{
    public partial class TiendamaquillajeContext
    {

        [DbFunction("UDF_Gral_tbClienteInfo_DDL", "dbo")]
        public IQueryable<UDF_Gral_tbClienteInfo_DDLResult> UDF_Gral_tbClienteInfo_DDL(int? id)
        {
            return FromExpression(() => UDF_Gral_tbClienteInfo_DDL(id));
        }

        [DbFunction("UDF_Gral_tbEmpleadoInfo_DDL", "dbo")]
        public IQueryable<UDF_Gral_tbEmpleadoInfo_DDLResult> UDF_Gral_tbEmpleadoInfo_DDL(int? id)
        {
            return FromExpression(() => UDF_Gral_tbEmpleadoInfo_DDL(id));
        }

        [DbFunction("UDF_Gral_tbMunicipio_DDL", "dbo")]
        public IQueryable<UDF_Gral_tbMunicipio_DDLResult> UDF_Gral_tbMunicipio_DDL(int? depto)
        {
            return FromExpression(() => UDF_Gral_tbMunicipio_DDL(depto));
        }

        [DbFunction("UDF_Gral_tbMunicipios_CARGAR", "dbo")]
        public IQueryable<UDF_Gral_tbMunicipios_CARGARResult> UDF_Gral_tbMunicipios_CARGAR(int? mun_Id)
        {
            return FromExpression(() => UDF_Gral_tbMunicipios_CARGAR(mun_Id));
        }

        [DbFunction("UDF_Gral_tbSucursales_DDL", "dbo")]
        public IQueryable<UDF_Gral_tbSucursales_DDLResult> UDF_Gral_tbSucursales_DDL(int? id)
        {
            return FromExpression(() => UDF_Gral_tbSucursales_DDL(id));
        }

        [DbFunction("UDF_tbDetallesVentas_CargarDetalleVentaPorId", "dbo")]
        public IQueryable<UDF_tbDetallesVentas_CargarDetalleVentaPorIdResult> UDF_tbDetallesVentas_CargarDetalleVentaPorId(int? vde_Id)
        {
            return FromExpression(() => UDF_tbDetallesVentas_CargarDetalleVentaPorId(vde_Id));
        }

        [DbFunction("UDF_tbProductos_CargarStockProductoPorId", "Maqui")]
        public IQueryable<UDF_tbProductos_CargarStockProductoPorIdResult> UDF_tbProductos_CargarStockProductoPorId(int? pro_Id)
        {
            return FromExpression(() => UDF_tbProductos_CargarStockProductoPorId(pro_Id));
        }

        [DbFunction("UDF_tbProductos_ListarProductoPorId", "dbo")]
        public IQueryable<UDF_tbProductos_ListarProductoPorIdResult> UDF_tbProductos_ListarProductoPorId(int? pro_Id)
        {
            return FromExpression(() => UDF_tbProductos_ListarProductoPorId(pro_Id));
        }

        [DbFunction("UDF_tbVentas_ListarDetallesPorIdVenta", "Maqui")]
        public IQueryable<UDF_tbVentas_ListarDetallesPorIdVentaResult> UDF_tbVentas_ListarDetallesPorIdVenta(int? ven_Id)
        {
            return FromExpression(() => UDF_tbVentas_ListarDetallesPorIdVenta(ven_Id));
        }

        protected void OnModelCreatingGeneratedFunctions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UDF_Gral_tbClienteInfo_DDLResult>().HasNoKey();
            modelBuilder.Entity<UDF_Gral_tbEmpleadoInfo_DDLResult>().HasNoKey();
            modelBuilder.Entity<UDF_Gral_tbMunicipio_DDLResult>().HasNoKey();
            modelBuilder.Entity<UDF_Gral_tbMunicipios_CARGARResult>().HasNoKey();
            modelBuilder.Entity<UDF_Gral_tbSucursales_DDLResult>().HasNoKey();
            modelBuilder.Entity<UDF_tbDetallesVentas_CargarDetalleVentaPorIdResult>().HasNoKey();
            modelBuilder.Entity<UDF_tbProductos_CargarStockProductoPorIdResult>().HasNoKey();
            modelBuilder.Entity<UDF_tbProductos_ListarProductoPorIdResult>().HasNoKey();
            modelBuilder.Entity<UDF_tbVentas_ListarDetallesPorIdVentaResult>().HasNoKey();
        }
    }
}
