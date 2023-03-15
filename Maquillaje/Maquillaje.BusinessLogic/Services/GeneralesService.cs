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
        private readonly SucursalesRepository _sucursalesRepository;
        private readonly MunicipioRepository _municipiosRepository;
        private readonly DepartamentosRepository _departamentosRepository;
        private readonly EstadosCivilesRepository _estadosCivilesRepository;
        private readonly MetodoPagoRepository _metodoPagoRepository;
        private readonly ProveedoresRepository _proveedoresRepository;
        private readonly VentasRepository _ventasRepository;
        private readonly UsuariosRepository _usuariosRepository;

        public GeneralesService(CategoriaRepository categoriaRepository, ProductosRepository productosRepository, InventarioRepository inventarioRepository, ClientesRepository clientesRepository, EmpleadosRepository empleadosRepository, SucursalesRepository sucursalesRepository, MunicipioRepository municipioRepository, DepartamentosRepository departamentosRepository, EstadosCivilesRepository estadosCivilesRepository, MetodoPagoRepository metodoPagoRepository, ProveedoresRepository proveedoresRepository, VentasRepository ventasRepository, UsuariosRepository usuariosRepository) 
        {
            _categoriaRepository = categoriaRepository;
            _productosRepository = productosRepository;
            _inventarioRepository = inventarioRepository;
            _clientesRepository = clientesRepository;
            _empleadosRepository = empleadosRepository;
            _sucursalesRepository = sucursalesRepository;
            _municipiosRepository = municipioRepository;
            _departamentosRepository = departamentosRepository;
            _estadosCivilesRepository = estadosCivilesRepository;
            _metodoPagoRepository = metodoPagoRepository;
            _proveedoresRepository = proveedoresRepository;
            _ventasRepository = ventasRepository;
            _usuariosRepository = usuariosRepository;
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

        public int CreateCategorias(tbCategorias categorias)
        {
            try
            {
                return _categoriaRepository.Insert(categorias);

            }
            catch (Exception)
            {
                return 0;


            }
        }


        public int EditCategoria(tbCategorias categorias)
        {
   
                return _categoriaRepository.Update(categorias);

      
        }

        public tbCategorias BuscarCategoria(int? id)
        {
            return _categoriaRepository.Find(id);
        }


        //ELIMINAR
        public int DeleteCategoria(tbCategorias categoria)
        {
            try
            {
                return _categoriaRepository.Delete(categoria);
            }
            catch
            {
                return 1;
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

        #region Sucursales

        public IEnumerable<Vw_Gral_tbSucursales_LIST> ListadoSucursales()
        {
            try
            {
                var result = _sucursalesRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Gral_tbSucursales_LIST>();
            }
        }

        #endregion

        #region Municipio

        public IEnumerable<Vw_Gral_tbMunicipios_LIST> ListadoMunicipios()
        {
            try
            {
                var result = _municipiosRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Gral_tbMunicipios_LIST>();
            }
        }

        #endregion

        #region Departamentos

        public IEnumerable<Vw_Gral_tbDepartamentos_LIST> ListadoDepartamentos()
        {
            try
            {
                var result = _departamentosRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Gral_tbDepartamentos_LIST>();
            }
        }

        #endregion

        #region EstadosCiviles

        public IEnumerable<Vw_Gral_tbEstadosCiviles_LIST> ListadoEstadosCiviles()
        {
            try
            {
                var result = _estadosCivilesRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Gral_tbEstadosCiviles_LIST>();
            }
        }

        #endregion

        #region MetodoPago

        public IEnumerable<Vw_Maqui_tbMetodoPago_LIST> ListadoMetodoPago()
        {
            try
            {
                var result = _metodoPagoRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Maqui_tbMetodoPago_LIST>();
            }
        }

        #endregion

        #region Proveedores

        public IEnumerable<Vw_Maqui_tbProveedores_LIST> ListadoProveedores()
        {
            try
            {
                var result = _proveedoresRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Maqui_tbProveedores_LIST>();
            }
        }

        #endregion

        #region Ventas

        public IEnumerable<Vw_Maqui_tbVentas_LIST> ListadoVentas()
        {
            try
            {
                var result = _ventasRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Maqui_tbVentas_LIST>();
            }
        }

        #endregion

        #region Usuarios

        public IEnumerable<Vw_Gral_tbUsuarios_LIST> ListadoUsuarios()
        {
            try
            {
                var result = _usuariosRepository.List();
                return result;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Vw_Gral_tbUsuarios_LIST>();
            }
        }

        #endregion
    }
}

