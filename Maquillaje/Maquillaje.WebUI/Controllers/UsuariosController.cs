﻿using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.DataAccess;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public TiendaContext db = new TiendaContext();



        public UsuariosController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Usuarios/Listado")]
        public IActionResult Index()
        {
            ViewBag.usuario = new SelectList(db.Vw_Gral_tbEmpleados_DDL, "emp_ID", "emp_Nombre");
            var listado = _generalesService.ListadoUsuarios();
            var ListadoMapeado = _mapper.Map<IEnumerable<UsuariosViewModel>>(listado);
            return View(ListadoMapeado);
        }


        public IActionResult Details(int id)
        {

            var cates = _generalesService.DetallesUsuarios(id);
            UsuariosViewModel model = new UsuariosViewModel();

            if (cates != null && cates.Length > 0)
            {
                model.usu_ID = cates[0];
                model.usu_Usuario = cates[1];
                model.Empleado = cates[2];
                model.usu_Usuario = cates[3];
                model.usu_UsuarioCrea = cates[4];
                model.usu_UsuarioModi = cates[5];
                model.usu_FechaCrea = Convert.ToDateTime(cates[6]);
                model.usu_FechaModi = Convert.ToDateTime(cates[7]);

            }
            ViewBag.UsuCrea = model.usu_UsuarioCrea;
            ViewBag.UsuModi = model.usu_UsuarioModi;

            if (cates == null)
            {
                return RedirectToAction("Index"); // acá vamos a redireccionar a la pagina 404
            }
            return View(model);



        }






        [HttpPost("/Usuarios/Create")]
        public IActionResult Create(string usu_Usuario, int emp_Id, string usu_Clave, bool usu_EsAdmin)
        {

            try
            {
            tbUsuarios usua = new tbUsuarios();
            usua.usu_Usuario = usu_Usuario;
            usua.usu_empID = emp_Id;
            usua.usu_UsuarioCrea = 1;
            usua.usu_EsAdmin = usu_EsAdmin;
            usua.usu_Clave = usu_Clave;

            

            ViewBag.usuario = new SelectList(db.Vw_Gral_tbEmpleados_DDL, "emp_ID", "emp_Nombre");
            var usu = _mapper.Map<tbUsuarios>(usua);
            var result = _generalesService.CreateUsuario(usu);

            return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }


        }




        [HttpPost("/Usuarios/Eliminar/")]
        public IActionResult Delete(int usu_Id)
        {

            tbUsuarios usu = new tbUsuarios();
            usu.usu_ID = usu_Id;


            var usua = _mapper.Map<tbUsuarios>(usu);
            var result = _generalesService.DeleteUsuario(usua);


            return RedirectToAction("Index");
        }



    }
}
