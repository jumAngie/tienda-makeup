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
            throw new NotImplementedException();
        }

        public int Insert(tbProveedores item)
        {
            throw new NotImplementedException();
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

        IEnumerable<tbProveedores> IRepository<tbProveedores>.List()
        {
            throw new NotImplementedException();
        }
    }
}
