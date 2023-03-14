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


    }
}
