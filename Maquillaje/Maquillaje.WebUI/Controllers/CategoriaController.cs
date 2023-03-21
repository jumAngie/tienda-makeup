using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.DataAccess;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly GeneralesService _generalesService;
        private readonly IMapper _mapper;
        TiendaContext db = new TiendaContext();


        public CategoriaController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesService = generalesService;
            _mapper = mapper;
        }

        [HttpGet("/Categorias/Listado")]
        public IActionResult Index()
        {
            var listado = _generalesService.ListadoCategorias();
            var listadoMapeado = _mapper.Map<IEnumerable<CategoriaViewModel>>(listado);
            return View(listadoMapeado);
        }

        [HttpPost("/Categorias/Create")]
        public IActionResult Create(string cat_Descripcion)
        {
            tbCategorias cate = new tbCategorias();
            cate.cat_Descripcion = cat_Descripcion;
            cate.cat_UsuCrea = 1;
            var cat = _mapper.Map<tbCategorias>(cate);
            var result = _generalesService.CreateCategorias(cat);

            return RedirectToAction("Index");

        }

        [HttpGet("/Categorias/Editar/{id}")]
        public IActionResult Edit(int? id)
        {
            var listado = _generalesService.BuscarCategoria(id);
            return View(listado);
        }

        [HttpPost("/Categorias/Editar")]
        public IActionResult Edit(int cat_Id, string cat_Descripcion)
        {
            tbCategorias cat = new tbCategorias();
            cat.cat_Id = cat_Id;
            cat.cat_Descripcion = cat_Descripcion;
            cat.cat_UsuModi = 1;

            var categoria = _mapper.Map<tbCategorias>(cat);
            var result = _generalesService.EditCategoria(categoria);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
           
                var cates = _generalesService.Detalles(id);
                CategoriaViewModel model = new CategoriaViewModel();

                if (cates != null && cates.Length > 0)
                {
                    model.cat_Id = cates[0];
                    model.cat_Descripcion = cates[1];
                    model.cat_UsuCrea = cates[2];
                    model.cat_UsuModi = cates[3];
                    model.cat_FechaCrea = Convert.ToDateTime(cates[4]);
                    model.cat_FechaModi = Convert.ToDateTime(cates[5]);

                }
                ViewBag.UsuCrea = model.cat_UsuCrea;
                ViewBag.UsuModi = model.cat_UsuModi;

                if (cates == null)
                {
                    return RedirectToAction("Index"); // acá vamos a redireccionar a la pagina 404
                }
                return View(model);

         

        }


        [HttpPost("/Categoria/Eliminar/")]
        public IActionResult Delete(int cat_Id)
        {

            tbCategorias cat = new tbCategorias();
            cat.cat_Id = cat_Id;
            cat.cat_UsuModi = 1;


            var categoria = _mapper.Map<tbCategorias>(cat);
            var result = _generalesService.DeleteCategoria(categoria);


            return RedirectToAction("Index");
        }




    }
}
