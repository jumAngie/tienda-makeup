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
    public class MunicipioController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;


        public MunicipioController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Municipios/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoMunicipios();
            var listadoMapeado = _mapper.Map<IEnumerable<MunicipiosViewModel>>(listado);
            return View(listadoMapeado);
        }

        [HttpGet("/Municipios/Create")]

        public IActionResult Create()
        {
            return View();
        }
    }
}
