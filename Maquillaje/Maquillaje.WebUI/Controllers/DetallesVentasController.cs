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
    public class DetallesVentasController : Controller
    {
        TiendaContext db = new TiendaContext();
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;


        public DetallesVentasController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpPost, ActionName("GuardarDetalle")]
        public ActionResult GuardarDetalleVenta(int? Vent_Id, int? Prod_Id, float? Prod_PrecioVenta, int? Prod_Cantidad)
        {
            try
            {
                
                    if (Vent_Id != null && Prod_Id != null && Prod_PrecioVenta != null && Prod_Cantidad != null)
                    {
                        int UsuCrea = 1;
                        var resultado = _generalesService.IngresarNuevoDetalleVenta(Vent_Id, Prod_Id, Prod_Cantidad, UsuCrea);

                        if (resultado > 0)
                        {
                            var DetallesVentas = db.UDF_tbVentas_ListarDetallesPorIdVenta(Vent_Id);

                            if (DetallesVentas != null)
                            {
                                return RedirectToAction("Index", "Venta", DetallesVentas);
                            }
                            return RedirectToAction("Index", "Home");
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

        [HttpPost, ActionName("GuardarEdicionDetalle")]
        public ActionResult GuardarEdicionDetalleVenta(int? DeVe_Id, int? Vent_Id, int? Prod_Id, float? Prod_PrecioVenta, int? Prod_Cantidad)
        {
            try
            {
                    if (DeVe_Id != null && Vent_Id != null && Prod_Id != null && Prod_PrecioVenta != null && Prod_Cantidad != null)
                    {
                        int UsuarioModificacion = 1;
                        var resultado = _generalesService.ActualizarDetalleVenta(DeVe_Id, Prod_Id, Prod_Cantidad, UsuarioModificacion);

                        if (resultado > 0)
                        {
                            var DetallesVentas =db.UDF_tbVentas_ListarDetallesPorIdVenta(Vent_Id);

                            if (DetallesVentas != null)
                            {
                                return RedirectToAction("Index", "Venta", DetallesVentas);
                            }
                            return RedirectToAction("Index", "Home");
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

        [HttpPost, ActionName("EliminarDetalle")]
        public ActionResult EliminarDetalleVenta(int? DeVe_Id, int? Vent_Id)
        {
            try
            {
                    if (DeVe_Id != null)
                    {
                        var resultado = _generalesService.EliminarDetalleVenta(DeVe_Id);

                        if (resultado > 0)
                        {
                            var DetallesVentas = db.UDF_tbVentas_ListarDetallesPorIdVenta(Vent_Id);

                            if (DetallesVentas != null)
                            {
                                return RedirectToAction("Index", "Venta", DetallesVentas);
                            }
                            return RedirectToAction("Index", "Home");
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
