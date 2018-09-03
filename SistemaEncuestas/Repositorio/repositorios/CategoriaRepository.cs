using SistemaEncuestas.Models;
using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.repositorio.Interfaz;
using SistemaEncuestas.Repositorio.Infraestructura;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SistemaEncuestas.repositorio.repositorios
{
    public class CategoriaRepository : ICategoria
    {
        ApplicationDbContext context;
    
        public CategoriaRepository()
        {
            context = ContextFactory.GetContext();
        }
     
        public void Create(Categoria entity)
        {
            context.Categorias.Add(entity);
        }
        public Categoria GetById(int id)
        {
    
            return context.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            context.Entry<Categoria>(GetById(id)).State = System.Data.Entity.EntityState.Deleted;
        }
        public void Update(Categoria entity)
        {
            Categoria local = GetById(entity.Id);
            if (local != null)
                context.Entry<Categoria>(local).State = EntityState.Detached;
            context.Entry<Categoria>(local).State = EntityState.Modified;
        }
        public IQueryable<Categoria> GetAll()
        {
            return context.Categorias.Select(c => c);
        }
        public IQueryable<Categoria> FindBy(Expression<Func<Categoria, bool>> Conditional)
        {
            return context.Categorias.Select(c => c);
        }

    }
}