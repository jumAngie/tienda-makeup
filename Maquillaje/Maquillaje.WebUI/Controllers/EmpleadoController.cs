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


        #region Listado
        [HttpGet("/Empleado/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoEmpleados();
            var ListadoMapeado = _mapper.Map<IEnumerable<EmpleadosViewModel>>(listado);
            return View(ListadoMapeado);
        }
        #endregion

        #region Validaciones
        public bool ExisteDni(string dni)
        {
            using (var db = new TiendaContext())
            {
                return db.tbEmpleados.Any(p => p.emp_DNI == dni);
            }
        }
        #endregion

        #region Crear Empleado
        [HttpGet("/Empleado/Create")]

        public IActionResult Create()
        {
            ViewBag.emp_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
            ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
            ViewBag.emp_Sucursal = new SelectList(db.Vw_Gral_tbSucursales_DDL, "suc_Id", "suc_Descripcion");
            return View();
        }

        [HttpPost("/Empleado/Create")]

        public IActionResult Create(EmpleadosViewModel item)
        {
            var fechas = item.emp_FechaNacimiento.ToString();
            if (ModelState.IsValid)
            {
                if (item.emp_Nombre != null && item.emp_Apellido != null && item.emp_DNI != null && item.emp_EstadoCivil != "0" &&
                    fechas != "01/01/0001 0:00:00" && item.emp_Sexo != null && item.emp_Telefono != null && item.depto != "0" &&
                   (item.emp_Municipio != null && item.emp_Municipio != "0") && item.emp_Sucursal != "0")
                {
                    if(ExisteDni(item.emp_DNI))
                    {
                        ModelState.AddModelError("ValidarDNI", "El DNI ya existe");
                        ViewBag.emp_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
                        ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
                        ViewBag.emp_Sucursal = new SelectList(db.Vw_Gral_tbSucursales_DDL, "suc_Id", "suc_Descripcion");
                        return View(item);
                    }
                    else
                    {
                        string[] f = fechas.Split('/');
                        string[] año = f[2].Split(' ');
                        string FechaValida = año[0] + "/" + f[1] + "/" + f[0];
                        _generalesService.CreateEmpleados(item.emp_Nombre, item.emp_Apellido, item.emp_DNI, FechaValida, item.emp_Sexo,
                            Int32.Parse(item.emp_Municipio), item.emp_Telefono, item.emp_Correo, Int32.Parse(item.emp_EstadoCivil), Int32.Parse(item.emp_Sucursal), 1);
                        return RedirectToAction("Index");
                    }
                    
                }
                else
                {
                    if (item.depto == "0") { ModelState.AddModelError("ValidarDep", "*"); }
                    if (item.emp_EstadoCivil == "0") { ModelState.AddModelError("ValidarCivil", "*"); }
                    if (item.emp_Sucursal == "0") { ModelState.AddModelError("ValidarSucu", "*"); }
                    ViewBag.emp_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
                    ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
                    ViewBag.emp_Sucursal = new SelectList(db.Vw_Gral_tbSucursales_DDL, "suc_Id", "suc_Descripcion");
                    return View(item);
                }
                    
            }
            else
            {
                if(item.depto == "0") { ModelState.AddModelError("ValidarDep", "*"); }
                if(item.emp_EstadoCivil == "0") { ModelState.AddModelError("ValidarCivil", "*"); }
                if(item.emp_Sucursal == "0") { ModelState.AddModelError("ValidarSucu", "*"); }
                if(fechas == "01/01/0001 0:00:00") { ModelState.AddModelError("ValidarFecha", "*"); }
                ViewBag.emp_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
                ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
                ViewBag.emp_Sucursal = new SelectList(db.Vw_Gral_tbSucursales_DDL, "suc_Id", "suc_Descripcion");
                return View(item);
            }
        }

        [HttpGet("/Empleado/CargarMunicipios/{depto}")]
        public JsonResult CargarMunicipios(int depto)
        {

            var ddl = db.UDF_Gral_tbMunicipio_DDL(depto).ToList();

            return Json(ddl);

        }
        #endregion



    }
}
