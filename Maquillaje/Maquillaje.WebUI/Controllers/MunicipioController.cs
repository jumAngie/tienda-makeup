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
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");
            ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
            var listado = _generalesService.ListadoMunicipios();
            var listadoMapeado = _mapper.Map<IEnumerable<MunicipiosViewModel>>(listado);
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



        [HttpGet("/Municipio/Create")]
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
            ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
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



        [HttpPost("/Municipio/Create")]
        public IActionResult Create(string mun_Descripcion, int mun_DepId)
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
                tbMunicipios muni = new tbMunicipios();
                muni.mun_Descripcion = mun_Descripcion;
                muni.mun_depID = mun_DepId;
                muni.mun_UsuarioCrea = usucrea;

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

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }

        }






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

            var cates = _generalesService.DetallesMunis(id);
            MunicipiosViewModel model = new MunicipiosViewModel();

            if (cates != null && cates.Length > 0)
            {
                model.mun_ID = cates[0];
                model.mun_depID = cates[1];
                model.mun_Descripcion = cates[2];
                model.mun_UsuarioCrea = cates[3];
                model.mun_UsuarioModi = cates[4];
                model.mun_FechaCrea = Convert.ToDateTime(cates[5]);
                model.mun_FechaModi = Convert.ToDateTime(cates[6]);

            }
            ViewBag.UsuCrea = model.mun_UsuarioCrea;
            ViewBag.UsuModi = model.mun_UsuarioModi;

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




        //public ActionResult getDepartment()
        //{
        //    try
        //    {

        //        var Deptos = _generalesService.ListadoDepartamentos();
        //        return Json(Deptos);

        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("Index", "Home");
        //        throw;
        //    }
        //}




        //public ActionResult Edit(int? id)
        //{

        //    var tbMunicipios = db.UDF_Gral_tbMunicipios_CARGAR(id).ToList();
        //    return Json(new { success = true, mun_Id = tbMunicipios[0].mun_ID, mun_Descripcion = tbMunicipios[0].mun_Descripcion, mun_DepId = tbMunicipios[0].mun_depID });

        //}




        //[HttpPost("/Municipio/Edit")]
        //public ActionResult Edit(int mun_Id, int mun_DepId, string mun_Descripcion)
        //{

        //    tbMunicipios muni = new tbMunicipios();
        //    muni.mun_ID = mun_Id;
        //    muni.mun_Descripcion = mun_Descripcion;
        //    muni.mun_depID = mun_DepId;
        //    muni.mun_UsuarioModi = 1;

        //    var mun = _mapper.Map<tbMunicipios>(muni);
        //    var resultado = _generalesService.UpdateMuni(mun);

        //    return RedirectToAction("Index");

        //}




        [HttpGet("/Municipios/Cargar")]
        public JsonResult Cargar()
        {

            var cargaDepa = _generalesService.CargaDepa();

            return Json(cargaDepa);
        }


        [HttpGet("/Municipios/CargaPaEditar/{mun_Id}")]
        public JsonResult CargaPaEditar(int? mun_Id)
        {

            var CargaPaEditar = _generalesService.LlenarCiudades(mun_Id);

            return Json(CargaPaEditar);
        }


        [HttpGet("/Municipios/Editar/{mun_Id}/{mun_Descripcion}/{mun_DepIdEdit}")]
        public JsonResult Editar(int mun_Id, string mun_Descripcion, int mun_DepIdEdit)
        {

            var CargaPaEditar = _generalesService.EditarCiudades(mun_Id, mun_Descripcion, mun_DepIdEdit);

            return Json(CargaPaEditar);

        }



    }
}
