using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;

        public ProveedoresController(GeneralesService generalesService, IMapper mapper)
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

            var cates = _generalesService.DetallesProveedores(id);
            ProveedoresViewModel model = new ProveedoresViewModel();

            if (cates != null && cates.Length > 0)
            {
                model.prv_ID = cates[0];
                model.prv_NombreCompañia = cates[1];
                model.prv_NombreContacto = cates[2];
                model.prv_TelefonoContacto = cates[3];
                model.prv_DireccionEmpresa = cates[4];
                model.prv_DireccionContacto = cates[5];
                model.prv_SexoContacto = cates[6];
                model.prv_UsuarioCrea = cates[7];
                model.prv_UsuarioModi = cates[8];
                model.prv_FechaCrea = Convert.ToDateTime(cates[9]);
                model.prv_FechaModi = Convert.ToDateTime(cates[10]);



            }
            ViewBag.UsuCrea = model.prv_UsuarioCrea;
            ViewBag.UsuModi = model.prv_UsuarioModi;

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
        [HttpGet("/Proveedores/Listado")]
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


            var listado = _generalesService.ListadoProveedores();
            var listadoMapeado = _mapper.Map<IEnumerable<ProveedoresViewModel>>(listado);
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
            return View(listadoMapeado);

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

        #region Crear Proveedor

        [HttpGet("/Proveedores/Create")]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProveedoresViewModel item)
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
            if (ModelState.IsValid)
            {
                if(item.prv_NombreCompañia != null && item.prv_NombreContacto != null && item.prv_DireccionEmpresa != null
                    && item.prv_DireccionContacto != null && item.prv_TelefonoContacto != null && item.prv_SexoContacto != null)
                {

                    // QUITAR EL 1
                    _generalesService.CreateProveedor(item.prv_NombreCompañia,item.prv_NombreContacto, item.prv_TelefonoContacto,
                      item.prv_DireccionEmpresa, item.prv_DireccionContacto, item.prv_SexoContacto, usucrea);
                    TempData["SuccessMessage"] = "El proceso se completó correctamente";
                    MostrarToastDeExito();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(item);
                }
            }
            else
            {
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

        #region Editar Proveedor
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
            var proveedor = _generalesService.ObtenerProveedores(id);
            if(proveedor == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ProveedoresViewModel item = new ProveedoresViewModel();
                item.prv_ID = proveedor.prv_ID;
                item.prv_NombreCompañia = proveedor.prv_NombreCompañia;
                item.prv_NombreContacto = proveedor.prv_NombreContacto;
                item.prv_DireccionEmpresa = proveedor.prv_DireccionEmpresa;
                item.prv_DireccionContacto = proveedor.prv_DireccionContacto;
                item.prv_TelefonoContacto = proveedor.prv_TelefonoContacto;
                item.prv_SexoContacto = proveedor.prv_SexoContacto;

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


        [HttpPost]

        public IActionResult Edit(ProveedoresViewModel item)
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

                        if (ModelState.IsValid)
                        {

                            if(item.prv_NombreCompañia != null && item.prv_NombreContacto != null && item.prv_DireccionEmpresa != null
                                && item.prv_DireccionContacto != null && item.prv_TelefonoContacto != null && item.prv_SexoContacto != null)
                            {
                                // REMOVER EL 1
                                _generalesService.UpdateProveedor(item.prv_ID, item.prv_NombreCompañia, item.prv_NombreContacto,
                                    item.prv_TelefonoContacto, item.prv_DireccionEmpresa, item.prv_DireccionContacto, item.prv_SexoContacto, usumodi);
                                TempData["SuccessMessage"] = "El proceso se completó correctamente";
                                MostrarToastDeExito();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                return View();
                            }    
                        }
                        else
                        {
                            return View();
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

        #region Eliminar Proveedor
            [HttpPost("/Proveedores/Eliminar/")]
        public IActionResult Delete(int prv_Id)
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

                        tbProveedores prov = new tbProveedores();
                        prov.prv_ID = prv_Id;
                        prov.prv_UsuarioModi = usumodi;


                        var prove = _mapper.Map<tbProveedores>(prov);
                        var result = _generalesService.DeleteProv(prove);


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
