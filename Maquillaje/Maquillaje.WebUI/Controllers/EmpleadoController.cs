using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.DataAccess;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Http;
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
        #region Detalles
        public IActionResult Details(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");


            var cates = _generalesService.DetallesEmpleados(id);
            EmpleadosViewModel model = new EmpleadosViewModel();

            if (cates != null && cates.Length > 0)
            {
                model.emp_ID = cates[0];
                model.emp_Nombre = cates[1];
                model.emp_Apellido = cates[2];
                model.emp_DNI = cates[3];
                model.emp_FechaNacimiento = cates[4];
                model.emp_Sexo = cates[5];
                model.emp_Telefono = cates[6];
                model.emp_Municipio = cates[7];
                model.emp_Correo = cates[8];
                model.emp_EstadoCivil = cates[9];
                model.emp_Sucursal = cates[10];
                model.emp_UsuarioCrea = cates[11];
                model.emp_UsuarioModi = cates[12];
                model.emp_FechaCrea = Convert.ToDateTime(cates[13]);
                model.emp_FechaModi = Convert.ToDateTime(cates[14]);



            }
            ViewBag.UsuCrea = model.emp_UsuarioCrea;
            ViewBag.UsuModi = model.emp_UsuarioModi;

            if (cates == null)
            {
                return RedirectToAction("Index"); // acá vamos a redireccionar a la pagina 404
            }
            return View(model);

                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }





        }
        #endregion

        #region Listado
        [HttpGet("/Empleado/Listado")]
        public IActionResult Index()
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");

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

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }


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

        #endregion

        #region Validaciones
        // EDITAR // 

        [HttpGet("/Empleado/CargarInfo/{emp_ID}")]
        public JsonResult CargarInfo(int emp_ID)
        {

            var ddl = db.UDF_Gral_tbEmpleadoInfo_DDL(emp_ID).ToList();

            return Json(ddl);

        }
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
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");


            ViewBag.emp_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
            ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
            ViewBag.emp_Sucursal = new SelectList(db.Vw_Gral_tbSucursales_DDL, "suc_Id", "suc_Descripcion");
            return View();
                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }

        }

        [HttpPost("/Empleado/Create")]

        public IActionResult Create(EmpleadosViewModel item)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");
                    int usucrea = int.Parse(HttpContext.Session.GetString("usu_ID"));
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
                            Int32.Parse(item.emp_Municipio), item.emp_Telefono, item.emp_Correo, Int32.Parse(item.emp_EstadoCivil), Int32.Parse(item.emp_Sucursal), usucrea);
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
                    if (fechas == "01/01/0001 0:00:00") { ModelState.AddModelError("ValidarFecha", "*"); }
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

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
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
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");
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
                emple.emp_Apellido = empleado.emp_Apellido;
                emple.emp_DNI = empleado.emp_DNI;
                emple.emp_EstadoCivil = empleado.emp_EstadoCivil.ToString();
                emple.emp_FechaNacimiento = empleado.emp_FechaNacimiento;
                emple.emp_Municipio = empleado.emp_Municipio.ToString();
                emple.emp_Sexo = empleado.emp_Sexo;
                emple.emp_Telefono = empleado.emp_Telefono;
                emple.emp_Correo = empleado.emp_Correo;
                emple.emp_Sucursal = empleado.emp_Sucursal.ToString();

                emple.depto = db.tbMunicipios.Where(m => m.mun_ID == empleado.emp_Municipio).Select(m => m.mun_depID).FirstOrDefault().ToString();

                ViewBag.emp_EstadoCivil = new SelectList(db.Vw_Gral_tbEstadosCiviles_DDL, "est_ID", "est_Descripcion");
                ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
                ViewBag.emp_Municipio = new SelectList(db.tbMunicipios, "mun_ID", "mun_Descripcion");
                ViewBag.emp_Sucursal = new SelectList(db.Vw_Gral_tbSucursales_DDL, "suc_Id", "suc_Descripcion");
                return View(emple);
            }

                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }


        }

        [HttpPost]
        public IActionResult Edit(EmpleadosViewModel item)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");
                    int usumodi = int.Parse(HttpContext.Session.GetString("usu_ID"));
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
                        ModelState.AddModelError("DNI", "* El DNI ingresado ya existe.");
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
                        Int32.Parse(item.emp_Municipio), item.emp_Telefono, item.emp_Correo, Int32.Parse(item.emp_EstadoCivil), Int32.Parse(item.emp_Sucursal), usumodi);
                        TempData["SuccessMessage"] = "El proceso se completó correctamente";
                        MostrarToastDeExito();
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    //ViewBag.depto = Request.Form["depto"];
                    //ViewBag.emp_Muicipio = Request.Form["emp_Municipio"];
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
                //ViewBag.depto = Request.Form["depto"];
                //ViewBag.emp_Muicipio = Request.Form["emp_Municipio"];
                ViewBag.depto = new SelectList(db.Vw_Gral_tbDepartamentos_DDL, "depto", "dep_Descripcion");
                ViewBag.emp_Sucursal = new SelectList(db.Vw_Gral_tbSucursales_DDL, "suc_Id", "suc_Descripcion");
                return View(item);
            }
                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }


        }

        #endregion

        #region Eliminar Empleado
        [HttpPost("/Empleado/Eliminar/")]
        public IActionResult Delete(int emp_Id)
        {
            try
            {
                if (HttpContext.Session.GetString("usu_Nombre") != null)
                {
                    ViewBag.usu_Nombre = HttpContext.Session.GetString("usu_Nombre");
                    ViewBag.suc_Descripcion = HttpContext.Session.GetString("suc_Descripcion");
                    ViewBag.usu_Id = HttpContext.Session.GetString("usu_ID");
                    ViewBag.suc_Id = HttpContext.Session.GetString("suc_Id");
                    int? usumodi = int.Parse(HttpContext.Session.GetString("usu_ID"));

                    tbEmpleados emp = new tbEmpleados();
                    emp.emp_ID = emp_Id;
                    emp.emp_UsuarioModi = usumodi;


                    var empl = _mapper.Map<tbEmpleados>(emp);
                    var result = _generalesService.DeleteEmpleado(empl);


                    return RedirectToAction("Index");


                }

                return RedirectToAction("Index", "Login");


            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }

        }
        #endregion





    }
}
