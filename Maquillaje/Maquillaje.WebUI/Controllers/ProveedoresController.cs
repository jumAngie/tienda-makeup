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
    public class ProveedoresController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;

        public ProveedoresController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Proveedores/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoProveedores();
            var listadoMapeado = _mapper.Map<IEnumerable<ProveedoresViewModel>>(listado);
            return View(listadoMapeado);
        }
    }
}
