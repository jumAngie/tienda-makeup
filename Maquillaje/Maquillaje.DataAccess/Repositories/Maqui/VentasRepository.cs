using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
