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
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@cli_Id", item.cli_ID, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@cli_UsuModi", item.cli_UsuarioModi, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.ClientesEliminar, parametros, commandType: CommandType.StoredProcedure);

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



        public dynamic[] Detalles(int cli_Id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@ID", cli_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst(ScriptsDataBase.ClientesDetalles, parametro, commandType: CommandType.StoredProcedure);
            dynamic[] resultado = new dynamic[14];
            resultado[0] = result.cli_ID;
            resultado[1] = result.cli_Nombre;
            resultado[2] = result.cli_Apellido;
            resultado[3] = result.cli_DNI;
            resultado[4] = result.cli_FechaNacimiento;
            resultado[5] = result.cli_Sexo;
            resultado[6] = result.cli_Telefono;
            resultado[7] = result.cli_Municipio;
            resultado[8] = result.cli_EstadoCivil;
            resultado[9] = result.cli_UsuarioCrea;
            resultado[10] = result.cli_UsuarioModi;
            resultado[11] = result.cli_FechaCrea;
            resultado[12] = result.cli_FechaModi;

    


            return resultado;
        }

        public IEnumerable<tbClientes> Lista()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            return db.Query<tbClientes>(ScriptsDataBase.UDP_Listar_Clientes, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vw_Gral_tbClientes_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbClientes_LIST.ToList();
            return Listado;
        }

        public int Actualizar(int id, string cli_Nombre, string cli_Apellido, string cli_DNI, string cli_FechaNacimiento, string cli_Sexo, string cli_Telefono
                          , int cli_Municipio, int cli_EstadoCivil, int cli_UsuarioCrea)
        {
            cli_UsuarioCrea = 1;
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@cli_ID",               id,          DbType.String, ParameterDirection.Input);
            parametros.Add("@cli_Nombre",          cli_Nombre,   DbType.String, ParameterDirection.Input);
            parametros.Add("@cli_Apellido",        cli_Apellido, DbType.String, ParameterDirection.Input);
            parametros.Add("@cli_DNI",             cli_DNI,      DbType.String, ParameterDirection.Input);
            parametros.Add("@cli_FechaNacimiento", cli_FechaNacimiento, DbType.String, ParameterDirection.Input);
            parametros.Add("@cli_Sexo",            cli_Sexo,     DbType.String, ParameterDirection.Input);
            parametros.Add("@cli_Telefono",        cli_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@cli_Municipio",       cli_Municipio, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@cli_EstadoCivil",     cli_EstadoCivil, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@cli_UsuarioCrea",     cli_UsuarioCrea, DbType.Int32, ParameterDirection.Input);


            return db.Execute(ScriptsDataBase.ClientesEditar, parametros, commandType: CommandType.StoredProcedure);
        }

        IEnumerable<tbClientes> IRepository<tbClientes>.List()
        {
            throw new NotImplementedException();
        }
        public int Insert(tbClientes item)
        {
            throw new NotImplementedException();
        }

        public int Update(tbClientes item)
        {
            throw new NotImplementedException();
        }
    }
}
