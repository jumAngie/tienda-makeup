using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public int Insert(tbInventario item)
        {
            throw new NotImplementedException();
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
