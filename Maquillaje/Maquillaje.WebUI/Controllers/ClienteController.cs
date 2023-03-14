using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.DataAccess;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
     public class ClienteController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;
        private TiendaContext db = new TiendaContext();

        public ClienteController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Cliente/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoClientes();
            var ListadoMapeado = _mapper.Map<IEnumerable<ClientesViewModel>>(listado);
            return View(ListadoMapeado);
        }

        [HttpGet("/Cliente/Create")]

        public IActionResult Create()
        {
            //ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
            //ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
            return View();
        }
    }
}
