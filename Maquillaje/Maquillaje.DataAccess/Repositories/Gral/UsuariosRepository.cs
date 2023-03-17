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
    public class UsuariosRepository : IRepository<tbUsuarios>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbUsuarios item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@usu_Id", item.usu_ID, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.UsuariosEliminar, parametros, commandType: CommandType.StoredProcedure);

        }

        public tbUsuarios Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbUsuarios.Find(id);
            return result;

        }

        public int Insert(tbUsuarios item)
        {
            string admin;
            if (item.usu_EsAdmin == true)
            {
                admin = "1";
            }
            else
            {
                admin = "0";
            }
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@usu_Usuario", item.usu_Usuario, DbType.String, ParameterDirection.Input);
            parametros.Add("@usu_empID", item.usu_empID, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@usu_Clave", item.usu_Clave, DbType.String, ParameterDirection.Input);
            parametros.Add("@usu_EsAdmin", admin, DbType.String, ParameterDirection.Input);
            parametros.Add("@usu_UsuarioCrea", item.usu_UsuarioCrea, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.UsuariosCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vw_Gral_tbUsuarios_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbUsuarios_LIST.ToList();
            return Listado;
        }

        public int Update(tbUsuarios item)
        {
            throw new NotImplementedException();
        }
        int IRepository<tbUsuarios>.Insert(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbUsuarios> IRepository<tbUsuarios>.List()
        {
            throw new NotImplementedException();
        }
    }
}
