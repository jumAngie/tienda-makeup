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
using System.Net.Http;
using System.Text;
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
            if (TempData.ContainsKey("SuccessMessage"))
            {
                // Obtener el mensaje de éxito y eliminarlo de TempData
                string successMessage = TempData["SuccessMessage"].ToString();
                TempData.Remove("SuccessMessage");

                // Generar el código JavaScript para mostrar el Toast de Success
                string script = $"<script>toastr.success('{successMessage}', 'Éxito');</script>";
                ViewBag.SuccessMessageScript = script;
            }
            else
            {
                ViewBag.SuccessMessageScript = null;
            }
            return View(listadoMapeado);
        }
        #endregion


        #region Validaciones
        public bool ExisteCodigo(string codigo)
        {
            using (var db = new TiendaContext())
            {
                return db.tbProductos.Any(p => p.pro_Codigo == codigo);
            }
        }

        #endregion

        #region Mensajes

        public HttpResponseMessage MostrarToastDeExito()
        {
            string script = "<script>toastr.success('¡El proceso se completó correctamente!', 'Éxito');</script>";
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(script, Encoding.UTF8, "text/html");
            return response;
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
                    && item.pro_StockInicial != null && item.cat_Descripcion != "0")
                {

                    
                    if(item.pro_StockInicial == "0")
                    {
                        ModelState.AddModelError("StockCero", "* El Stock Inicial no puede ser cero.");
                        ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
                        ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
                        return View(item);
                    }
                    else
                    {
                        if (ExisteCodigo(item.pro_Codigo))
                        {
                            ModelState.AddModelError("Codigo", "* El código ingresado ya exsite.");
                            ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
                            ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
                            return View(item);
                        }
                        else
                        {
                            _generalesService.CreateProductos(item.pro_Codigo, item.pro_Nombre, item.pro_StockInicial, item.pro_PrecioUnitario, Int32.Parse(item.pro_Proveedor),
                            1, Int32.Parse(item.cat_Descripcion));
                            TempData["SuccessMessage"] = "El proceso se completó correctamente";
                            MostrarToastDeExito();
                            return RedirectToAction("Index");
                        }
                        
                    }



                }
                else
                {
                    if(item.cat_Descripcion == "0") { ModelState.AddModelError("ValidarCategoria", "*"); }
                    if(item.pro_Proveedor == "0") { ModelState.AddModelError("ValidarProveedor", "*"); }
                    ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
                    ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
                    return View(item);
                }
                
            }
            else
            {
                if (item.cat_Descripcion == "0") { ModelState.AddModelError("ValidarCategoria", "*"); }
                if (item.pro_Proveedor == "0") { ModelState.AddModelError("ValidarProveedor", "*"); }
                ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
                ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
                return View(item);
            }
            
        }
        #endregion

        #region Editar Productos
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            var producto = _generalesService.ObtenerProducto(id);
            if (producto == null)
            {
                return RedirectToAction("Index");
            }
            else
            {

                ProductosViewModel item = new ProductosViewModel();
                item.pro_Id = producto.pro_Id;
                item.pro_Codigo = producto.pro_Codigo;
                item.pro_Nombre = producto.pro_Nombre;
                item.pro_PrecioUnitario = producto.pro_PrecioUnitario;
                item.pro_Proveedor = producto.pro_Proveedor.ToString();
                item.pro_StockInicial = producto.pro_StockInicial;
                item.cat_Descripcion = producto.pro_Categoria.ToString();

                ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
                ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
                return View(item);
            }
        }

        #endregion

        #region Eliminar Productos

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
