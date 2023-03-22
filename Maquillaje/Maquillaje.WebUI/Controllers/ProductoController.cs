using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.DataAccess;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Http;
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

            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");


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

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }




        }
        #endregion

        #region Detalles
        public IActionResult Details(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

                        var cates = _generalesService.DetallesProductos(id);
                        ProductosViewModel model = new ProductosViewModel();

                        if (cates != null && cates.Length > 0)
                        {
                            model.pro_Id = cates[0];
                            model.pro_Codigo = cates[1];
                            model.pro_Nombre = cates[2];
                            model.pro_StockInicial = cates[3];
                            model.pro_PrecioUnitario = cates[4];
                            model.pro_Proveedor = cates[5];
                            model.cat_Descripcion = cates[6];
                            model.pro_usuCrea = cates[7];
                            model.pro_UsuModi = cates[8];
                            model.pro_FechaCrea = Convert.ToDateTime(cates[9]);
                            model.pro_FechaModi = Convert.ToDateTime(cates[10]);



                        }
                        ViewBag.UsuCrea = model.pro_usuCrea;
                        ViewBag.UsuModi = model.pro_UsuModi;

                        if (cates == null)
                        {
                            return RedirectToAction("Index"); // acá vamos a redireccionar a la pagina 404
                        }
                        return View(model);
                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }


     



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

        public bool ExisteCodigoEditar(int id, string codigo)
        {
            var registrosConMismoCodigo = db.tbProductos.Where(r => r.pro_Id != id && r.pro_Codigo == codigo).ToList();
            if (registrosConMismoCodigo.Count > 0)
            {
                return true;
            }
            else
                return false;
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
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");


            ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
            ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
            return View();


                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }

        }

        // Condicionar Campos
        [HttpPost]
        public IActionResult Create(ProductosViewModel item)
        {

            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

                    int usucrea = int.Parse(HttpContext.Session.GetString("usu_ID"));


                    if (ModelState.IsValid)
            {
                if (item.pro_Codigo != null && item.pro_Nombre != null && item.pro_PrecioUnitario != null && item.pro_Proveedor != "0"
                    && (item.pro_StockInicial != null || item.pro_StockInicial != "0") && item.cat_Descripcion != "0")
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
                            usucrea, Int32.Parse(item.cat_Descripcion));
                            TempData["SuccessMessage"] = "El proceso se completó correctamente";
                            MostrarToastDeExito();
                            return RedirectToAction("Index");
                        }

                }
                else
                {
                    if(item.pro_StockInicial == "0" || item.pro_StockInicial == null) { ModelState.AddModelError("StockCero", "*"); }
                    if (item.cat_Descripcion == "0") { ModelState.AddModelError("ValidarCategoria", "*"); }
                    if (item.pro_Proveedor == "0") { ModelState.AddModelError("ValidarProveedor", "*"); }
                    ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
                    ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
                    return View(item);
                }

            }
            else
            {
                        if (item.pro_StockInicial == "0" || item.pro_StockInicial == null) { ModelState.AddModelError("StockCero", "*"); }
                        if (item.cat_Descripcion == "0") { ModelState.AddModelError("ValidarCategoria", "*"); }
                        if (item.pro_Proveedor == "0") { ModelState.AddModelError("ValidarProveedor", "*"); }
                ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
                ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
                return View(item);
            }

                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }


        }
        #endregion

        #region Editar Productos
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");


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

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }



        }

        [HttpPost]

        public IActionResult Edit(ProductosViewModel item)
        {

            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

                    int usumodi = int.Parse(HttpContext.Session.GetString("usu_ID"));

            ModelState.Remove(item.pro_StockInicial);
            if(ModelState.IsValid)
            {
                if(item.pro_Codigo != null && item.pro_Nombre != null && item.pro_PrecioUnitario != null && item.pro_Proveedor != "0"
                     && item.cat_Descripcion != "0")
                {
                    if (ExisteCodigoEditar(item.pro_Id, item.pro_Codigo))
                    {
                        ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
                        ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
                        ModelState.AddModelError("Codigo", "* El código ingresado ya existe.");
                        return View(item);
                    }
                    else
                    {
                        _generalesService.EditProductos(item.pro_Id, item.pro_Codigo, item.pro_Nombre,  item.pro_PrecioUnitario, Int32.Parse(item.pro_Proveedor)
                            , usumodi, Int32.Parse(item.cat_Descripcion));
                        TempData["SuccessMessage"] = "El proceso se completó correctamente";
                        MostrarToastDeExito();
                        return RedirectToAction("Index");
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
            else
            {   
                if (item.cat_Descripcion == "0") { ModelState.AddModelError("ValidarCategoria", "*"); }
                if (item.pro_Proveedor == "0") { ModelState.AddModelError("ValidarProveedor", "*"); }
                ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
                ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
                return View(item);
            }

                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }


        }

        #endregion

        #region Eliminar Productos

        [HttpPost("/Producto/Eliminar/")]
        public IActionResult Delete(int pro_Id)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");
                    int usumodi = int.Parse(HttpContext.Session.GetString("usu_ID"));

                    tbProductos pro = new tbProductos();
                        pro.pro_Id = pro_Id;
                        pro.pro_UsuModi = usumodi;


                        var produ = _mapper.Map<tbProductos>(pro);
                        var result = _generalesService.DeleteProductos(produ);


                        return RedirectToAction("Index");

                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }

        }

        #endregion

    }
}
