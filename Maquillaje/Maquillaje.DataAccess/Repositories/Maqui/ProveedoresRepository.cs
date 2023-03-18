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

            return db.Execute(ScriptsDataBase.ProveedoresEliminar, parametros, commandType: CommandType.StoredProcedure);


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

        public int Actulizar(int prv_ID, string prv_NombreCompañia, string prv_NombreContacto, string prv_TelefonoContacto,
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
