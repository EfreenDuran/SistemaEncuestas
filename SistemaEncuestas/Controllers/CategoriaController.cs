using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaEncuestas.Controllers
{
    public class CategoriaController : Controller
    {

        //INYECCION DE DEPENDENCIAS
        CategoriaService catService;    //campo
        public CategoriaController() : this(new CategoriaService()) { }   //constructur vacio
        public CategoriaController(CategoriaService catService)         //constructor que me hace la inyección 
        {
            this.catService = catService;   // variable global / variable local para indicarle al compilador que me utilice esa variable global como local
        }

        // GET: Categoria
        public ActionResult Index()
        {
            List<Categoria> lista = new List<Categoria>();
            lista=catService.ListarTodo();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()    //GET. para que nos regrese el formulario para agregar elementos
        {
            Categoria c = new Categoria();
            return View(c);
        }

        [HttpPost]
        public ActionResult Create(Categoria c) //POST. aqui es cuando ya queremos modificar los datos en el servidor
        {
            if (catService.Guardar(c))
                return RedirectToAction("Index");
            else
                return View(c);
        }
        
        public ActionResult Details(int id)     //Action para ver los detalles. Leemos un entero que es el id
        {
            var temp = catService.ObtenerPorId(id); 
            return View(temp);
        }

        //Controlador para editar
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var temp = catService.ObtenerPorId(id);
            //Categoria c = new Categoria(id);
            //var c = catService.Actualizar(id);
            return View(temp);
        }

        [HttpPost]        
        public ActionResult Edit(Categoria cat) //POST. aqui es cuando ya queremos modificar los datos en el servidor
        {
            catService.Actualizar(cat);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            catService.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}