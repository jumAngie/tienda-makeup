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
    public class InventarioRepository : IRepository<tbInventario>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbInventario item)
        {
            throw new NotImplementedException();
        }

        public tbInventario Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbInventario.Find(id);

            return result;
        }

        public int Insert(tbInventario item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@inv_Cantidad", item.inv_Cantidad, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@inv_Producto", item.inv_Producto, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@inv_UsuCrea",     item.inv_UsuCrea, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.InventarioCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vw_Maqui_tbInventario_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Maqui_tbInventario_LIST.ToList();
            return Listado;
        }

        public int Update(tbInventario item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbInventario> IRepository<tbInventario>.List()
        {
            throw new NotImplementedException();
        }
    }
}
