using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories.Gral
{
    public class SucursalesRepository : IRepository<tbSucursales>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbSucursales item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@suc_Id", item.suc_Id, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.SucursalesEliminar, parametros, commandType: CommandType.StoredProcedure);

        }

        public tbSucursales Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbSucursales.Find(id);

            return result;
        }

        public int Insert(tbSucursales item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@suc_Descripcion", item.suc_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@suc_Municipio", item.suc_Municipio, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@suc_UsuCrea", item.suc_UsuCrea, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.SucursalesCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vw_Gral_tbSucursales_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbSucursales_LIST.ToList();
            return Listado;
        }



        public dynamic[] Detalles(int suc_Id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@ID", suc_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst(ScriptsDataBase.SucursalesDetalles, parametro, commandType: CommandType.StoredProcedure);
            dynamic[] resultado = new dynamic[7];
            resultado[0] = result.suc_Id;
            resultado[1] = result.suc_Municipio;
            resultado[2] = result.suc_Descripcion;
            resultado[3] = result.suc_UsuCrea;
            resultado[4] = result.suc_UsuModi;
            resultado[5] = result.suc_FechaCrea;
            resultado[6] = result.suc_FechaModi;


            return resultado;
        }


        public int Update(tbSucursales item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@suc_Id", item.suc_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@suc_Descripcion", item.suc_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@suc_Municipio", item.suc_Municipio, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@suc_UsuCrea", item.suc_UsuCrea, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.SucursalesEditar, parametros, commandType: CommandType.StoredProcedure);
        }

        IEnumerable<tbSucursales> IRepository<tbSucursales>.List()
        {
            throw new NotImplementedException();
        }
    }
}
