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
        
        public int EliminarDetalleVenta(int? @vde_Id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@vde_Id", @vde_Id, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.EliminarDetalleVenta, parametros, commandType: CommandType.StoredProcedure);

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

        public int Update(tbVentasDetalle item)
        {
            var db = new SqlConnection(TiendaContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@vde_Id",                   item.vde_Id,        DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_Producto",             item.vde_Producto,  DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_Cantidad",             item.vde_Cantidad,  DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_UsuModi",             item.vde_UsuModi,    DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Editar_FacturasDetalles, parametros, commandType: CommandType.StoredProcedure);
        }

        public int DeleteConfirmed(int id)
        {
            var db = new SqlConnection(TiendaContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@vde_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Eliminar_FacturasDetalles, parametros, commandType: CommandType.StoredProcedure);
        }


        public int Insert(tbVentasDetalle item)
        {
            var db = new SqlConnection(TiendaContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@vde_VentaId",  item.vde_VentaId, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_Producto", item.vde_Producto, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_Cantidad", item.vde_Cantidad, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@vde_UsuCrea",  item.vde_UsuCrea, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Insertar_FacturasDetalles, parametros, commandType: CommandType.StoredProcedure);
        }

        public int Insert(tbVentas item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            
            var parametros = new DynamicParameters();

            parametros.Add("@ven_Cliente", item.ven_Cliente, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@ven_Empleado", item.ven_Empleado, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@ven_Sucursal", item.ven_Sucursal, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@ven_MetodoPago", item.ven_MetodoPago, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@ven_UsuCrea", item.ven_UsuCrea, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Insertar_Facturas, parametros, commandType: CommandType.StoredProcedure);

        }

        public int RevisarStock(int id, int cantidad)
        {
            var db = new SqlConnection(TiendaContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@inv_Cantidad", cantidad, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@inv_Producto", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_RevisarStock, parametros, commandType: CommandType.StoredProcedure);
        }

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

        public dynamic[] Detalles(int vde_Id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@ID", vde_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst(ScriptsDataBase.VentasDetalles, parametro, commandType: CommandType.StoredProcedure);
            dynamic[] resultado = new dynamic[9];
            resultado[0] = result.ven_Id;
            resultado[1] = result.ven_Cliente.ToString();
            resultado[2] = result.ven_Empleado.ToString();
            resultado[3] = result.ven_Fecha;
            resultado[4] = result.ven_UsuCrea;
            resultado[5] = result.ven_UsuModi;
            resultado[6] = result.ven_FechaCrea;
            resultado[7] = result.ven_FechaModi;
            resultado[8] = result.met_Descripcion;




            return resultado;
        }



        public tbVentas Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbVentas.Find(id);

            return result;
        }

        public int Insertar(tbVentas item)
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
