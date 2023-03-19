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

        [HttpGet("/Municipio/Listado")]
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




        public ActionResult getDepartment()
        {
            try
            {

                var Deptos = _generalesService.ListadoDepartamentos();
                return Json(Deptos);

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
        }


        [HttpGet("/Municipio/DatosIdMunicipio")]
        public JsonResult DatosIdMunicipio(string mun_Id)
        {
            var Municipios = _generalesService.CargarDatosMuniPorId(mun_Id);
            return Json(Municipios);
        }




        //public ActionResult Edit(int? id)
        //{

        //    var tbMunicipios = db.UDF_Gral_tbMunicipios_CARGAR(id).ToList();
        //    return Json(new { success = true, mun_Id = tbMunicipios[0].mun_ID, mun_Descripcion = tbMunicipios[0].mun_Descripcion, mun_DepId = tbMunicipios[0].mun_depID });

        //}




        [HttpPost("/Municipio/Edit")]
        public ActionResult Edit(int mun_Id, int mun_DepId, string mun_Descripcion)
        {

            tbMunicipios muni = new tbMunicipios();
            muni.mun_ID = mun_Id;
            muni.mun_Descripcion = mun_Descripcion;
            muni.mun_depID = mun_DepId;
            muni.mun_UsuarioModi = 1;

            var mun = _mapper.Map<tbMunicipios>(muni);
            var resultado = _generalesService.UpdateMuni(mun);

            return RedirectToAction("Index");

        }

    }
}
