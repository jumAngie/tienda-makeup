using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.DataAccess;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            if (TempData.ContainsKey("SuccessMessage"))
            {
                // Obtener el mensaje de éxito y eliminarlo de TempData
                string successMessage = TempData["SuccessMessage"].ToString();
                TempData.Remove("SuccessMessage");

                // Generar el código JavaScript para mostrar el Toast de Success
                string script = $"<script>toastr.success('{successMessage}', 'Éxito');</script>";
                ViewBag.SuccessMessageScript = script;
            }
            else
            {
                ViewBag.SuccessMessageScript = null;
            }
            return View(ListadoMapeado);
        }
        #endregion

        #region Mensajes

        public HttpResponseMessage MostrarToastDeExito()
        {
            string script = "<script>toastr.success('¡El proceso se completó correctamente!', 'Éxito');</script>";
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(script, Encoding.UTF8, "text/html");
            return response;
        }

        public HttpResponseMessage MostrarToastDeError()
        {
            string script = "<script>toastr.error('El DNI ingresado ya existe.', 'Error');</script>";
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(script, Encoding.UTF8, "text/html");
            return response;
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

            if (TempData.ContainsKey("ErrorMessage"))
            {
                // Obtener el mensaje de éxito y eliminarlo de TempData
                string errorMessage = TempData["ErrorMessage"].ToString();
                TempData.Remove("ErrorMessage");

                // Generar el código JavaScript para mostrar el Toast de Success
                string script = $"<script>toastr.error('{errorMessage}', 'Error');</script>";
                ViewBag.ErrorMessageScript = script;
            }
            else
            {
                ViewBag.ErrorMessageScript = null;
            }


            var fechas = item.emp_FechaNacimiento.ToString();
            if (ModelState.IsValid)
            {
                if (item.emp_Nombre != null && item.emp_Apellido != null && item.emp_DNI != null && item.emp_EstadoCivil != "0" &&
                    fechas != "01/01/0001 0:00:00" && item.emp_Sexo != null && item.emp_Telefono != null && item.depto != "0" &&
                   (item.emp_Municipio != null && item.emp_Municipio != "0") && item.emp_Sucursal != "0")
                {
                    if (ExisteDni(item.emp_DNI))
                    {
                        ModelState.AddModelError("ValidarDNI", "*");
                        TempData["ErrorMessage"] = "El DNI ingresado ya existe.";
                        MostrarToastDeError();
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


                        // QUITAR EL CAMPO DE AUDIOTRIA //
                        _generalesService.CreateEmpleados(item.emp_Nombre, item.emp_Apellido, item.emp_DNI, FechaValida, item.emp_Sexo,
                            Int32.Parse(item.emp_Municipio), item.emp_Telefono, item.emp_Correo, Int32.Parse(item.emp_EstadoCivil), Int32.Parse(item.emp_Sucursal), 1);
                        TempData["SuccessMessage"] = "El proceso se completó correctamente";
                        MostrarToastDeExito();
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
                if (item.depto == "0") { ModelState.AddModelError("ValidarDep", "*"); }
                if (item.emp_EstadoCivil == "0") { ModelState.AddModelError("ValidarCivil", "*"); }
                if (item.emp_Sucursal == "0") { ModelState.AddModelError("ValidarSucu", "*"); }
                if (fechas == "01/01/0001 0:00:00") { ModelState.AddModelError("ValidarFecha", "*"); }
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

        #region Editar Empleado
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var empleado = _generalesService.ObtenerEmpleado(id);
            if (empleado == null)
            {
                return RedirectToAction("Index");
            }
            else
            {

                EmpleadosViewModel emple = new EmpleadosViewModel();
                emple.emp_ID = empleado.emp_ID;
                emple.emp_Nombre = empleado.emp_Nombre;
                emple.emp_Apellido = emple.emp_Apellido;
                emple.emp_DNI = emple.emp_DNI;
                emple.emp_EstadoCivil = emple.emp_EstadoCivil.ToString();
                emple.emp_FechaNacimiento = emple.emp_FechaNacimiento;
                emple.emp_Municipio = emple.emp_Municipio.ToString();
                emple.emp_Sexo = emple.emp_Sexo;
                emple.emp_Telefono = emple.emp_Telefono;
                emple.emp_Correo = emple.emp_Correo;
                emple.emp_Sucursal = emple.emp_Sucursal;

                emple.depto = db.tbMunicipios.Where(m => m.mun_ID == empleado.emp_Municipio).Select(m => m.mun_depID).FirstOrDefault().ToString();

                ViewBag.emp_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
                ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
                ViewBag.emp_Municipio = new SelectList(db.tbMunicipios, "mun_ID", "mun_Descripcion");
                ViewBag.emp_Sucursal = new SelectList(db.Vw_Gral_tbSucursales_DDL, "suc_Id", "suc_Descripcion");
                return View(emple);
            }
        }

        [HttpPost]
        public IActionResult Edit(EmpleadosViewModel item)
        {
            var fechas = item.emp_FechaNacimiento.ToString();
            if (ModelState.IsValid)
            {
                if (item.emp_Nombre != null && item.emp_Apellido != null && item.emp_DNI != null && item.emp_EstadoCivil != "0" &&
                    fechas != "01/01/0001 0:00:00" && item.emp_Sexo != null && item.emp_Telefono != null && item.depto != "0" &&
                   (item.emp_Municipio != null && item.emp_Municipio != "0") && item.emp_Sucursal != "0")
                {
                    var registrosConMismoDNI = db.tbEmpleados.Where(r => r.emp_ID != item.emp_ID && r.emp_DNI == item.emp_DNI).ToList();
                    if (registrosConMismoDNI.Any())
                    {
                        ModelState.AddModelError("DNI", "*");
                        TempData["ErrorMessage"] = "El DNI ingresado ya existe.";
                        MostrarToastDeError();
                        if (item.depto == "0") { ModelState.AddModelError("ValidarDep", "*"); }
                        if (item.emp_EstadoCivil == "0") { ModelState.AddModelError("ValidarCivil", "*"); }
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

                        // CAMBIAR EL CAMPO DE AUDITORIA ESTÁ EN DURO  // 
                        _generalesService.UpdateEmpleados(item.emp_ID, item.emp_Nombre, item.emp_Apellido, item.emp_DNI, FechaValida, item.emp_Sexo,
                        Int32.Parse(item.emp_Municipio), item.emp_Telefono, item.emp_Correo, Int32.Parse(item.emp_EstadoCivil), Int32.Parse(item.emp_Sucursal), 1);
                        TempData["SuccessMessage"] = "El proceso se completó correctamente";
                        MostrarToastDeExito();
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
                if (item.depto == "0") { ModelState.AddModelError("ValidarDep", "*"); }
                if (item.emp_EstadoCivil == "0") { ModelState.AddModelError("ValidarCivil", "*"); }
                if (item.emp_Sucursal == "0") { ModelState.AddModelError("ValidarSucu", "*"); }
                if (fechas == "01/01/0001 0:00:00") { ModelState.AddModelError("ValidarFecha", "*"); }
                ViewBag.emp_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
                ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
                ViewBag.emp_Sucursal = new SelectList(db.Vw_Gral_tbSucursales_DDL, "suc_Id", "suc_Descripcion");
                return View(item);
            }
        }

        #endregion






    }
}
