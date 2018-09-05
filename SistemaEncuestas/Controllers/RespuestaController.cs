using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaEncuestas.Controllers
{
    public class RespuestaController : Controller
    {
        //inyeccion de dependencias
        RespuestaService respService;
        public RespuestaController() : this(new RespuestaService()) { }
        public RespuestaController(RespuestaService respService)
        {
            this.respService = respService;
        }

        // GET: Respuesta
        public ActionResult Index()
        {
            List<Respuesta> lista = new List<Respuesta>();
            lista = respService.ListarTodo();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Respuesta r = new Respuesta();
            return View(r);
        }

        [HttpPost]
        public ActionResult Create(Respuesta r)
        {
            if (respService.Guardar(r))
                return RedirectToAction("Index");
            else
                return View(r);
        }

        public ActionResult Details(int id)
        {
            var temp = respService.ObtenerPorId(id);
            return View(temp);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var temp = respService.ObtenerPorId(id);
            return View(temp);
        }

        [HttpPost]
        public ActionResult Edit(Respuesta resp)
        {
            respService.Actualizar(resp);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            respService.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}