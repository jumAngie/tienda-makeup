using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories.Gral
{
    public class EstadosCivilesRepository : IRepository<tbEstadosCiviles>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbEstadosCiviles Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_Gral_tbEstadosCiviles_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbEstadosCiviles_LIST.ToList();
            return Listado;
        }


        public int Update(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbEstadosCiviles> IRepository<tbEstadosCiviles>.List()
        {
            throw new NotImplementedException();
        }
    }
}
