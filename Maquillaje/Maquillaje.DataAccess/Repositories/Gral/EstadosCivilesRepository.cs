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
    public class EstadosCivilesRepository : IRepository<tbEstadosCiviles>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }

        public tbEstadosCiviles Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbEstadosCiviles.Find(id);
            return result;

        }

        public int Insert(tbEstadosCiviles item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@est_Descripcion", item.est_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@est_UsuCrea", item.est_UsuarioCrea, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.EstadosCivilesCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vw_Gral_tbEstadosCiviles_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbEstadosCiviles_LIST.ToList();
            return Listado;
        }


        public int Update(tbEstadosCiviles item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@est_Id", item.est_ID, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@est_Descripcion", item.est_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@est_UsuModi", item.est_UsuarioModi, DbType.Int32, ParameterDirection.Input);


            db.Execute(ScriptsDataBase.EstadosCivilesEditar, parametros, commandType: System.Data.CommandType.StoredProcedure);

            int resultado = parametros.Get<int>("@est_Id");

            return resultado;
        }


        public dynamic[] Detalles(int est_Id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@ID", est_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst(ScriptsDataBase.EstadosCivilesDetalles, parametro, commandType: CommandType.StoredProcedure);
            dynamic[] resultado = new dynamic[6];
            resultado[0] = result.est_ID;
            resultado[1] = result.est_Descripcion;
            resultado[2] = result.est_UsuarioCrea;
            resultado[3] = result.est_UsuarioModi;
            resultado[4] = result.est_FechaCrea;
            resultado[5] = result.est_FechaModi;



            return resultado;
        }



        IEnumerable<tbEstadosCiviles> IRepository<tbEstadosCiviles>.List()
        {
            throw new NotImplementedException();
        }
    }
}
