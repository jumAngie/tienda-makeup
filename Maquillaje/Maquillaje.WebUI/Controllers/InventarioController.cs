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
    public class InventarioController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;
        public TiendaContext db = new TiendaContext();


        public InventarioController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Inventario/Listado")]
        public IActionResult Index()
        {
            ViewBag.producto = new SelectList(db.Vw_Maqui_tbProductos_DDL, "pro_Id", "pro_Nombre");
            var listado = _generalesService.ListadoInventario();
            var listadoMapeado = _mapper.Map<IEnumerable<InventarioViewModel>>(listado);
            return View(listadoMapeado);
        }

        [HttpGet("/Inventario/Create")]
        public IActionResult Create()
        {
            ViewBag.producto = new SelectList(db.Vw_Maqui_tbProductos_DDL, "pro_Id", "pro_Nombre");
            return View();
        }


        [HttpPost("/Inventario/Create")]
        public IActionResult Create(int inv_Cantidad, int inv_Producto)
        {
            tbInventario inv = new tbInventario();
            inv.inv_Cantidad = inv_Cantidad;
            inv.inv_Producto = inv_Producto;
            inv.inv_UsuCrea = 1;
            var inve = _mapper.Map<tbInventario>(inv);
            var result = _generalesService.CreateInventario(inve);

            return RedirectToAction("Index");

        }
    }

    
}
