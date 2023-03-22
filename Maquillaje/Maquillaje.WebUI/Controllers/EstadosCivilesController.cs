using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class EstadosCivilesController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;


        public EstadosCivilesController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/EstadosCiviles/Listado")]
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


            var listado = _generalesService.ListadoEstadosCiviles();
            var listadoMapeado = _mapper.Map<IEnumerable<EstadosCivilesViewModel>>(listado);
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





        [HttpPost("/EstadosCiviles/Create")]
        public IActionResult Create(string est_Descripcion)
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
            tbEstadosCiviles esta = new tbEstadosCiviles();
            esta.est_Descripcion = est_Descripcion;
            esta.est_UsuarioCrea = usucrea;
            var est = _mapper.Map<tbEstadosCiviles>(esta);
            var result = _generalesService.CreateEstado(est);

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

            var cates = _generalesService.DetallesEstados(id);
            EstadosCivilesViewModel model = new EstadosCivilesViewModel();

            if (cates != null && cates.Length > 0)
            {
                model.est_ID = cates[0];
                model.est_Descripcion = cates[1];
                model.est_UsuarioCrea = cates[2];
                model.est_UsuarioModi = cates[3];
                model.est_FechaCrea = Convert.ToDateTime(cates[4]);
                model.est_FechaModi = Convert.ToDateTime(cates[5]);

            }
            ViewBag.UsuCrea = model.est_UsuarioCrea;
            ViewBag.UsuModi = model.est_UsuarioModi;

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


        [HttpGet("/EstadosCiviles/Editar/{id}")]
        public IActionResult Edit(int? id)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");


                    var listado = _generalesService.BuscarEstado(id);
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

        [HttpPost("/EstadosCiviles/Editar")]
        public IActionResult Edit(int est_ID, string est_Descripcion)
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
            tbEstadosCiviles esta = new tbEstadosCiviles();
            esta.est_ID = est_ID;
            esta.est_Descripcion = est_Descripcion;
            esta.est_UsuarioModi = usumodi;

            var est = _mapper.Map<tbEstadosCiviles>(esta);
            var result = _generalesService.EditEstado(est);

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
