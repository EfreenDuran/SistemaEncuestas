using SistemaEncuestas.Models;
using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Repositorio.Infraestructura;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;

namespace SistemaEncuestas
{
    public class RespuestaRepositorio : IRespuesta
    {
        ApplicationDbContext context;
        public RespuestaRepositorio()
        {
            context = ContextFactory.GetContext();
        }

        public void Create(Respuesta entity)
        {
            context.Respuestas.Add(entity);
        }
        public Respuesta GetById(int id)
        {
            return context.Respuestas.FirstOrDefault(c => c.Id == id);
        }
        
        public void Delete(int id)
        {
            context.Entry<Respuesta>(GetById(id)).State = EntityState.Deleted;
        }

        public void Update(Respuesta entity)
        {
            Respuesta local = GetById(entity.Id);
            if (local != null)
                context.Entry<Respuesta>(local).State = EntityState.Detached;
            context.Entry<Respuesta>(local).State = EntityState.Modified;
        }

        public IQueryable<Respuesta> GetAll()
        {
            return context.Respuestas.Select(c => c);
        }

        public IQueryable<Respuesta> FindBy(Expression<Func<Respuesta, bool>> condicion)
        {
            return context.Respuestas.Where(condicion).Select(c => c);
        }

        
    }
}
  