using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaEncuestas.Controllers
{
    public class EncuestaController : Controller
    {
        //inyeccion de dependencias
        EncuestaService encService;
        public EncuestaController() : this (new EncuestaService()) { }
        public EncuestaController (EncuestaService encService)
        {
            this.encService = encService;
        }        

        // GET: Encuesta
        public ActionResult Index()
        {
            List<Encuesta> lista = new List<Encuesta>();
            lista = encService.ListarTodo();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Encuesta e = new Encuesta();
            return View(e);
        }

        [HttpPost]
        public ActionResult Create(Encuesta e)
        {
            if (encService.Guardar(e))
                return RedirectToAction("Index");
            else
                return View(e);
        }
        public ActionResult Details(int id)
        {
            var temp = encService.ObtenerPorId(id);
            return View(temp);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var temp = encService.ObtenerPorId(id);
            return View(temp);
        }

        [HttpPost]
        public ActionResult Edit (Encuesta enc)
        {
            encService.Actualizar(enc);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            encService.Eliminar(id);
            return RedirectToAction("Index");
        }


    }
}