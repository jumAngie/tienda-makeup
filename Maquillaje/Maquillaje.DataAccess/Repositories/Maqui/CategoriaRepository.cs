using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories
{
    public class CategoriaRepository : IRepository<tbCategorias>
    {

        public int Delete(tbCategorias item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@cat_Id", item.cat_Id, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.CategoriasEliminar, parametros, commandType: CommandType.StoredProcedure);


        }



        public tbCategorias Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbCategorias.Find(id);

            return result;
        }

        public int Insert(tbCategorias item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@cat_Descripcion", item.cat_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@cat_UsuCrea", item.cat_UsuCrea, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.CategoriasCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vw_Maqui_tbCategorias_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Maqui_tbCategorias_LIST.ToList();
            return Listado;
        }

        public int Update(tbCategorias item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@cat_Id", item.cat_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@cat_Descripcion", item.cat_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@cat_UsuModi", item.cat_UsuModi, DbType.Int32, ParameterDirection.Input);


            db.Execute(ScriptsDataBase.CategoriasEditar, parametros, commandType: System.Data.CommandType.StoredProcedure);

            int resultado = parametros.Get<int>("@cat_Id");

            return resultado;
        }

        IEnumerable<tbCategorias> IRepository<tbCategorias>.List()
        {
            throw new NotImplementedException();
        }
    }
}


//////using var db = new TiendaContext();
////var listado = db.tbCategorias.ToList();

////return listado;
//using var db = new SqlConnection(TiendaContext.ConnectionString);
////var parametors = new DynamicParameters();
////parametors.Add("@Parametro", "dd", DbType.String, ParameterDirection.Input);

//return db.Query<tbCategorias>(ScriptsDataBase.CategoriasList, null, commandType: CommandType.StoredProcedure);
