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
        public int Delete(int? id)
        {
            //investigar
            throw new NotImplementedException();
        }

        public tbCategorias Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbCategorias.Find(id);

            return result;
        }

        public int Insert(tbCategorias item)
        {
            using var db = new TiendaContext();

            db.tbCategorias.Add(item);
            db.SaveChanges();
            return item.cat_Id;
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
            using var db = new TiendaContext();
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();

            return item.cat_Id;
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
