using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories
{
    public class ProductosRepository : IRepository<tbProductos>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbProductos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbProductos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_Maqui_tbProductos_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Maqui_tbProductos_LIST.ToList();
            return Listado;
        }

        public int Update(tbProductos item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbProductos> IRepository<tbProductos>.List()
        {
            throw new NotImplementedException();
        }
    }
}
