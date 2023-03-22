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
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

            ViewBag.deptoCrea = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
            var listado = _generalesService.ListadoSucursales();
            var ListadoMapeado = _mapper.Map<IEnumerable<SucursalesViewModel>>(listado);
            return View(ListadoMapeado);
                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }

        }


        [HttpGet("/Sucursal/Create")]

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

            ViewBag.deptoCrea = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
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



        [HttpGet("/Sucursal/CargarMunicipios/{depto}")]
        public JsonResult CargarMunicipios(int depto)
        {

            var ddl = db.UDF_Gral_tbMunicipio_DDL(depto).ToList();

            return Json(ddl);

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

            var cates = _generalesService.DetallesSucu(id);
            SucursalesViewModel model = new SucursalesViewModel();

            if (cates != null && cates.Length > 0)
            {
                model.suc_Id = cates[0];
                model.suc_Municipio = cates[1];
                model.suc_Descripcion = cates[2];
                model.suc_UsuCrea = cates[3];
                model.suc_UsuModi = cates[4];
                model.suc_FechaCrea = Convert.ToDateTime(cates[5]);
                model.suc_FechaModi = Convert.ToDateTime(cates[6]);

            }
            ViewBag.UsuCrea = model.suc_UsuCrea;
            ViewBag.UsuModi = model.suc_UsuModi;

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



        [HttpPost("/Sucursal/Create")]
        public IActionResult Create(string suc_Descripcion, int suc_MunicipioCrea)
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
            tbSucursales sucu = new tbSucursales();
            sucu.suc_Descripcion = suc_Descripcion;
            sucu.suc_Municipio = suc_MunicipioCrea;
            sucu.suc_UsuCrea = usucrea;
            var suc = _mapper.Map<tbSucursales>(sucu);
            var result = _generalesService.CreateSucursales(suc);

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



        [HttpPost("/Sucursales/Cargar")]
        public JsonResult Cargar(int sucu_ID)
        {

            var tbSucursales = _generalesService.LlenarSucursal(sucu_ID);

            return Json(tbSucursales);
        }



        [HttpGet("/Sucursales/CargarDepartamento")]
        public JsonResult CargarDDLdepto()
        {

            var tbSucursales = _generalesService.CargaDep();

            return Json(tbSucursales);
        }



        [HttpPost("/Sucursales/CargarMunicipio/{dep_ID}")]
        public JsonResult CargarDdlmuni(int dep_ID)
        {

            var tbSucursales = _generalesService.CargaMuni(dep_ID);

            return Json(tbSucursales);
        }



        [HttpPost("/Sucursales/Editar")]
        public ActionResult EditarSucursales(tbSucursales tbSucursales)
        {
            _generalesService.EditarSucursal(tbSucursales);
            return RedirectToAction("Index");

        }




        [HttpPost("/Sucursal/Eliminar/")]
        public IActionResult Delete(int suc_Id)
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
            tbSucursales suc = new tbSucursales();
            suc.suc_Id = suc_Id;
                    suc.suc_usuModi = usumodi;


            var sucu = _mapper.Map<tbSucursales>(suc);
            var result = _generalesService.DeleteSucursales(sucu);


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


    }
}


