using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Maquillaje.DataAccess.Repositories.Gral
{
    public class EmpleadosRepository : IRepository<tbEmpleados>
    {


        public int Delete(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_Gral_tbEmpleados_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbEmpleados_LIST.ToList();
            return Listado;
        }

        public int Update(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbEmpleados> IRepository<tbEmpleados>.List()
        {
            throw new NotImplementedException();
        }
    }
}
