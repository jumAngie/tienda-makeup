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


        [HttpGet("/Venta/Listado")]
        public IActionResult Index()
        {

            var listado = _generalesService.ListadoFacturas();

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(listado);
        }

        [HttpGet("/Venta/Create")]
        public IActionResult Create(VentaDetallesViewModel item, VentaViewModel item2)
        {
            var ddlCliente = _generalesService.ListadoClientes(out string error).ToList();
            var ddlMetodo = _generalesService.ListadoMetodosPago().ToList();
            var ddlCategoria = _generalesService.ListadoCategorias(out string error1).ToList();
            var detalles = _generalesService.ListadoVentaDetalles(item.vde_VentaId);
            if(item.vde_VentaId == 0)
            {
                item.vde_VentaId = item2.ven_Id;
            }
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

        [HttpPost("/Venta/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VentaViewModel item, int prod_Id)
        {
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

        [HttpGet("/Venta/Update")]
        public IActionResult Update(int id)
        {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetalles(VentaDetallesViewModel item, VentaViewModel item2, tbVentas factura)
        {
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

        [HttpPost]
        public IActionResult Delete(int id, int idFactura, string esEditar2, VentaDetallesViewModel item, VentaViewModel item2)
        {
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
                    return RedirectToAction("Update", new { id = ViewBag.vde_VentaId });
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

        [HttpPost]
        public IActionResult Edit(VentaDetallesViewModel item)
        {
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

        //JSONS
        public IActionResult CargarProductos(int id)
        {
            var productos = _generalesService.ListadoProductos(id);
            return Json(productos);
        }

        public IActionResult PrecioProductos(int id)
        {
            var precio = _generalesService.PrecioProducto(id);
            return Json(precio);
        }

        public IActionResult RevisarStock(int id, int cantidad)
        {
            var stock = _generalesService.RevisarStock(id, cantidad);
            return Json(stock);
        }
    }
}

