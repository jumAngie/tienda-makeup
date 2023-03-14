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
        }
    }
}
