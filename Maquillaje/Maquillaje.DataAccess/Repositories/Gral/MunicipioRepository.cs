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
    public class MunicipioRepository : IRepository<tbMunicipios>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbMunicipios> Find(int? id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);


            var parametros = new DynamicParameters();
            parametros.Add("@mun_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.Query<tbMunicipios>(ScriptsDataBase.MunicipiosCargar, parametros, commandType: CommandType.StoredProcedure);

        }

        public int Insert(tbMunicipios item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@mun_Descripcion", item.mun_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@mun_DepId", item.mun_depID, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@mun_UsuCrea", item.mun_UsuarioCrea, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.MunicipiosCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public dynamic[] Detalles(int mun_Id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@ID", mun_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst(ScriptsDataBase.MunicipiosDetalles, parametro, commandType: CommandType.StoredProcedure);
            dynamic[] resultado = new dynamic[7];
            resultado[0] = result.mun_ID;
            resultado[1] = result.mun_depID;
            resultado[2] = result.mun_Descripcion;
            resultado[3] = result.mun_UsuarioCrea;
            resultado[4] = result.mun_UsuarioModi;
            resultado[5] = result.mun_FechaCrea;
            resultado[6] = result.mun_FechaModi;



            return resultado;
        }






        //public tbMunicipios CargarMunicipios(string muni_Id)
        //{
        //    using var db = new SqlConnection(TiendaContext.ConnectionString);
        //    var parametro = new DynamicParameters();
        //    parametro.Add("@muni_Id", muni_Id, DbType.String, ParameterDirection.Input);

        //    return db.QueryFirst<tbMunicipios>(ScriptsDataBase.MunicipiosCargarDatosId, parametro, commandType: CommandType.StoredProcedure);
        //}


        public IEnumerable<Vw_Gral_tbMunicipios_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbMunicipios_LIST.ToList();
            return Listado;
        }


        public int Update(int mun_Id, string mun_Descripcion, int mun_DepId)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@mun_Descripcion", mun_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@mun_UsuModi", 1, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@mun_Id", mun_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@mun_DepId", mun_DepId, DbType.Int32, ParameterDirection.Input);


            var lis = db.Query<tbMunicipios>(ScriptsDataBase.MunicipiosEditar, parametros, commandType: CommandType.StoredProcedure);

            int result = 0;
            if (lis.Count() == 1)
            {
                result = 1;
            }

            return result;
        }


        public IEnumerable<tbDepartamentos> CargaDepa()
        {

            using var db = new SqlConnection(TiendaContext.ConnectionString);


            return db.Query<tbDepartamentos>(ScriptsDataBase.MunicipiosCargarCiudades, commandType: CommandType.StoredProcedure);

        }

        IEnumerable<tbMunicipios> IRepository<tbMunicipios>.List()
        {
            throw new NotImplementedException();
        }

        public int Update(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        tbMunicipios IRepository<tbMunicipios>.Find(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
