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
            using var db = new TiendaContext();
            var result = db.tbClientes.Find(id);

            return result;
        }

        public int Insertar(string cli_Nombre, string cli_Apellido, string cli_DNI, string cli_FechaNacimiento, string cli_Sexo, string cli_Telefono
                          ,int cli_Municipio, int cli_EstadoCivil, int cli_UsuarioCrea)
        {
            cli_UsuarioCrea = 1;
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@cli_Nombre",           cli_Nombre,            DbType.String,  ParameterDirection.Input);
            parametros.Add("@cli_Apellido",         cli_Apellido,          DbType.String,  ParameterDirection.Input);
            parametros.Add("@cli_DNI",              cli_DNI,               DbType.String,  ParameterDirection.Input);
            parametros.Add("@cli_FechaNacimiento",  cli_FechaNacimiento,   DbType.String,    ParameterDirection.Input);
            parametros.Add("@cli_Sexo",             cli_Sexo,              DbType.String,  ParameterDirection.Input);
            parametros.Add("@cli_Telefono",         cli_Telefono,          DbType.String, ParameterDirection.Input);
            parametros.Add("@cli_Municipio",        cli_Municipio,         DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@cli_EstadoCivil",      cli_EstadoCivil,       DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@cli_UsuarioCrea",      cli_UsuarioCrea,       DbType.Int32,   ParameterDirection.Input);


            return db.Execute(ScriptsDataBase.ClientesCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public int Insert(tbClientes item)
        {
            throw new NotImplementedException();
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
