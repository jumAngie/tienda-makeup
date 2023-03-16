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
