using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class VentaController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;
        public TiendaContext db = new TiendaContext();

        public VentaController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;

        }

        public IActionResult Index()
        {
            // meter try catch
            // meter count de sesión
            var IdUltimaVentaReciente = _generalesService.IdVentaReciente();
            int idVenta = 0;

            foreach (Nullable<int> item in IdUltimaVentaReciente)
            {
                if (item.HasValue)
                {
                    idVenta = item.Value;
                }
            }

            var Detalles = db.UDF_tbVentas_ListarDetallesPorIdVenta(idVenta);

            if (Detalles != null)
            {
                return View(Detalles);
            }
            else
            {
                // error
                return RedirectToAction("Index", "Home");
            }


        }

        [HttpPost, ActionName("CargarDdl")]
        public ActionResult CargarDdlClientes(string cargar)
        {
            try
            {
                if (cargar != null && cargar != "")
                {
                    var DdlClientes = db.Vw_Gral_tbClientes_DDL;
                    var Ddlproductos = db.Vw_Maqui_tbProductos_DDL;
                    return Json(new { DdlClientes, Ddlproductos });
                }
                else
                {
                    return RedirectToAction("Index");
                }


            }
            catch (Exception)
            {
                // cambiar a pagina de error.
                return RedirectToAction("Index");
                throw;
            }
        }

        [HttpPost, ActionName("Guardar")]
        public ActionResult Guardar(int? clie_id)
        {
            try
            {
                if (clie_id != null && clie_id != 0)
                {
                    int empleado = 1;
                    int sucursal = 1;
                    int usuario = 1;
                    int metodo = 1;
                    var resultado = _generalesService.IngresarNuevaVenta(clie_id, empleado, sucursal, metodo, usuario);

                    if (resultado > 0)
                    {
                        var IdUltimaVentaReciente = _generalesService.IdVentaReciente();
                        var Ddlproductos = db.Vw_Maqui_tbProductos_DDL;
                        return Json(new { success = true, IdUltimaVentaReciente, Ddlproductos });
                    }
                    return Json(new { success = false });
                }
                //Colocar la página de Error
                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {
                //Colocar la página de Error
                return RedirectToAction("Index", "Home");
                throw;
            }
        }

        [HttpPost, ActionName("ObtenerPrecio")]
        public ActionResult ListarproductoPorId(int? id)
        {
            try
            {
                if (id != null && id != 0)
                {
                    var producto = db.UDF_tbProductos_ListarProductoPorId(id);

                    if (producto != null)
                    {
                        return Json(new { success = true, producto });
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
        }

        [HttpPost, ActionName("CargarStock")]
        public ActionResult CargarStockProductoPorId(int? id)
        {
            try
            {

                if (id != null && id != 0)
                {
                    var stock = db.UDF_tbProductos_CargarStockProductoPorId(id);

                    if (stock != null)
                    {
                        return Json(new { success = true, stock });
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
        }


        [HttpPost, ActionName("preEditarDetalle")]
        public ActionResult CargarDetalleVentaPorId(int? DeVe_Id)
        {
            try
            {
                
                    if (DeVe_Id != null && DeVe_Id != 0)
                    {
                        var DetalleVenta = db.UDF_tbDetallesVentas_CargarDetalleVentaPorId(DeVe_Id);

                        if (DetalleVenta != null)
                        {
                            return Json(new { success = true, DetalleVenta });
                        }
                    }
                    return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
        }
    }
}
