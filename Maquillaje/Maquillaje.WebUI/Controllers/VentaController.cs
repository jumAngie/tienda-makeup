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

        //[HttpGet("/Facturas/Update")]
        //public IActionResult Update(int id)
        //{
        //    var factura = _maquService.ObtenerIDFactura(id);

        //    if (factura == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    if (TempData["Script"] is string script)
        //    {
        //        TempData.Remove("Script");
        //        ViewBag.Script = script;
        //    }

        //    var ddlCliente = _maquService.ListadoClientes(out string error).ToList();
        //    var ddlMetodo = _maquService.ListadoMetodosPago().ToList();
        //    var ddlCategoria = _maquService.ListadoCategorias(out string error1).ToList();
        //    var detalles = _maquService.ListadoFacturasDetalles(id);

        //    ViewBag.cate = new SelectList(ddlCategoria, "cate_Id", "cate_Nombre");
        //    ViewBag.clie_Id = new SelectList(ddlCliente, "clie_Id", $"clie_Nombres");
        //    ViewBag.meto_Id = new SelectList(ddlMetodo, "meto_Id", "meto_Nombre");
        //    ViewBag.detalles = detalles;
        //    ViewBag.fact_Id = id;

        //    return View(factura);
        //}





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

