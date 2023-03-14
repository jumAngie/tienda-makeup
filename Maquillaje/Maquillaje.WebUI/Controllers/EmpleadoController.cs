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
    public class EmpleadoController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;

        public EmpleadoController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Empleado/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoClientes();
            var ListadoMapeado = _mapper.Map<IEnumerable<EmpleadosViewModel>>(listado);
            return View(ListadoMapeado);
        }
    }
}
