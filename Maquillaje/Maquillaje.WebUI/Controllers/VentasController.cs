using AutoMapper;
using Maquillaje.BusinessLogic.Services;
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
    }
}
