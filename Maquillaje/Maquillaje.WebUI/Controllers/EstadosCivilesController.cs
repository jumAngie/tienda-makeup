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
            var listado = _generalesService.ListadoEstadosCiviles();
            var listadoMapeado = _mapper.Map<IEnumerable<EstadosCivilesViewModel>>(listado);
            return View(listadoMapeado);
        }





        [HttpPost("/EstadosCiviles/Create")]
        public IActionResult Create(string est_Descripcion)
        {
            tbEstadosCiviles esta = new tbEstadosCiviles();
            esta.est_Descripcion = est_Descripcion;
            esta.est_UsuarioCrea = 1;
            var est = _mapper.Map<tbEstadosCiviles>(esta);
            var result = _generalesService.CreateEstado(est);

            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {

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


        [HttpGet("/EstadosCiviles/Editar/{id}")]
        public IActionResult Edit(int? id)
        {
            var listado = _generalesService.BuscarEstado(id);
            return View(listado);
        }

        [HttpPost("/EstadosCiviles/Editar")]
        public IActionResult Edit(int est_ID, string est_Descripcion)
        {
            tbEstadosCiviles esta = new tbEstadosCiviles();
            esta.est_ID = est_ID;
            esta.est_Descripcion = est_Descripcion;
            esta.est_UsuarioModi = 1;

            var est = _mapper.Map<tbEstadosCiviles>(esta);
            var result = _generalesService.EditEstado(est);

            return RedirectToAction("Index");
        }

    }
}
