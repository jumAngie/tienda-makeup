using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories.Gral
{
    public class DepartamentosRepository : IRepository<tbDepartamentos>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbDepartamentos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbDepartamentos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_Gral_tbDepartamentos_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbDepartamentos_LIST.ToList();
            return Listado;
        }

        public int Update(tbDepartamentos item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbDepartamentos> IRepository<tbDepartamentos>.List()
        {
            throw new NotImplementedException();
        }
    }
}

