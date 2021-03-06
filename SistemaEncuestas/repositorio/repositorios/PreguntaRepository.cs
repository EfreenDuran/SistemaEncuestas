﻿using SistemaEncuestas.Models;
using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.repositorio.Interfaz;
using SistemaEncuestas.Repositorio.Infraestructura;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace proyecto.repositorio.repositorios
{
    public class PreguntaRepository : IPregunta
    {
        ApplicationDbContext context;
        public PreguntaRepository()
        {
            context = ContextFactory.GetContext();
        }
        public void Create(Pregunta entity)
        {
            context.Preguntas.Add(entity);
        }
        public Pregunta GetById(int Id)
        {
            return context.Preguntas.FirstOrDefault(c => c.Id == Id);
        }
        public void Delete(int Id)
        {
            context.Entry<Pregunta>(GetById(Id)).State = System.Data.Entity.EntityState.Deleted;
        }
        public void Update(Pregunta entity)
        {
            Pregunta local = GetById(entity.Id);
            if (local != null)
                context.Entry<Pregunta>(local).State = EntityState.Detached;
            context.Entry<Pregunta>(entity).State = EntityState.Modified;   //en vez de local va entity para que se actualice correctamente
        }
        public IQueryable<Pregunta> GetAll()
        {
            return context.Preguntas.Select(c => c);
        }

        //opcional
        public IQueryable<Pregunta> FindBy(Expression<Func<Pregunta, bool>> Conditional)
        {
            return context.Preguntas.Select(c => c);
        }

    }
}