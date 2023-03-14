﻿using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class SucursalController : Controller
    {

        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;

        public SucursalController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Sucursal/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoSucursales();
            var ListadoMapeado = _mapper.Map<IEnumerable<SucursalesViewModel>>(listado);
            return View(ListadoMapeado);
        }
    }
}