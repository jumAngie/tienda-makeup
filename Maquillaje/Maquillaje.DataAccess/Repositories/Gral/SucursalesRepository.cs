using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories.Gral
{
    public class SucursalesRepository : IRepository<tbSucursales>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbSucursales item)
        {
            throw new NotImplementedException();
        }

        public tbSucursales Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbSucursales item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_Gral_tbSucursales_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbSucursales_LIST.ToList();
            return Listado;
        }


        public int Update(tbSucursales item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbSucursales> IRepository<tbSucursales>.List()
        {
            throw new NotImplementedException();
        }
    }
}
