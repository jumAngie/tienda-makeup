using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories
{
    public class ProductosRepository : IRepository<tbProductos>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbProductos item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@pro_Id", item.pro_Id, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.ProductosEliminar, parametros, commandType: CommandType.StoredProcedure);


        }




        public tbProductos Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbProductos.Find(id);

            return result;
        }

        

        public int Insertar(string pro_Codigo, string pro_Nombre, string pro_StockInicial, decimal pro_PrecioUnitario, 
                            int pro_Proveedor, int pro_usuCrea, int pro_Categoria)
        {
            pro_usuCrea = 1;
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@pro_Codigo",         pro_Codigo,           DbType.String,  ParameterDirection.Input);
            parametros.Add("@pro_Nombre",         pro_Nombre,           DbType.String,  ParameterDirection.Input);
            parametros.Add("@pro_StockInicial",   pro_StockInicial,     DbType.String,  ParameterDirection.Input);
            parametros.Add("@pro_PrecioUnitario", pro_PrecioUnitario,   DbType.Decimal, ParameterDirection.Input);
            parametros.Add("@pro_Proveedor",      pro_Proveedor,        DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@pro_usuCrea",        pro_usuCrea,          DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@pro_Categoria",      pro_Categoria,        DbType.Int32,   ParameterDirection.Input);


            return db.Execute(ScriptsDataBase.ProductosCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public int Actualizar(int pro_Id, string pro_Codigo, string pro_Nombre, string pro_StockInicial, decimal pro_PrecioUnitario,
                           int pro_Proveedor, int pro_usuCrea, int pro_Categoria)
        {
            pro_usuCrea = 1;
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@pro_Id",               pro_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@pro_Codigo",           pro_Codigo, DbType.String, ParameterDirection.Input);
            parametros.Add("@pro_Nombre",           pro_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@pro_StockInicial",     pro_StockInicial, DbType.String, ParameterDirection.Input);
            parametros.Add("@pro_PrecioUnitario",   pro_PrecioUnitario, DbType.Decimal, ParameterDirection.Input);
            parametros.Add("@pro_Proveedor",        pro_Proveedor, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@pro_usuCrea",          pro_usuCrea, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@pro_Categoria",        pro_Categoria, DbType.Int32, ParameterDirection.Input);


            return db.Execute(ScriptsDataBase.ProductosEditar, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vw_Maqui_tbProductos_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Maqui_tbProductos_LIST.ToList();
            return Listado;
        }

        public int Update(tbProductos item)
        {
            throw new NotImplementedException();
        }
        public int Insert(tbProductos item)
        {
            throw new NotImplementedException();
        }
        IEnumerable<tbProductos> IRepository<tbProductos>.List()
        {
            throw new NotImplementedException();
        }
    }
}
