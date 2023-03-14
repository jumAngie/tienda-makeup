using AutoMapper;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<CategoriaViewModel, Vw_Maqui_tbCategorias_LIST>().ReverseMap();
            CreateMap<ProductosViewModel, Vw_Maqui_tbProductos_LIST>().ReverseMap();
            CreateMap<InventarioViewModel, Vw_Maqui_tbInventario_LIST>().ReverseMap();
            CreateMap<ClientesViewModel, Vw_Gral_tbClientes_LIST>().ReverseMap();
            CreateMap<EmpleadosViewModel, Vw_Gral_tbEmpleados_LIST>().ReverseMap();
            CreateMap<SucursalesViewModel, Vw_Gral_tbSucursales_LIST>().ReverseMap();
            CreateMap<MunicipiosViewModel, Vw_Gral_tbMunicipios_LIST>().ReverseMap();
            CreateMap<DepartamentosViewModel, Vw_Gral_tbDepartamentos_LIST>().ReverseMap();
            CreateMap<EstadosCivilesViewModel, Vw_Gral_tbEstadosCiviles_LIST>().ReverseMap();
            CreateMap<MetodoPagoViewModel, Vw_Maqui_tbMetodoPago_LIST>().ReverseMap();
            CreateMap<ProveedoresViewModel, Vw_Maqui_tbProveedores_LIST>().ReverseMap();
            CreateMap<VentasViewModel, Vw_Maqui_tbVentas_LIST>().ReverseMap();
            CreateMap<UsuariosViewModel, Vw_Gral_tbUsuarios_LIST>().ReverseMap();
        }
    }
}
