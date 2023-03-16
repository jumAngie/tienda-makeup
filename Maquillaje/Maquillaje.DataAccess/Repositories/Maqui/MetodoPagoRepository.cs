﻿using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maquillaje.DataAccess.Repositories.Maqui
{
    public class MetodoPagoRepository : IRepository<tbMetodoPago>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbMetodoPago item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@met_Id", item.met_Id, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.MetodoPagoEliminar, parametros, commandType: CommandType.StoredProcedure);
        }


        public tbMetodoPago Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbMetodoPago.Find(id);

            return result;
        }

        public int Insert(tbMetodoPago item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@met_Descripcion", item.met_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@met_UsuCrea", item.met_FechaCrea, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.MetodoPagoCrear, parametros, commandType: CommandType.StoredProcedure);

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
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@met_Id", item.met_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@met_Decripcion", item.met_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@met_UsuModi", item.met_usuModi, DbType.Int32, ParameterDirection.Input);


            db.Execute(ScriptsDataBase.MetodoPagoEditar, parametros, commandType: System.Data.CommandType.StoredProcedure);

            int resultado = parametros.Get<int>("@met_Id");

            return resultado;
        }
        IEnumerable<tbMetodoPago> IRepository<tbMetodoPago>.List()
        {
            throw new NotImplementedException();
        }
    }
}
