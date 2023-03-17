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
    public class EmpleadoController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;
        public TiendaContext db = new TiendaContext();



        public EmpleadoController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Empleado/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoEmpleados();
            var ListadoMapeado = _mapper.Map<IEnumerable<EmpleadosViewModel>>(listado);
            return View(ListadoMapeado);
        }

        #region Crear Empleado
        [HttpGet("/Empleado/Create")]

        public IActionResult Create()
        {
            ViewBag.cli_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
            ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
            //ViewBag.emp_Sucursal = new SelectList(db.Vw_Maqui_tbSucursal)
            return View();
        }
        #endregion



    }
}
