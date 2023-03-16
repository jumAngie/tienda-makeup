﻿using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            using var db = new TiendaContext();
            var result = db.tbMunicipios.Find(id);
            return result;
        }

        public int Insert(tbMunicipios item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@mun_Descripcion", item.mun_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@mun_DepId", item.mun_depID, DbType.String, ParameterDirection.Input);
            parametros.Add("@mun_UsuCrea", item.mun_UsuarioCrea, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.MunicipiosCrear, parametros, commandType: CommandType.StoredProcedure);
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
