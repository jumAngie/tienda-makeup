using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Maquillaje.DataAccess.Repositories.Gral
{
    public class ClientesRepository : IRepository<tbClientes>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbClientes Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbClientes item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_Gral_tbClientes_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbClientes_LIST.ToList();
            return Listado;
        }

        public int Update(tbClientes item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbClientes> IRepository<tbClientes>.List()
        {
            throw new NotImplementedException();
        }
    }
}
