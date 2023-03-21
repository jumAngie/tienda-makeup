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
    public class EmpleadosRepository : IRepository<tbEmpleados>
    {


        public int Delete(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbEmpleados.Find(id);

            return result;
        }

        public dynamic[] Detalles(int emp_Id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@ID", emp_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst(ScriptsDataBase.EmpleadosDetalles, parametro, commandType: CommandType.StoredProcedure);
            dynamic[] resultado = new dynamic[17];
            resultado[0] = result.emp_ID;
            resultado[1] = result.emp_Nombre;
            resultado[2] = result.emp_Apellido;
            resultado[3] = result.emp_DNI;
            resultado[4] = result.emp_FechaNacimiento;
            resultado[5] = result.emp_Sexo;
            resultado[6] = result.emp_Telefono;
            resultado[7] = result.emp_Municipio;
            resultado[8] = result.emp_Correo;
            resultado[9] = result.emp_EstadoCivil;
            resultado[10] = result.emp_Sucursal;
            resultado[11] = result.emp_UsuarioCrea;
            resultado[12] = result.emp_UsuarioModi;
            resultado[13] = result.emp_FechaCrea;
            resultado[14] = result.emp_FechaModi;

            return resultado;
        }

	


        public int Insertar( string emp_Nombre, string emp_Apellido, string emp_DNI , string emp_FechaNacimiento, string emp_Sexo  ,			
            int emp_Municipio , string emp_Telefono , string emp_Correo , int emp_EstadoCivil, int emp_Sucursal , int emp_UsuarioCrea)
        {
            emp_UsuarioCrea = 1;
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@emp_Nombre",           emp_Nombre,             DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_Apellido",         emp_Apellido ,          DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_DNI",              emp_DNI ,               DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_FechaNacimiento",  emp_FechaNacimiento ,   DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_Sexo",             emp_Sexo,               DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_Municipio",        emp_Municipio ,         DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_Telefono",         emp_Telefono ,          DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_Correo",           emp_Correo,             DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_EstadoCivil",      emp_EstadoCivil ,       DbType.Int32, ParameterDirection.Input);
            parametros.Add("@emp_Sucursal",         emp_Sucursal,           DbType.Int32, ParameterDirection.Input);
            parametros.Add("@emp_UsuarioCrea",      emp_UsuarioCrea,        DbType.Int32, ParameterDirection.Input);


            return db.Execute(ScriptsDataBase.EmpleadosCrear, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Vw_Gral_tbEmpleados_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbEmpleados_LIST.ToList();
            return Listado;
        }
        public int Actualizar(int emp_ID, string emp_Nombre, string emp_Apellido, string emp_DNI, string emp_FechaNacimiento, string emp_Sexo,
            int emp_Municipio, string emp_Telefono, string emp_Correo, int emp_EstadoCivil, int emp_Sucursal, int emp_UsuarioCrea)
        {
            emp_UsuarioCrea = 1;
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@emp_ID",               emp_ID,             DbType.Int32, ParameterDirection.Input);
            parametros.Add("@emp_Nombre",           emp_Nombre,         DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_Apellido",         emp_Apellido,       DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_DNI",              emp_DNI,            DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_FechaNacimiento",  emp_FechaNacimiento , DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_Sexo",             emp_Sexo ,          DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_Municipio",        emp_Municipio ,     DbType.Int32, ParameterDirection.Input);
            parametros.Add("@emp_Telefono",         emp_Telefono,       DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_Correo",           emp_Correo ,        DbType.String, ParameterDirection.Input);
            parametros.Add("@emp_EstadoCivil",      emp_EstadoCivil,    DbType.Int32, ParameterDirection.Input);
            parametros.Add("@emp_Sucursal",         emp_Sucursal,       DbType.Int32, ParameterDirection.Input);
            parametros.Add("@emp_UsuarioCrea",      emp_UsuarioCrea,    DbType.Int32, ParameterDirection.Input);


            return db.Execute(ScriptsDataBase.EmpleadosEditar, parametros, commandType: CommandType.StoredProcedure);
        }
        public int Update(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        //

        IEnumerable<tbEmpleados> IRepository<tbEmpleados>.List()
        {
            throw new NotImplementedException();
        }
        public int Insert(tbEmpleados item)
        {
            throw new NotImplementedException();
        }
    }
}
