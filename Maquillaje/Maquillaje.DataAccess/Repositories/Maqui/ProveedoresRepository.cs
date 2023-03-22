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
    public class ProveedoresRepository : IRepository<tbProveedores>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbProveedores item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@prv_Id", item.prv_ID, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prv_UsuModi", item.prv_UsuarioModi, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.ProveedoresEliminar, parametros, commandType: CommandType.StoredProcedure);


        }


        public dynamic[] Detalles(int prv_Id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@ID", prv_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst(ScriptsDataBase.ProveedoresDetalles, parametro, commandType: CommandType.StoredProcedure);
            dynamic[] resultado = new dynamic[12];
            resultado[0] = result.prv_ID;
            resultado[1] = result.prv_NombreCompañia;
            resultado[2] = result.prv_NombreContacto;
            resultado[3] = result.prv_TelefonoContacto;
            resultado[4] = result.prv_DireccionEmpresa;
            resultado[5] = result.prv_TelefonoContacto;
            resultado[6] = result.prv_SexoContacto;
            resultado[7] = result.prv_UsuarioCrea;
            resultado[8] = result.prv_UsuarioModi;
            resultado[9] = result.prv_FechaCrea;
            resultado[10] = result.prv_FechaModi;

            return resultado;
        }






        public tbProveedores Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbProveedores.Find(id);

            return result;
        }

        public int Insertar(string prv_NombreCompañia, string prv_NombreContacto, string prv_TelefonoContacto,
                            string prv_DireccionEmpresa, string prv_DireccionContacto, string prv_SexoContacto, int prv_UsuarioCrea)
        {
            //QUITAR
            prv_UsuarioCrea = 1;
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@prv_NombreCompañia",       prv_NombreCompañia,         DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_NombreContacto",       prv_NombreContacto,         DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_TelefonoContacto",     prv_TelefonoContacto,       DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_DireccionEmpresa",     prv_DireccionEmpresa,       DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_DireccionContacto",    prv_DireccionContacto,      DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_SexoContacto",         prv_SexoContacto,           DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_UsuarioCrea",          prv_UsuarioCrea,            DbType.Int32, ParameterDirection.Input);


            return db.Execute(ScriptsDataBase.ProveedoresCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public int Actualizar(int prv_ID, string prv_NombreCompañia, string prv_NombreContacto, string prv_TelefonoContacto,
                            string prv_DireccionEmpresa, string prv_DireccionContacto, string prv_SexoContacto, int prv_UsuarioCrea)
        {
            //QUITAR
            prv_UsuarioCrea = 1;
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@prv_ID",                   prv_ID,                 DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prv_NombreCompañia",       prv_NombreCompañia,     DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_NombreContacto",       prv_NombreContacto,     DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_TelefonoContacto",     prv_TelefonoContacto,   DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_DireccionEmpresa",     prv_DireccionEmpresa,   DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_DireccionContacto",    prv_DireccionContacto,  DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_SexoContacto",         prv_SexoContacto,       DbType.String, ParameterDirection.Input);
            parametros.Add("@prv_UsuarioCrea",          prv_UsuarioCrea,        DbType.Int32, ParameterDirection.Input);


            return db.Execute(ScriptsDataBase.ProveedoresEditar, parametros, commandType: CommandType.StoredProcedure);
        }




        public IEnumerable<Vw_Maqui_tbProveedores_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Maqui_tbProveedores_LIST.ToList();
            return Listado;
        }

        public int Update(tbProveedores item)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbProveedores item)
        {
            throw new NotImplementedException();
        }
        IEnumerable<tbProveedores> IRepository<tbProveedores>.List()
        {
            throw new NotImplementedException();
        }
    }
}
