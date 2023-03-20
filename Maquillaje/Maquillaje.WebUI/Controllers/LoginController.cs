using Maquillaje.BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly GeneralesService _generalesService;

        public LoginController (GeneralesService generalesService)
        {
            _generalesService = generalesService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("Login/Validar")]
        public IActionResult Index  (string txtUsername, string txtPass)
        {
            ViewBag.usu_Nombre = txtUsername;
            ViewBag.usu_Clave = txtPass;

            
            if ((txtUsername != "" && txtUsername != null) && (txtPass != "" && txtPass != null))
            {
                var usuario = _generalesService.ValidarLogin(txtUsername, txtPass);
                if (usuario != null && usuario.Length > 0)
                {
                    HttpContext.Session.SetString("usu_ID", usuario[0]);
                    HttpContext.Session.SetString("usu_Nombre", usuario[1]);
                    HttpContext.Session.SetString("usu_EsAdmin", usuario[2]);
                    HttpContext.Session.SetString("emp_Sucursal", usuario[3]);
                    HttpContext.Session.SetString("sucu_Descripcion", usuario[4]);


                    if (usuario[2] == "admin")
                    {
                        ViewBag.EsAdmin = "admin";
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError("General", "Los campos son obligatorios.");
                return View();
            }

            if (txtUsername == "" || txtUsername == null)
            {
                ModelState.AddModelError("username", "El campo usuario es obligatorio.");
            }

            if (txtPass == "" || txtPass == null)
            {
                ModelState.AddModelError("password", "El campo clave es obligatorio.");
            }
            return View();
        }
    }
}
