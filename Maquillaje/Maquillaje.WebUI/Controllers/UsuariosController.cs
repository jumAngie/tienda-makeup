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
    public class UsuariosController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;



        public UsuariosController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Usuarios/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoUsuarios();
            var ListadoMapeado = _mapper.Map<IEnumerable<UsuariosViewModel>>(listado);
            return View(ListadoMapeado);
        }
    }
}
