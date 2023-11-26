using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class VentaController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;

        public VentaController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }




        //public IActionResult Details(int id)
        //{


        //    if (HttpContext.Session.GetString("usu_Nombre") != null)
        //    {
        //        ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
        //        ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
        //        ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
        //        ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");



        //        var cates = _generalesService.DetallesVenta(id);
        //        VentaViewModel model = new VentaViewModel();

        //        if (cates != null && cates.Length > 0)
        //        {
        //            model.ven_Id = cates[0];
        //            model.cliente = cates[1];
        //            model.empleado = cates[2];
        //            model.ven_Fecha = cates[3];
        //            model.crea = cates[4];
        //            model.modi = cates[5];
        //            model.ven_FechaCrea = Convert.ToDateTime(cates[6]);
        //            model.ven_FechaModi = Convert.ToDateTime(cates[7]);
        //            model.metodo = cates[8];


        //        }
        //        ViewBag.UsuCrea = model.crea;
        //        ViewBag.UsuModi = model.modi;

        //        if (cates == null)
        //        {
        //            return RedirectToAction("Index"); // acá vamos a redireccionar a la pagina 404
        //        }
        //        return View(model);
        //    }

        //    return RedirectToAction("Index", "Login");









        //}



        [HttpGet("/Venta/Listado")]
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

            var listado = _generalesService.ListadoFacturas();

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(listado);
                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }

        }

        [HttpGet("/Venta/Create")]
        public IActionResult Create(VentaDetallesViewModel item, VentaViewModel item2)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

            if (item.vde_VentaId == 0)
            {
                item.vde_VentaId = item2.ven_Id;
            }
            var ddlCliente = _generalesService.ListadoClientes(out string error).ToList();
            var ddlMetodo = _generalesService.ListadoMetodosPago().ToList();
            var ddlCategoria = _generalesService.ListadoCategorias(out string error1).ToList();
            var detalles = _generalesService.ListadoVentaDetalles(item.vde_VentaId);
            
            ViewBag.cate = new SelectList(ddlCategoria, "cat_Id", "cat_Descripcion");
            ViewBag.ven_Cliente = new SelectList(ddlCliente, "cli_ID", "cli_Nombre");
            ViewBag.ven_MetodoPago = new SelectList(ddlMetodo, "met_Id", "met_Descripcion");
            ViewBag.detalles = detalles;
            ViewBag.vde_VentaId = item.vde_VentaId;
            ViewBag.esEditar = false;

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(item2);
                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }

        }

        [HttpPost("/Venta/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VentaViewModel item, int prod_Id)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");
            item.ven_UsuCrea = ViewBag.usu_Id = Int32.Parse(HttpContext.Session.GetString("usu_ID"));
            item.ven_Sucursal = ViewBag.suc_Id = Int32.Parse(HttpContext.Session.GetString("suc_Id"));
            item.ven_Empleado = 1;
            var factura = _mapper.Map<tbVentas>(item);
            var insertar = _generalesService.InsertFacturas(factura);

            var ddlCliente = _generalesService.ListadoClientes(out string error).ToList();
            var ddlMetodo = _generalesService.ListadoMetodosPago().ToList();
            var ddlCategoria = _generalesService.ListadoCategorias(out string error1).ToList();
            var detalles = _generalesService.ListadoVentaDetalles(item.ven_Id);


            ViewBag.cate = new SelectList(ddlCategoria, "cat_Id", "cat_Descripcion");
            ViewBag.ven_Cliente = new SelectList(ddlCliente, "cli_ID", "cli_Nombre");
            ViewBag.ven_MetodoPago = new SelectList(ddlMetodo, "met_Id", "met_Descripcion");
            ViewBag.detalles = detalles;
            ViewBag.esEditar = false;

            if (insertar != 0)
            {
                ViewBag.vde_VentaId = insertar;
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return View(item);

                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }

        }

        [HttpGet("/Venta/Update")]
        public IActionResult Update(int id)
        {

            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

            var factura = _generalesService.ObtenerIDFactura(id);

            if (factura == null)
            {
                return RedirectToAction("Index");
            }

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            var ddlCliente = _generalesService.ListadoClientes(out string error).ToList();
            var ddlMetodo = _generalesService.ListadoMetodosPago().ToList();
            var ddlCategoria = _generalesService.ListadoCategorias(out string error1).ToList();
            var detalles = _generalesService.ListadoVentaDetalles(id);

            ViewBag.cate = new SelectList(ddlCategoria, "cat_Id", "cat_Descripcion");
            ViewBag.ven_Cliente = new SelectList(ddlCliente, "cli_ID", "cli_Nombre");
            ViewBag.ven_MetodoPago = new SelectList(ddlMetodo, "met_Id", "met_Descripcion");
            ViewBag.detalles = detalles;
            ViewBag.vde_VentaId = id;

            return View(factura);
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
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetalles(VentaDetallesViewModel item, VentaViewModel item2, tbVentas factura)
        {

            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

            if (item.vde_VentaId < 1)
            {
                string script = "MostrarMensajeDanger('No se ha encontrado la factura');";
                TempData["Script"] = script;
                return RedirectToAction("Index");
            }

            item.vde_UsuCrea = ViewBag.usu_Id = Int32.Parse(HttpContext.Session.GetString("usu_ID"));
            var facturaDetalle = _mapper.Map<tbVentasDetalle>(item);
            var create = _generalesService.InsertFacturasDetalles(facturaDetalle);
            var detalles = _generalesService.ListadoVentaDetalles(item.vde_VentaId);
            var ddlCliente = _generalesService.ListadoClientes(out string error).ToList();
            var ddlMetodo = _generalesService.ListadoMetodosPago().ToList();
            var ddlCategoria = _generalesService.ListadoCategorias(out string error1).ToList();

            ViewBag.cate = new SelectList(ddlCategoria, "cat_Id", "cat_Descripcion");
            ViewBag.vde_VentaId = item.vde_VentaId;
            ViewBag.detalles = detalles;
            ViewBag.ven_Cliente = new SelectList(ddlCliente, "cli_ID", "cli_Nombre");
            ViewBag.ven_MetodoPago = new SelectList(ddlMetodo, "met_Id", "met_Descripcion");

            if (item.esEditar == "no")
            {
                if (create == 1)
                {
                    return RedirectToAction("Create", item);
                }
                else
                {
                    return RedirectToAction("Create", item);
                }
            }
            else
            {
                if (create == 1)
                {
                    return RedirectToAction("Update", new { id = ViewBag.vde_VentaId });
                }
                else
                {
                    return RedirectToAction("Update", new { id = ViewBag.vde_VentaId });
                }
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
        public IActionResult Delete(int id, int idFactura, string esEditar2, VentaDetallesViewModel item, VentaViewModel item2)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");
            var delete = _generalesService.DeleteFacturasDetalles(id);
            var detalles = _generalesService.ListadoVentaDetalles(idFactura);

            ViewBag.detalles = detalles;
            ViewBag.vde_VentaId = idFactura;
            item2.ven_Id = idFactura;

            if (esEditar2 == "no")
            {
                if (delete == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                    TempData["Script"] = script;
                    return RedirectToAction("Create", item2);
                }
                else
                {
                    string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                    TempData["Script"] = script;
                    return RedirectToAction("Create", item2);
                }
            }
            else
            {
                if (delete == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                    TempData["Script"] = script;
                    return RedirectToAction("Update", new { id = ViewBag.vde_VentaId });
                }
                else
                {
                    string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                    TempData["Script"] = script;
                    return RedirectToAction("Update", new { id = ViewBag.vde_VentaId });
                }
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
        public IActionResult Edit(VentaDetallesViewModel item)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");
            var facdetalle = _mapper.Map<tbVentasDetalle>(item);
            var update = _generalesService.UpdateFacturasDetalles(facdetalle);
            var ddlCategoria = _generalesService.ListadoCategorias(out string error1).ToList();
            var detalles = _generalesService.ListadoVentaDetalles(item.vde_VentaId);

            ViewBag.vde_VentaId = item.vde_VentaId;
            ViewBag.detalles = detalles;
            ViewBag.cate = new SelectList(ddlCategoria, "cat_Id", "cat_Descripcion");

            if (item.esEditar == "no")
            {
                if (update == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                    TempData["Script"] = script;
                    return RedirectToAction("Create", item);
                }
                else
                {
                    return RedirectToAction("Create", item);
                }
            }
            else
            {
                if (update == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                    TempData["Script"] = script;
                    return RedirectToAction("Update", new { id = ViewBag.vde_VentaId });
                }
                else
                {
                    string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                    TempData["Script"] = script;
                    return RedirectToAction("Update", new { id = ViewBag.vde_VentaId });
                }
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

        //JSONS
        public IActionResult CargarProductos(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

            var productos = _generalesService.ListadoProductos(id);
            return Json(productos);

                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
        }

        public IActionResult PrecioProductos(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

            var precio = _generalesService.PrecioProducto(id);
            return Json(precio);

                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
        }

        public IActionResult RevisarStock(int id, int cantidad)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

            var stock = _generalesService.RevisarStock(id, cantidad);
            return Json(stock);

                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
        }
    }
}

