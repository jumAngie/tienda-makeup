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
    public class VentasController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;


        public VentasController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Ventas/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoVentas();
            var listadoMapeado = _mapper.Map<IEnumerable<VentasViewModel>>(listado);
            return View(listadoMapeado);
        }

        [HttpGet("/Ventas/Create")]

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("/Ventas/Eliminar/")]
        public IActionResult Delete(int ven_Id)
        {

            tbVentas ven = new tbVentas();
            ven.ven_Id = ven_Id;


            var vent = _mapper.Map<tbVentas>(ven);
            var result = _generalesService.DeleteVenta(vent);


            return RedirectToAction("Index");
        }

    }
}
