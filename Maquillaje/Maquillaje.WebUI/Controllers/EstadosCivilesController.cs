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

        [HttpGet("/EstadosCiviles/Create")]

        public IActionResult Create()
        {
            return View();
        }
    }
}
