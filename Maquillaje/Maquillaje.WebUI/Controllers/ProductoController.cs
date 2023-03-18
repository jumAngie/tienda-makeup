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

        public HttpResponseMessage MostrarToastDeAdvertencia()
        {
            string script = "<script>toastr.warning('El Stock Inicial no puede ser cero.', 'Advertencia');</script>";
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(script, Encoding.UTF8, "text/html");
            return response;
        }

        public HttpResponseMessage MostrarToastDeError()
        {
            string script = "<script>toastr.error('El código ingresado ya existe.', 'Error');</script>";
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
            if (TempData.ContainsKey("WarningMessage"))
            {
                
                string warningMessage = TempData["WarningMessage"].ToString();
                TempData.Remove("WarningMessage");

                
                string script = $"<script>toastr.warning('{warningMessage}', 'Advertencia');</script>";
                ViewBag.WarningMessageScript = script;
            }
            else
            {
                ViewBag.WarningMessageScript = null;
            }

            if (TempData.ContainsKey("ErrorMessage"))
            {

                string errorMessage = TempData["ErrorMessage"].ToString();
                TempData.Remove("ErrorMessage");


                string script = $"<script>toastr.error('{errorMessage}', 'Error');</script>";
                ViewBag.ErrorMessageScript = script;
            }
            else
            {
                ViewBag.ErrorMessageScript = null;
            }
            if (ModelState.IsValid)
            {
                if(item.pro_Codigo != null && item.pro_Nombre != null && item.pro_PrecioUnitario != 0 && item.pro_Proveedor != "0"
                    && item.pro_StockInicial != null && item.cat_Descripcion != "0")
                {

                    
                    if(item.pro_StockInicial == "0")
                    {
                        ModelState.AddModelError("StockCero", "*");
                        TempData["ErrorMessage"] = "El Stock Inicial no puede ser cero.";
                        MostrarToastDeAdvertencia();
                        ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
                        ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
                        return View(item);
                    }
                    else
                    {

                        if (ExisteCodigo(item.pro_Codigo))
                        {
                            ModelState.AddModelError("Codigo", "*");
                            TempData["WarningMessage"] = "El código ingresado ya existe.";
                            MostrarToastDeError();
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
