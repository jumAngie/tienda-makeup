using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories.Maqui
{
    public class VentasRepository : IRepository<tbVentas>
    {
        public int IdVentaReciente()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var registro = db.ExecuteScalar<int>(ScriptsDataBase.IdVentaReciente, null, commandType: CommandType.StoredProcedure);
            
            return registro;
        }


        public int EliminarDetalleVenta(int? @vde_Id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@vde_Id", @vde_Id, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.EliminarDetalleVenta, parametros, commandType: CommandType.StoredProcedure);

        }
        public int ActualizarDetalleVenta(int? @vde_Id, int? @vde_Producto , int? @vde_Cantidad , int @vde_UsuModi )
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@vde_Id", @vde_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_Producto", @vde_Producto, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_Cantidad", @vde_Cantidad, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_UsuModi", @vde_UsuModi, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.ActualizarDetalleVenta, parametros, commandType: CommandType.StoredProcedure);
        }

        public int IngresarNuevoDetalleVenta(int? @vde_VentaId, int? @vde_Producto, int? @vde_Cantidad, int @vde_UsuCrea)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@vde_VentaId", @vde_VentaId, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_Producto", @vde_Producto, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_Cantidad", @vde_Cantidad, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_UsuCrea", @vde_UsuCrea, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.IngresarNuevoDetalleVenta, parametros, commandType: CommandType.StoredProcedure);
        }

        public int IngresarNuevaVenta(int? clie_id, int empleado, int sucursal, int MetodoPago, int UsuarioCrea)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@ven_Cliente",      clie_id,     DbType.Int32, ParameterDirection.Input);
            parametros.Add("@ven_Empleado",     empleado,   DbType.Int32, ParameterDirection.Input);
            parametros.Add("@ven_Sucursal",     sucursal, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@ven_MetodoPago",   MetodoPago, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@ven_UsuCrea",      UsuarioCrea, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.IngresarNuevaVenta, parametros, commandType: CommandType.StoredProcedure);
        }
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbVentas item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@ven_Id", item.ven_Id, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.VentasEliminar, parametros, commandType: CommandType.StoredProcedure);


        }

        /// 

        public IEnumerable<VW_tbVentas_List> ListView()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);

            return db.Query<VW_tbVentas_List>(ScriptsDataBase.UDP_Listar_Facturas, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbVentasDetalles_List> ListView(int id)
        {
            var db = new SqlConnection(TiendaContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@vde_VentaId", id, DbType.Int32, ParameterDirection.Input);

            return db.Query<VW_tbVentasDetalles_List>(ScriptsDataBase.UDP_Listar_VentasDetalles, parametros, commandType: CommandType.StoredProcedure);
        }

        public tbVentas Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbVentas.Find(id);

            return result;
        }

        public int Insert(tbVentas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_Maqui_tbVentas_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Maqui_tbVentas_LIST.ToList();
            return Listado;
        }

        public int Update(tbVentas item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbVentas> IRepository<tbVentas>.List()
        {
            throw new NotImplementedException();
        }
    }
}
