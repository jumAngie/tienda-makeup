using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Data;

namespace Maquillaje.DataAccess.Repositories.Gral
{
    public class ClientesRepository : IRepository<tbClientes>
    {

        public int Delete(tbClientes item)
        {
            throw new NotImplementedException();
        }

        public tbClientes Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbClientes item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@cli_Nombre",           item.cli_Nombre,            DbType.String,  ParameterDirection.Input);
            parametros.Add("@cli_Apellido",         item.cli_Apellido,          DbType.String,  ParameterDirection.Input);
            parametros.Add("@cli_DNI",              item.cli_DNI,               DbType.String,  ParameterDirection.Input);
            parametros.Add("@cli_FechaNacimiento",  item.cli_FechaNacimiento,   DbType.Date,    ParameterDirection.Input);
            parametros.Add("@cli_Sexo",             item.cli_Sexo,              DbType.String,  ParameterDirection.Input);
            parametros.Add("@cli_Municipio",        item.cli_Municipio,         DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@cli_EstadoCivil",      item.cli_EstadoCivil,       DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@cli_UsuarioCrea",      item.cli_UsuarioCrea,       DbType.Int32,   ParameterDirection.Input);


            return db.QueryFirst<int>(ScriptsDataBase.ClientesCrear, parametros, commandType: CommandType.StoredProcedure);
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
