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
    public class UsuariosRepository : IRepository<tbUsuarios>
    {
        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(tbUsuarios item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@usu_Id", item.usu_ID, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@usu_UsuModi", item.usu_UsuarioModi, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.UsuariosEliminar, parametros, commandType: CommandType.StoredProcedure);

        }

        public tbUsuarios Find(int? id)
        {
            using var db = new TiendaContext();
            var result = db.tbUsuarios.Find(id);
            return result;

        }

        public int Insert(tbUsuarios item)
        {
            try
            {
            string admin;
            if (item.usu_EsAdmin == true)
            {
                admin = "1";
            }
            else
            {
                admin = "0";
            }
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@usu_Usuario", item.usu_Usuario, DbType.String, ParameterDirection.Input);
            parametros.Add("@usu_empID", item.usu_empID, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@usu_Clave", item.usu_Clave, DbType.String, ParameterDirection.Input);
            parametros.Add("@usu_EsAdmin", admin, DbType.String, ParameterDirection.Input);
            parametros.Add("@usu_UsuarioCrea", item.usu_UsuarioCrea, DbType.Int32, ParameterDirection.Input);

            return db.Execute(ScriptsDataBase.UsuariosCrear, parametros, commandType: CommandType.StoredProcedure);

            }
            catch (Exception)
            {

                return 1;
            }
        }

        public IEnumerable<Vw_Gral_tbUsuarios_LIST> List()
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            TiendaContext dbc = new TiendaContext();
            var Listado = dbc.Vw_Gral_tbUsuarios_LIST.ToList();
            return Listado;
        }

        public string[] IniciarSesion(string txtUsername, string txtPass)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@usu_Usuario", txtUsername, DbType.String, ParameterDirection.Input);
            parametro.Add("@usu_Clave", txtPass, DbType.String, ParameterDirection.Input);

            var result = db.QueryFirst(ScriptsDataBase.ValidarLogin, parametro, commandType: CommandType.StoredProcedure);
            string[] resultado = new string[8];


            string admin;
            if (result.usu_EsAdmin == true)
            {
                admin = "1";
            }
            else
            {
                admin = "0";

            }

            resultado[0] = result.usu_ID.ToString();
            resultado[1] = result.usu_Nombre;
            resultado[2] = admin;
            resultado[3] = result.emp_Sucursal.ToString();
            resultado[4] = result.suc_Descripcion;
            resultado[5] = result.suc_Id.ToString();
            resultado[6] = result.usu_Usuario;
            resultado[7] = result.usu_Clave;


            return resultado;
        }
        public int Update(tbUsuarios item)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@usu_Id", item.usu_ID, DbType.String, ParameterDirection.Input);
            parametros.Add("@usu_empID", item.usu_empID, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@usu_EsAdmin", item.usu_EsAdmin, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@usu_UsuModi", item.usu_UsuarioModi, DbType.Int32, ParameterDirection.Input);


            db.Query<tbUsuarios>(ScriptsDataBase.UsuariosEditar, parametros, commandType: System.Data.CommandType.StoredProcedure);

            int resultado = 1;

            return resultado;
        }
        int IRepository<tbUsuarios>.Insert(tbUsuarios item)
        {
            throw new NotImplementedException();
        }


        public dynamic[] Detalles(int usu_Id)
        {
            using var db = new SqlConnection(TiendaContext.ConnectionString);
            var parametro = new DynamicParameters();
            parametro.Add("@ID", usu_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst(ScriptsDataBase.UsuariosDetalles, parametro, commandType: CommandType.StoredProcedure);
            dynamic[] resultado = new dynamic[9];
            resultado[0] = result.usu_ID;
            resultado[1] = result.usu_Usuario;
            resultado[2] = result.usu_empID;
            resultado[3] = result.usu_EsAdmin;
            resultado[4] = result.usu_FechaCrea;
            resultado[5] = result.usu_FechaModi;
            resultado[6] = result.usu_UsuarioCrea;
            resultado[7] = result.usu_UsuarioModi;




            return resultado;
        }



        IEnumerable<tbUsuarios> IRepository<tbUsuarios>.List()
        {
            throw new NotImplementedException();
        }
    }
}
