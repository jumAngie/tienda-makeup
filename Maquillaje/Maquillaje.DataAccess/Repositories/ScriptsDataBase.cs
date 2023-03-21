using System;
using System.Collections.Generic;
using System.Text;

namespace Maquillaje.DataAccess.Repositories
{
    public class ScriptsDataBase
    {
        #region Categorias
        public static string CategoriasCrear = "UDP_Maqui_tbCategorias_CREAR";
        public static string CategoriasEditar = "UDP_Maqui_tbCategorias_EDITAR";
        public static string CategoriasEliminar = "UDP_Maqui_tbCategorias_ELIMINAR";
        public static string CategoriasDetalles = "UDP_tbCategorias_Detalles";
        #endregion

        #region Productos
        public static string ProductosCrear = "UDP_Maqui_tbProductos_CREAR";
        public static string ProductosEditar = "UDP_Maqui_tbProductos_UPDATE";
        public static string ProductosDetalles = "UDP_tbProductos_Detalles";
        public static string ProductosEliminar = "UDP_Gral_tbProductos_ELIMINAR";
        #endregion

        #region Empleados
        public static string EmpleadosCrear = "UDP_Gral_tbEmpleados_CREAR";
        public static string EmpleadosEditar = "UDP_Gral_tbEmpleados_UPDATE";
        public static string EmpleadosDetalles = "UDP_tbEmpleados_Detalles";
        public static string EmpleadosEliminar = "UDP_Gral_tbEmpleados_ELIMINAR";
        #endregion

        #region Clientes
        public static string ClientesCrear = "UDP_Gral_tbClientes_CREAR";
        public static string ClientesEditar = "UDP_Gral_tbClientes_UPDATE";
        public static string ClientesEliminar = "UDP_Gral_tbClientes_ELIMINAR";
        public static string UDP_Listar_Clientes = "Maqui.UDP_maqu_tbClientes_List";
        public static string ClientesDetalles = "UDP_tbClientes_Detalles";
        #endregion

        #region Estados
        public static string EstadosCivilesCrear = "UDP_Gral_tbEstadosCiviles_CREAR";
        public static string EstadosCivilesEditar = "UDP_Gral_tbEstadosCiviles_EDITAR";
        public static string EstadosCivilesDetalles = "UDP_tbEstadosCiviles_Detalles";

        #endregion

        #region Sucursales
        public static string SucursalesCrear = "UDP_Gral_tbSucursales_CREAR";
        public static string SucursalesEditar = "UDP_Gral_tbSucurusales_EDITAR";
        public static string SucursalesEliminar = "UDP_Gral_tbSucursales_ELIMINAR";
        public static string SucursalesDetalles = "UDP_tbSucursales_Detalles";
        #endregion

        #region Departamentos
        public static string DepartamentosCrear = "UDP_Gral_tbDepartamentos_CREAR";
        public static string DepartamentosEditar = "UDP_Gral_tbDepartamentos_EDITAR";
        public static string DepartamentosDetalles = "UDP_tbDepartamentos_Detalles";

        #endregion

        #region Municipios
        public static string MunicipiosCrear = "UDP_Gral_tbMunicipios_CREAR";
        public static string MunicipiosEditar = "UDP_Gral_tbMunicipios_EDITAR";
        public static string MunicipiosCargarCiudades = "UDP_tbDeptos_CARGAR";
        public static string MunicipiosCargar = "UDP_Gral_tbMunicipios_CARGAR";
        public static string MunicipiosDetalles = "UDP_tbMunicipios_Detalles";

        #endregion

        #region Usuarios
        public static string UsuariosCrear = "UDP_Gral_tbUsuarios_CREAR";
        public static string UsuariosEliminar = "UDP_Gral_tbUsuarios_ELIMINAR";
        public static string UsuariosEditar = "UDP_Gral_tbUsuarios_EDITAR";
        public static string ValidarLogin = "UDP_Login";
        public static string UsuariosDetalles = "UDP_tbUsuarios_Detalles";

        #endregion

        #region MetodoPago
        public static string MetodoPagoCrear = "UDP_Maqui_tbMetodoPago_CREAR";
        public static string MetodoPagoEditar = "UDP_Maqui_tbMetodoPago_EDITAR";
        public static string MetodoPagoEliminar = "UDP_Maqui_tbMetodoPago_ELIMINAR";
        public static string MetodoPagoDetalles = "UDP_tbMetodoPago_Detalles";

        #endregion

        #region Proveedores
        public static string ProveedoresCrear = "UDP_Maqui_tbProveedores_CREAR";
        public static string ProveedoresDetalles = "UDP_tbProveedores_Detalles";
        public static string ProveedoresEditar = "UDP_Maqui_tbProveedores_UPDATE";
        public static string ProveedoresEliminar = "UDP_Gral_tbProveedores_ELIMINAR";
        #endregion

        #region Ventas
        public static string VentasCrear = "UDP_Maqui_tbVentas_CREAR";
        public static string VentasEliminar = "UDP_Maqui_tbVentas_ELIMINAR";
        public static string IdVentaReciente = "Maqui.UDP_tbVentas_IdVentaReciente";
        public static string IngresarNuevaVenta = "Maqui.UDP_tbVentas_IngresarNuevaVenta";
        public static string UDP_Listar_Facturas = "Maqui.UDP_tbVentas_Listado";
        #endregion

        #region VentasDetalles
        public static string VentasDetallesCrear = "UDP_Maqui_tbVentasDetalle_CREAR";
        public static string IngresarNuevoDetalleVenta = "Maqui.UDP_tbVentas_IngresarNuevoDetalleVenta";
        public static string ActualizarDetalleVenta = "Maqui.UDP_tbDetallesVentas_ActualizarDetalleVenta";
        public static string EliminarDetalleVenta = "Maqui.UDP_tbDetallesVentas_EliminarDetalleVenta";
        public static string UDP_Listar_VentasDetalles = "Maqui.UDP_maqu_tbVentasDetalles_Listado";
        #endregion

        #region Inventario
        public static string InventarioCrear = "UDP_Maqui_tbInventario_CREAR";
        #endregion
    }
}
