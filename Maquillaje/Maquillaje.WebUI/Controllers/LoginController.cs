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

        public LoginController(GeneralesService generalesService)
        {
            _generalesService = generalesService;
        }

        public IActionResult Index()
        {
            return View();
        }





        [HttpPost]
        public IActionResult Index(string txtUsername, string txtPass)
        {
            try
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
                        HttpContext.Session.SetString("suc_Id", usuario[5]);
                        HttpContext.Session.SetString("usu_Usuario", usuario[6]);
                        HttpContext.Session.SetString("usu_Clave", usuario[7]);


                        if (usuario[2] == "admin")
                        {
                            ViewBag.EsAdmin = "admin";
                            return View();
                        }
                        if (txtUsername == "" || txtUsername == null || txtUsername != usuario[6])
                        {
                            ModelState.AddModelError("username", "El campo usuario es obligatorio.");
                        }

                        if (txtPass == "" || txtPass == null || txtPass != usuario[7])
                        {
                            ModelState.AddModelError("password", "El campo clave es obligatorio.");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }



                    }
                    ModelState.AddModelError("General", "Los campos son obligatorios.");
                    return View();
                }


                return View();
            }
            catch (Exception ex)
            {

         ModelState.AddModelError("password", "El campo clave es obligatorio.");
                Console.WriteLine(ex);
                return RedirectToAction("Index", "Login");

            }
        }
         

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
