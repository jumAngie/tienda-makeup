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
    public class DepartamentosController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;


        public DepartamentosController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Departamentos/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoDepartamentos();
            var listadoMapeado = _mapper.Map<IEnumerable<DepartamentosViewModel>>(listado);
            return View(listadoMapeado);
        }

        [HttpGet("/Departamentos/Create")]

        public IActionResult Create()
        {
            return View();
        }
    }
}
