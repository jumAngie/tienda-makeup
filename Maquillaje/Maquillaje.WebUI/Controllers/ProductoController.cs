using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.DataAccess;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class ProductoController : Controller
    {
        private TiendaContext db = new TiendaContext();
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;


        public ProductoController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        #region Listado
        [HttpGet("/Producto/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoProductos();
            var listadoMapeado = _mapper.Map<IEnumerable<ProductosViewModel>>(listado);
            return View(listadoMapeado);
        }
        #endregion


        #region Crear Productos
        [HttpGet("/Producto/Create")]

        public IActionResult Create()
        {
            
            ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
            ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
            return View();
        }

        // Condicionar Campos
        [HttpPost]
        public IActionResult Create(ProductosViewModel item)
        {
            if (ModelState.IsValid)
            {
                if(item.pro_Codigo != null && item.pro_Nombre != null && item.pro_PrecioUnitario != 0 && item.pro_Proveedor != "0"
                    && item.pro_StockInicial != null && item.pro_Categoria != 0)
                {
                    if(item.pro_StockInicial == "0")
                    {
                        return View(item);
                    }
                    else
                    {
                        _generalesService.CreateProductos(item.pro_Codigo, item.pro_Nombre, item.pro_StockInicial, item.pro_PrecioUnitario, Int32.Parse(item.pro_Proveedor),
                            1, item.pro_Categoria);
                        return RedirectToAction("Index");
                    }



                }
                else
                {
                    return View(item);
                }
                
            }
            else
            {
                return View(item);
            }
            
        }
        #endregion


        #region Editar Productos


        #endregion

        #region Elimar Productos

        [HttpPost("/Producto/Eliminar/")]
        public IActionResult Delete(int pro_Id)
        {

            tbProductos pro = new tbProductos();
            pro.pro_Id = pro_Id;


            var produ = _mapper.Map<tbProductos>(pro);
            var result = _generalesService.DeleteProductos(produ);


            return RedirectToAction("Index");
        }

        #endregion

    }
}
