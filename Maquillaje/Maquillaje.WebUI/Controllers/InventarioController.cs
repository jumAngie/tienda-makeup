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
    public class InventarioController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;

        public InventarioController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Inventario/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoInventario();
            var listadoMapeado = _mapper.Map<IEnumerable<InventarioViewModel>>(listado);
            return View(listadoMapeado);
        }
    }

    
}
