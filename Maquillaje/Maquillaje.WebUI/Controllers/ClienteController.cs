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

        public bool ExisteDni(string dni)
        {
            using (var db = new TiendaContext())
            {
                return db.tbClientes.Any(p => p.cli_DNI == dni);
            }
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


            var fechas = item.cli_FechaNacimiento.ToString();
            if (ModelState.IsValid)
            {

                if (item.cli_Nombre != null && item.cli_Apellido != null && item.cli_DNI != null && item.cli_EstadoCivil != "0" &&
                    fechas != "01/01/0001 0:00:00" && item.cli_Sexo != null && item.cli_Telefono != null && item.depto != "0" &&
                   (item.cli_Municipio != null && item.cli_Municipio != "0"))
                {

                    string[] f = fechas.Split('/');
                    string[] año = f[2].Split(' ');
                    string FechaValida = año[0] + "/" + f[1] + "/" + f[0];

                    string Nombre = item.cli_Nombre;
                    string Sexo = item.cli_Sexo;
                    string Municipio = item.cli_Municipio;
                    string Telefono = item.cli_Telefono;
                    string Apellido = item.cli_Apellido;
                    string DNI = item.cli_DNI;
                    string Civil = item.cli_EstadoCivil;
                    string depto = item.depto;
                    if (ExisteDni(DNI))
                    {
                        ModelState.AddModelError("ValidarDNI", "El DNI ya existe");
                        ViewBag.cli_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
                        ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion", ViewBag.depto);
                        return View(item);

                    }
                    else
                    {
                        _generalesService.CreateClientes(Nombre, Apellido, DNI, FechaValida, Sexo, Telefono, Int32.Parse(Municipio), Int32.Parse(Civil), 1);

                        return RedirectToAction("Index");
                    }


                }
                else
                {
                    if (item.depto == "0") { ModelState.AddModelError("ValidarDep", "*"); }
                    if (item.cli_EstadoCivil == "0") { ModelState.AddModelError("ValidarCivil", "*"); }
                    ViewBag.cli_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion", ViewBag.item.depto);
                    ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
                    return View(item);
                }


            }
            else
            {
                if (item.depto == "0") { ModelState.AddModelError("ValidarDep", "*"); }
                if (item.cli_EstadoCivil == "0") { ModelState.AddModelError("ValidarCivil", "*"); }
                if (fechas == "01/01/0001 0:00:00") { ModelState.AddModelError("ValidarFecha", "*"); }
                ViewBag.cli_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
                ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
                return View(item);
            }



        }

        [HttpGet("/Cliente/CargarMunicipios/{depto}")]
        public JsonResult CargarMunicipios(int depto)
        {

            var ddl = db.UDF_Gral_tbMunicipio_DDL(depto).ToList();

            return Json(ddl);

        }

        // EDITAR // 

        [HttpGet("/Cliente/CargarInfo/{id}")]
        public JsonResult CargarInfo(int cli_ID)
        {
            int numero = 5;
            var ddl = db.UDF_Gral_tbClienteInfo_DDL(numero).ToList();

            return Json(ddl);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            
           var cliente =  _generalesService.ObtenerCliente(id);
            if(cliente == null)
            {
                return RedirectToAction("Index");
            }
            else
            {

                //var listadoMapeado = _mapper.Map<ClientesViewModel>(cliente);
                ViewBag.cli_EstadoCivil = new SelectList(db.tbEstadosCiviles, "est_ID", "est_Descripcion");
                ViewBag.depto = new SelectList(db.tbDepartamentos, "dep_ID", "dep_Descripcion");
                ViewBag.Municipio = new SelectList(db.tbMunicipios, "mun_ID", "mun_Descripcion");
                return View();
            }
        }

        // ELIMINAR //


    }
}
