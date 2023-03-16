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
    public class DepartamentosRepository : IRepository<tbDepartamentos>
    {

        public int Delete(tbDepartamentos item)
        {
            throw new NotImplementedException();
        }

        public tbDepartamentos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbDepartamentos item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@dep_Descripcion", item.dep_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@dep_UsuCrea", item.dep_UsuarioCrea, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.DepartamentosCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vw_Gral_tbDepartamentos_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbDepartamentos_LIST.ToList();
            return Listado;
        }

        public int Update(tbDepartamentos item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@dep_Id", item.dep_ID, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@dep_Descripcion", item.dep_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@dep_UsuModi", item.dep_UsuarioCrea, DbType.Int32, ParameterDirection.Input);


            db.Execute(ScriptsDataBase.DepartamentosEditar, parametros, commandType: System.Data.CommandType.StoredProcedure);

            int resultado = parametros.Get<int>("@dep_Id");

            return resultado;
        }

        IEnumerable<tbDepartamentos> IRepository<tbDepartamentos>.List()
        {
            throw new NotImplementedException();
        }
    }
}

