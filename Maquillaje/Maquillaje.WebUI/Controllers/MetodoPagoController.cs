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
    public class MetodoPagoController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;



        public MetodoPagoController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/MetodoPago/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoMetodoPago();
            var ListadoMapeado = _mapper.Map<IEnumerable<MetodoPagoViewModel>>(listado);
            return View(ListadoMapeado);
        }


        [HttpPost("/MetodoPago/Create")]
        public IActionResult Create(string met_Descripcion)
        {
            tbMetodoPago cate = new tbMetodoPago();
            cate.met_Descripcion = met_Descripcion;
            cate.met_UsuCrea = 1;
            var met = _mapper.Map<tbMetodoPago>(cate);
            var result = _generalesService.CreateMetodoPago(met);

            return RedirectToAction("Index");

        }


        [HttpGet("/MetodoPago/Editar/{id}")]
        public IActionResult Edit(int? id)
        {
            var listado = _generalesService.BuscarMetodoPago(id);
            return View(listado);
        }

        [HttpPost("/MetodoPago/Editar")]
        public IActionResult Edit(int met_Id, string met_Descripcion)
        {
            tbMetodoPago meto = new tbMetodoPago();
            meto.met_Id = met_Id;
            meto.met_Descripcion = met_Descripcion;
            meto.met_usuModi = 1;

            var met = _mapper.Map<tbMetodoPago>(meto);
            var result = _generalesService.EditMetodoPago(met);

            return RedirectToAction("Index");
        }


        [HttpPost("/MetodoPago/Eliminar/")]
        public IActionResult Delete(int met_Id)
        {

            tbMetodoPago meto = new tbMetodoPago();
            meto.met_Id = met_Id;
            meto.met_usuModi = 1;


            var met = _mapper.Map<tbMetodoPago>(meto);
            var result = _generalesService.DeleteMetodoPago(met);


            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {

            var cates = _generalesService.DetallesMetodo(id);
            MetodoPagoViewModel model = new MetodoPagoViewModel();

            if (cates != null && cates.Length > 0)
            {
                model.met_Id = cates[0];
                model.met_Descripcion = cates[1];
                model.met_UsuCrea = cates[2];
                model.met_UsuModi = cates[3];
                model.met_FechaCrea = Convert.ToDateTime(cates[4]);
                model.met_FechaModi = Convert.ToDateTime(cates[5]);

            }
            ViewBag.UsuCrea = model.met_UsuCrea;
            ViewBag.UsuModi = model.met_UsuModi;

            if (cates == null)
            {
                return RedirectToAction("Index"); // acá vamos a redireccionar a la pagina 404
            }
            return View(model);



        }



    }
}
