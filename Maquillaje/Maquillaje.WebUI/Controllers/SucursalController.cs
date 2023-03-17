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
    public class SucursalController : Controller
    {

        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;
        public TiendaContext db = new TiendaContext();

        public SucursalController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Sucursal/Listado")]
        public IActionResult Index()
        {
            ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
            var listado = _generalesService.ListadoSucursales();
            var ListadoMapeado = _mapper.Map<IEnumerable<SucursalesViewModel>>(listado);
            return View(ListadoMapeado);
        }


        [HttpGet("/Sucursal/Create")]

        public IActionResult Create()
        {
            ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
            return View();
        }



        [HttpGet("/Sucursal/CargarMunicipios/{depto}")]
        public JsonResult CargarMunicipios(int depto)
        {

            var ddl = db.UDF_Gral_tbMunicipio_DDL(depto).ToList();

            return Json(ddl);

        }



        [HttpPost("/Sucursal/Create")]
        public IActionResult Create(string suc_Descripcion, int suc_Municipio)
        {
            tbSucursales sucu = new tbSucursales();
            sucu.suc_Descripcion = suc_Descripcion;
            sucu.suc_Municipio = suc_Municipio;
            sucu.suc_UsuCrea = 1;
            var suc = _mapper.Map<tbSucursales>(sucu);
            var result = _generalesService.CreateSucursales(suc);

            return RedirectToAction("Index");

        }
    }
}


