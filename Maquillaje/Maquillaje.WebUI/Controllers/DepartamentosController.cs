using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
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
            var listado = _generalesService.ListadoDepartamentos();
            var listadoMapeado = _mapper.Map<IEnumerable<DepartamentosViewModel>>(listado);
            return View(listadoMapeado);
        }

        [HttpPost("/Departamentos/Create")]
        public IActionResult Create(string dep_Descripcion)
        {
            tbDepartamentos depto = new tbDepartamentos();
            depto.dep_Descripcion = dep_Descripcion;
            depto.dep_UsuarioCrea = 1;
            var dep = _mapper.Map<tbDepartamentos>(depto);
            var result = _generalesService.CreateDepto(dep);

            return RedirectToAction("Index");

        }


        [HttpGet("/Departamentos/Editar/{id}")]
        public IActionResult Edit(int? id)
        {
            var listado = _generalesService.BuscarDepto(id);
            return View(listado);
        }

        [HttpPost("/Departamentos/Editar")]
        public IActionResult Edit(int dep_Id, string dep_Descripcion)
        {
            tbDepartamentos depto = new tbDepartamentos();
            depto.dep_ID = dep_Id;
            depto.dep_Descripcion = dep_Descripcion;
            depto.dep_UsuarioCrea = 1;
            var dep = _mapper.Map<tbDepartamentos>(depto);
            var result = _generalesService.EditDepto(dep);

            return RedirectToAction("Index");
        }




        public IActionResult Details(int id)
        {

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
