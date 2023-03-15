using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories.Gral
{
    public class MunicipioRepository : IRepository<tbMunicipios>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        public tbMunicipios Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbMunicipios item)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Vw_Gral_tbMunicipios_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbMunicipios_LIST.ToList();
            return Listado;
        }


        public int Update(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbMunicipios> IRepository<tbMunicipios>.List()
        {
            throw new NotImplementedException();
        }
    }
}
