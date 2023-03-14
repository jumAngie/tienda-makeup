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
     public class ClienteController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;

        public ClienteController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Cliente/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoClientes();
            var ListadoMapeado = _mapper.Map<IEnumerable<ClientesViewModel>>(listado);
            return View(ListadoMapeado);
        }
    }
}
