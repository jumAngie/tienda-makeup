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
    public class ProductoController : Controller
    {
        private TiendaContext db = new TiendaContext();
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;


        public ProductoController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Producto/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoProductos();
            var listadoMapeado = _mapper.Map<IEnumerable<ProductosViewModel>>(listado);
            return View(listadoMapeado);
        }

        [HttpGet("/Producto/Create")]

        public IActionResult Create()
        {
            
            ViewBag.cat_Id = new SelectList(db.Vw_Maqui_tbCategorias_DDL, "cat_Id", "cat_Descripcion");
            ViewBag.pro_Proveedor = new SelectList(db.Vw_Maqui_tbProveedores_DDL, "prv_ID", "prv_NombreCompañia");
            return View();
        }

        // Condicionar Campos
        [HttpPost]
        public IActionResult Create(ProductosViewModel productosView)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(productosView);
        }



        [HttpPost("/Productos/Eliminar/")]
        public IActionResult Delete(int pro_Id)
        {

            tbProductos pro = new tbProductos();
            pro.pro_Id = pro_Id;


            var prod = _mapper.Map<tbProductos>(pro);
            var result = _generalesService.DeleteProductos(prod);


            return RedirectToAction("Index");
        }

    }
}
