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

        #endregion

        #region Productos
        public static string ProductosCrear = "UDP_Maqui_tbProductos_CREAR";
        public static string ProductosEditar = "UDP_Maqui_tbProductos_UPDATE";
        public static string ProductosEliminar = "UDP_Gral_tbProductos_ELIMINAR";
        #endregion

        #region Empleados
        public static string EmpleadosCrear = "UDP_Gral_tbEmpleados_CREAR";
        public static string EmpleadosEditar = "UDP_Gral_tbEmpleados_UPDATE";
        public static string EmpleadosEliminar = "UDP_Gral_tbEmpleados_ELIMINAR";
        #endregion

        #region Clientes
        public static string ClientesCrear = "UDP_Gral_tbClientes_CREAR";
        public static string ClientesEditar = "UDP_Gral_tbClientes_UPDATE";
        public static string ClientesEliminar = "UDP_Gral_tbClientes_ELIMINAR";
        #endregion

        #region Estados
        public static string EstadosCivilesCrear = "UDP_Gral_tbEstadosCiviles_CREAR";
        public static string EstadosCivilesEditar = "UDP_Gral_tbEstadosCiviles_EDITAR";
        #endregion

        #region Sucursales
        public static string SucursalesCrear = "UDP_Gral_tbSucursales_CREAR";
        public static string SucursalesEditar = "UDP_Gral_tbSucurusales_EDITAR";
        public static string SucursalesEliminar = "UDP_Gral_tbSucursales_ELIMINAR";
        #endregion

        #region Departamentos
        public static string DepartamentosCrear = "UDP_Gral_tbDepartamentos_CREAR";
        public static string DepartamentosEditar = "UDP_Gral_tbDepartamentos_EDITAR";
        #endregion

        #region Municipios
        public static string MunicipiosCrear = "UDP_Gral_tbMunicipios_CREAR";
        public static string MunicipiosEditar = "UDP_Gral_tbMunicipios_EDITAR";
        public static string MunicipiosCargarDatosId = "UDP_tbMunicipios_CargarDatosEditarPorIdmunicipio";

        #endregion

        #region Usuarios
        public static string UsuariosCrear = "UDP_Gral_tbUsuarios_CREAR";
        public static string UsuariosEliminar = "UDP_Gral_tbUsuarios_ELIMINAR";
        public static string UsuariosEditar = "UDP_Gral_tbUsuarios_EDITAR";
        #endregion

        #region MetodoPago
        public static string MetodoPagoCrear = "UDP_Maqui_tbMetodoPago_CREAR";
        public static string MetodoPagoEditar = "UDP_Maqui_tbMetodoPago_EDITAR";
        public static string MetodoPagoEliminar = "UDP_Maqui_tbMetodoPago_ELIMINAR";
        #endregion

        #region Proveedores
        public static string ProveedoresCrear = "UDP_Maqui_tbProveedores_CREAR";
        public static string ProveedoresEditar = "UDP_Maqui_tbProveedores_UPDATE";
        public static string ProveedoresEliminar = "UDP_Gral_tbProveedores_ELIMINAR";
        #endregion

        #region Ventas
        public static string VentasCrear = "UDP_Maqui_tbVentas_CREAR";
        public static string VentasEliminar = "UDP_Maqui_tbVentas_ELIMINAR";
        #endregion

        #region VentasDetalles
        public static string VentasDetallesCrear = "UDP_Maqui_tbVentasDetalle_CREAR";
        #endregion

        #region Inventario
        public static string InventarioCrear = "UDP_Maqui_tbInventario_CREAR";
        #endregion
    }
}
