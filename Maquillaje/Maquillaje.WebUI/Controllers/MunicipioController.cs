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
    public class MunicipioController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;
        public TiendaContext db = new TiendaContext();



        public MunicipioController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Municipios/Listado")]
        public IActionResult Index()
        {
            ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
            var listado = _generalesService.ListadoMunicipios();
            var listadoMapeado = _mapper.Map<IEnumerable<MunicipiosViewModel>>(listado);
            return View(listadoMapeado);
        }



        [HttpGet("/Municipio/Create")]
        public IActionResult Create()
        {
            ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
            return View();
        }



        [HttpPost("/Municipio/Create")]
        public IActionResult Create(string mun_Descripcion, int mun_DepId)
        {

            if (ModelState.IsValid)
            {
                tbMunicipios muni = new tbMunicipios();
                muni.mun_Descripcion = mun_Descripcion;
                muni.mun_depID = mun_DepId;
                muni.mun_UsuarioCrea = 1;

                var mun = _mapper.Map<tbMunicipios>(muni);
                _generalesService.CreateMuni(mun);
                ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
                return RedirectToAction("Index");
            }
        }

 
    }
}
