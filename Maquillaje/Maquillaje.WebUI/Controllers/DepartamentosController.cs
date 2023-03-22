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
    public class DepartamentosController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;


        public DepartamentosController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Departamentos/Listado")]
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

            var listado = _generalesService.ListadoDepartamentos();
            var listadoMapeado = _mapper.Map<IEnumerable<DepartamentosViewModel>>(listado);
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

        [HttpPost("/Departamentos/Create")]
        public IActionResult Create(string dep_Descripcion)
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
            tbDepartamentos depto = new tbDepartamentos();
            depto.dep_Descripcion = dep_Descripcion;
            depto.dep_UsuarioCrea = usucrea;
            var dep = _mapper.Map<tbDepartamentos>(depto);
            var result = _generalesService.CreateDepto(dep);

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


        [HttpGet("/Departamentos/Editar/{id}")]
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

            var listado = _generalesService.BuscarDepto(id);
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

        [HttpPost("/Departamentos/Editar")]
        public IActionResult Edit(int dep_Id, string dep_Descripcion)
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
            tbDepartamentos depto = new tbDepartamentos();
            depto.dep_ID = dep_Id;
            depto.dep_Descripcion = dep_Descripcion;
            depto.dep_UsuarioCrea = usumodi;
            var dep = _mapper.Map<tbDepartamentos>(depto);
            var result = _generalesService.EditDepto(dep);

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
            var cates = _generalesService.DetallesDepto(id);
            DepartamentosViewModel model = new DepartamentosViewModel();

            if (cates != null && cates.Length > 0)
            {
                model.dep_ID = cates[0];
                model.dep_Descripcion = cates[1];
                model.dep_UsuarioCrea = cates[2];
                model.dep_UsuarioModi = cates[3];
                model.dep_FechaCrea = Convert.ToDateTime(cates[4]);
                model.dep_FechaModi = Convert.ToDateTime(cates[5]);

            }
            ViewBag.UsuCrea = model.dep_UsuarioCrea;
            ViewBag.UsuModi = model.dep_UsuarioModi;

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


        [HttpPost("/Departamentos/Eliminar/")]
        public IActionResult Delete(int dep_Id)
        {

            tbDepartamentos depto = new tbDepartamentos();
            depto.dep_ID = dep_Id;

            var dep = _mapper.Map<tbDepartamentos>(depto);
            var result = _generalesService.DeleteDepto(dep);


            return RedirectToAction("Index");
        }
    }
}
