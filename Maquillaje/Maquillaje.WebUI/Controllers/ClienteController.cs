using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.DataAccess;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public TiendaContext db = new TiendaContext();

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

        [HttpGet("/Cliente/Create")]

        public IActionResult Create()
        {
            ViewBag.cli_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
            ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
            return View();
        }

        [HttpPost("/Cliente/Create")]

        public IActionResult Create(ClientesViewModel item)
        {
            
            string Depto = item.depto;
            if (ModelState.IsValid)
            {
                string fecha = item.cli_FechaNacimiento.ToString();
                string[] f = fecha.Split('/');
                string[] año = f[2].Split(' ');
                string FechaValida = año[0] + "/" + f[1] + "/" + f[0];

               
                string Nombre = item.cli_Nombre;
                string Sexo = item.cli_Sexo;
                string Municipio = item.cli_Municipio;
                string Telefono = item.cli_Telefono;
                string Apellido = item.cli_Apellido;
                string DNI = item.cli_DNI;
                string Civil = item.cli_EstadoCivil;
            }
            

            return View();
        }





        [HttpGet("/Cliente/CargarMunicipios/{depto}")]
        public JsonResult CargarMunicipios(int depto)
        {
            
            var ddl = db.UDF_Gral_tbMunicipio_DDL(depto).ToList();

            return Json(ddl);

        }
    }
}
