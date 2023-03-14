using Maquillaje.DataAccess.Repositories;
using Maquillaje.DataAccess.Repositories.Gral;
using Maquillaje.DataAccess.Repositories.Maqui;
using Maquillaje.Entities.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maquillaje.BusinessLogic.Services
{
    public class GeneralesService
    {
        private readonly CategoriaRepository _categoriaRepository;
        private readonly ProductosRepository _productosRepository;
        private readonly InventarioRepository _inventarioRepository;
        private readonly ClientesRepository _clientesRepository;
        private readonly EmpleadosRepository _empleadosRepository;


        public GeneralesService(CategoriaRepository categoriaRepository, ProductosRepository productosRepository, InventarioRepository inventarioRepository, ClientesRepository clientesRepository, EmpleadosRepository empleadosRepository)
        {
            _categoriaRepository = categoriaRepository;
            _productosRepository = productosRepository;
            _inventarioRepository = inventarioRepository;
            _clientesRepository = clientesRepository;
            _empleadosRepository = empleadosRepository;
        }

        #region Categorias
        public IEnumerable<Vw_Maqui_tbCategorias_LIST> ListadoCategorias()
        {
            try
            {
                var result = _categoriaRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Maqui_tbCategorias_LIST>();
            }
        }

        public void CreateCategorias(tbCategorias categorias)
        {
            try
            {
                _categoriaRepository.Insert(categorias);

            }
            catch (Exception)
            {


            }
        }

        #endregion


        #region Productos

        public IEnumerable<Vw_Maqui_tbProductos_LIST> ListadoProductos()
        {
            try
            {
                var result = _productosRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Maqui_tbProductos_LIST>();
            }
        }
        public void CreateProductos(tbProductos productos)
        {
            try
            {
                _productosRepository.Insert(productos);

            }
            catch (Exception)
            {


            }
        }

        #endregion

        #region Inventario

        public IEnumerable<Vw_Maqui_tbInventario_LIST> ListadoInventario()
        {
            try
            {
                var result = _inventarioRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Maqui_tbInventario_LIST>();
            }
        }

        #endregion


        #region Clientes
        public IEnumerable<Vw_Gral_tbClientes_LIST> ListadoClientes()
        {
            try
            {
                var result = _clientesRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Gral_tbClientes_LIST>();
            }
        }

        #endregion



        #region Empleados

        public IEnumerable<Vw_Gral_tbEmpleados_LIST> ListadoEmpleados()
        {
            try
            {
                var result = _empleadosRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Gral_tbEmpleados_LIST>();
            }
        }

        #endregion

    }
}
