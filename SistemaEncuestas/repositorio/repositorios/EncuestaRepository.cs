using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace proyecto.repositorio.repositorios
{
    public class EncuestaRepository : IEncuesta
    {
        ApplicationDbContext context;
        //crear
        public EncuestaRepository()
        {
            context = ContextFactory.GetContext();
        }
        //agregar encuestas a la tabla
        public void Create(Encuesta entity)
        {
            context.Encuestas.Add(entity);
        }
        public Encuestas GetById(int Id)
        {
            //busca Encuestas igual a su id
            return context.Encuestas.FirstOrDefault(c => c.Id == Id);
        }
        //busca encuesta para poder eliminarla
        public void Delete(int Id)
        {
            context.Entry<Encuesta>(GetById(Id)).State = System.Data.Entity.EntityState.Deleted;
        }
        public void Update(Encuesta entity)
        {
            //buscamos la encuesta y asignamos un variable tem, ponemos en bay espascio para poder modificarlo
            Encuesta local = GetById(entity.Id);        //****** Modifiqué esta parte, tenías: Producto local = GetById(entity.Id);  
            if (local != null)
                context.Entry<Encuesta>(local).State = EntityState.Detached;
            context.Entry <Encuesta>(local).State = EntityState.Modified;
        }
        //pasamos todos las encuestas o instancias
        public IQueryable<Encuesta> GetAll()
        {
            return context.Encuestas.Select(c => c);
        }
        //regresa una lista de productos donde cumpla la expresion
        public IQueryable<Encuesta> FindBy(Expression<Func<Encuesta, bool>> Conditional)
        {
            return context.Encuestas.Select(c => c);
        }

    }
}