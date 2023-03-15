using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories.Maqui
{
    public  class MetodoPagoRepository : IRepository<tbMetodoPago>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbMetodoPago item)
        {
            throw new NotImplementedException();
        }

        public tbMetodoPago Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbMetodoPago item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_Maqui_tbMetodoPago_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Maqui_tbMetodoPago_LIST.ToList();
            return Listado;
        }

        public int Update(tbMetodoPago item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbMetodoPago> IRepository<tbMetodoPago>.List()
        {
            throw new NotImplementedException();
        }
    }
}
