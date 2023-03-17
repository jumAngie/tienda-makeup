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
    public class VentasRepository : IRepository<tbVentas>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbVentas item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@ven_Id", item.ven_Id, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.VentasEliminar, parametros, commandType: CommandType.StoredProcedure);


        }

        public tbVentas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbVentas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_Maqui_tbVentas_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Maqui_tbVentas_LIST.ToList();
            return Listado;
        }

        public int Update(tbVentas item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbVentas> IRepository<tbVentas>.List()
        {
            throw new NotImplementedException();
        }
    }
}
