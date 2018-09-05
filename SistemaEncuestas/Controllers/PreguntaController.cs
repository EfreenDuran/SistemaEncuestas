using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaEncuestas.Controllers
{
    public class PreguntaController : Controller
    {
        //inyeccion de dependencias
        PreguntaService pregService;
        public PreguntaController() : this (new PreguntaService()) { }
        public PreguntaController(PreguntaService pregService)
        {
            this.pregService = pregService;
        }

        // GET: Pregunta
        public ActionResult Index()
        {
            List<Pregunta> lista = new List<Pregunta>();
            lista = pregService.ListarTodo();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Pregunta p = new Pregunta();
            return View(p);
        }

        [HttpPost]
        public ActionResult Create(Pregunta p)
        {
            if (pregService.Guardar(p))
                return RedirectToAction("Index");
            else
                return View(p);
        }

        public ActionResult Details(int id)
        {
            var temp = pregService.ObtenerPorId(id);
            return View(temp);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var temp = pregService.ObtenerPorId(id);
            return View(temp);
        }

        [HttpPost]
        public ActionResult Edit(Pregunta preg)
        {
            pregService.Actualizar(preg);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            pregService.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}

