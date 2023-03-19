using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
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


        #region Listado
        [HttpGet("/Proveedores/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoProveedores();
            var listadoMapeado = _mapper.Map<IEnumerable<ProveedoresViewModel>>(listado);
            return View(listadoMapeado);
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
            if(ModelState.IsValid)
            {
                if(item.prv_NombreCompañia != null && item.prv_NombreContacto != null && item.prv_DireccionEmpresa != null
                    && item.prv_DireccionContacto != null && item.prv_TelefonoContacto != null && item.prv_SexoContacto != null)
                {

                    // QUITAR EL 1
                    _generalesService.CreateProveedor(item.prv_NombreCompañia,item.prv_NombreContacto, item.prv_TelefonoContacto,
                        item.prv_DireccionContacto, item.prv_DireccionContacto, item.prv_SexoContacto, 1);
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

        #endregion

        #region Editar Proveedor
        [HttpGet]
        public IActionResult Edit(int? id)
        {
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


        [HttpPost]

        public IActionResult Edit(ProveedoresViewModel item)
        {
            if(ModelState.IsValid)
            {

                if(item.prv_NombreCompañia != null && item.prv_NombreContacto != null && item.prv_DireccionEmpresa != null
                    && item.prv_DireccionContacto != null && item.prv_TelefonoContacto != null && item.prv_SexoContacto != null)
                {
                    // REMOVER EL 1
                    _generalesService.UpdateProveedor(item.prv_ID, item.prv_NombreCompañia, item.prv_NombreContacto,
                        item.prv_TelefonoContacto, item.prv_DireccionEmpresa, item.prv_DireccionContacto, item.prv_SexoContacto, 1);
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
            #endregion

        #region Eliminar Proveedor
            [HttpPost("/Proveedores/Eliminar/")]
        public IActionResult Delete(int prv_Id)
        {

            tbProveedores prov = new tbProveedores();
            prov.prv_ID = prv_Id;


            var prove = _mapper.Map<tbProveedores>(prov);
            var result = _generalesService.DeleteProv(prove);


            return RedirectToAction("Index");
        }
        #endregion

    }
}
