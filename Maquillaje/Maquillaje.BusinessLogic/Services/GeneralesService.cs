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
        public void CreateProductos(string pro_Codigo, string pro_Nombre, string pro_StockInicial, decimal pro_PrecioUnitario,
                            int pro_Proveedor, int pro_usuCrea, int pro_Categoria)
        {
            try
            {
                _productosRepository.Insertar(pro_Codigo, pro_Nombre, pro_StockInicial, pro_PrecioUnitario, pro_Proveedor, pro_usuCrea
                    , pro_Categoria);

            }
            catch (Exception)
            {


            }
        }

        public tbProductos ObtenerProducto(int? id)
        {
            return _productosRepository.Find(id);
        }

        public void EditProductos(int pro_Id, string pro_Codigo, string pro_Nombre, string pro_StockInicial, decimal pro_PrecioUnitario,
                           int pro_Proveedor, int pro_usuCrea, int pro_Categoria)
        {
            try
            {
                _productosRepository.Actualizar(pro_Id, pro_Codigo, pro_Nombre, pro_StockInicial, pro_PrecioUnitario, pro_Proveedor, pro_usuCrea
                    , pro_Categoria);

            }
            catch (Exception)
            {


            }
        }

        public int DeleteProductos(tbProductos productos)
        {
               return _productosRepository.Delete(productos);
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

        public int CreateInventario(tbInventario inventario)
        {

            return _inventarioRepository.Insert(inventario);


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

        public void CreateClientes(string cli_Nombre, string cli_Apellido, string cli_DNI, string cli_FechaNacimiento, string cli_Sexo, string Telefono,
                          int cli_Municipio, int cli_EstadoCivil, int cli_UsuarioCrea)
        {

            _clientesRepository.Insertar(cli_Nombre, cli_Apellido, cli_DNI, cli_FechaNacimiento, cli_Sexo, Telefono,
                                        cli_Municipio, cli_EstadoCivil, cli_UsuarioCrea);


        }

        public void UpdateClientes(int id, string cli_Nombre, string cli_Apellido, string cli_DNI, string cli_FechaNacimiento,
                                   string cli_Sexo, string Telefono, int cli_Municipio, int cli_EstadoCivil, int cli_UsuarioCrea)
        {
            _clientesRepository.Actualizar(id, cli_Nombre, cli_Apellido, cli_DNI, cli_FechaNacimiento, cli_Sexo, Telefono, cli_Municipio,
                                            cli_EstadoCivil, cli_UsuarioCrea);
        }

        public tbClientes ObtenerCliente(int? id)
        {

            return _clientesRepository.Find(id);


        }



        public int DeleteCliente (tbClientes clientes)
        {
            try
            {
                return _clientesRepository.Delete(clientes);
            }
            catch (Exception)
            {

                return 1;
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

        public void CreateEmpleados(string emp_Nombre, string emp_Apellido, string emp_DNI, string emp_FechaNacimiento, string emp_Sexo,
            int emp_Municipio, string emp_Telefono, string emp_Correo, int emp_EstadoCivil, int emp_Sucursal, int emp_UsuarioCrea)
        {

            _empleadosRepository.Insertar(emp_Nombre, emp_Apellido, emp_DNI, emp_FechaNacimiento, emp_Sexo, emp_Municipio, emp_Telefono,
                emp_Correo, emp_EstadoCivil, emp_Sucursal, emp_UsuarioCrea);


        }

        public tbEmpleados ObtenerEmpleado(int? id)
        {

            return _empleadosRepository.Find(id);


        }

        public void UpdateEmpleados(int emp_ID, string emp_Nombre, string emp_Apellido, string emp_DNI, string emp_FechaNacimiento, string emp_Sexo,
            int emp_Municipio, string emp_Telefono, string emp_Correo, int emp_EstadoCivil, int emp_Sucursal, int emp_UsuarioCrea)
        {
            _empleadosRepository.Actualizar(emp_ID, emp_Nombre, emp_Apellido, emp_DNI, emp_FechaNacimiento, emp_Sexo, emp_Municipio, emp_Telefono,
                emp_Correo, emp_EstadoCivil, emp_Sucursal, emp_UsuarioCrea);
        }

        public int DeleteEmpleado (tbEmpleados empleados)
        {
            try
            {
                return _empleadosRepository.Delete(empleados);
            }
            catch (Exception)
            {

                return 1;
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

        public int CreateSucursales(tbSucursales sucursales)
        {

            try
            {
                return _sucursalesRepository.Insert(sucursales);

            }
            catch (Exception)
            {

                return 1;
            }

        }

        public int EditSucursales(tbSucursales sucursales)
        {
            try
            {
                return _sucursalesRepository.Update(sucursales);
            }
            catch (Exception)
            {

                return 1;
            }
        }


        public int DeleteSucursales(tbSucursales sucursales)
        {
            try
            {
                return _sucursalesRepository.Delete(sucursales);
            }
            catch (Exception)
            {

                return 1;
            }
        }


        public tbSucursales BuscarSucursal(int? id)
        {
            return _sucursalesRepository.Find(id);
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

        public int CreateMuni(tbMunicipios municipios)
        {
            return _municipiosRepository.Insert(municipios);

        }

        public int UpdateMuni(tbMunicipios municipios)
        {
            try
            {
                return _municipiosRepository.Update(municipios);
            }
            catch (Exception)
            {

                return 1;
            }
        }

        public tbMunicipios BuscarMuni(int? id)
        {
            return _municipiosRepository.Find(id);
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

        public int CreateDepto(tbDepartamentos departamentos)
        {
            try
            {
                return _departamentosRepository.Insert(departamentos);
            }
            catch (Exception)
            {

                return 1;
            }
        }

        public int EditDepto(tbDepartamentos departamentos)
        {
            try
            {
                return _departamentosRepository.Update(departamentos);
            }
            catch (Exception)
            {

                return 1;
            }
        }

        public tbDepartamentos BuscarDepto(int? id)
        {

            return _departamentosRepository.Find(id);

        }

        public int DeleteDepto(tbDepartamentos departamentos)
        {
            try
            {
                return _departamentosRepository.Delete(departamentos);
            }
            catch (Exception)
            {

                return 1;
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

        public int CreateEstado(tbEstadosCiviles estadosCiviles)
        {
            try
            {
                return _estadosCivilesRepository.Insert(estadosCiviles);
            }
            catch (Exception)
            {

                return 1;
            }
        }

        public int DeleteEstado(tbEstadosCiviles estadosCiviles)
        {
            try
            {
                return _estadosCivilesRepository.Delete(estadosCiviles);
            }
            catch (Exception)
            {

                return 1;
            }
        }

        public tbEstadosCiviles BuscarEstado(int? id)
        {
            return _estadosCivilesRepository.Find(id);
        }

        public int EditEstado(tbEstadosCiviles estadosCiviles)
        {

            return _estadosCivilesRepository.Update(estadosCiviles);

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

        public int CreateMetodoPago(tbMetodoPago metodoPago)
        {
            try
            {
                return _metodoPagoRepository.Insert(metodoPago);

            }
            catch (Exception)
            {
                return 0;


            }
        }


        public int EditMetodoPago(tbMetodoPago metodoPago)
        {

            return _metodoPagoRepository.Update(metodoPago);


        }

        public tbMetodoPago BuscarMetodoPago(int? id)
        {
            return _metodoPagoRepository.Find(id);
        }


        public int DeleteMetodoPago(tbMetodoPago metodoPago)
        {
            try
            {
                return _metodoPagoRepository.Delete(metodoPago);
            }
            catch
            {
                return 1;
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

        public int DeleteProv(tbProveedores proveedores)
        {
            try
            {
                return _proveedoresRepository.Delete(proveedores);
            }
            catch (Exception)
            {

                return 1;
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

        public int DeleteVenta(tbVentas ventas)
        {
            try
            {
                return _ventasRepository.Delete(ventas);
            }
            catch (Exception)
            {

                return 1;
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

        public int CreateUsuario(tbUsuarios usuarios)
        {

            return _usuariosRepository.Insert(usuarios);




        }

        public int EditUsuario(tbUsuarios usuarios)
        {
            try
            {
                return _usuariosRepository.Update(usuarios);
            }
            catch (Exception)
            {

                return 1;
            }
        }

        public int DeleteUsuario(tbUsuarios usuarios)
        {
            try
            {
                return _usuariosRepository.Delete(usuarios);
            }
            catch (Exception)
            {

                return 1;
            }
        }

        public tbUsuarios BuscarUsuario(int? id)
        {
            return _usuariosRepository.Find(id);
        }

        #endregion
    }
}

