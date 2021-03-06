﻿using SistemaEncuestas.Models;
using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.repositorio.Interfaz;
using SistemaEncuestas.Repositorio.Infraestructura;
using SistemaEncuestas.Repositorio.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SistemaEncuestas.repositorio.repositorios
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
        public Encuesta GetById(int Id)
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
            Encuesta local = GetById(entity.Id);        
            if (local != null)
                context.Entry<Encuesta>(local).State = EntityState.Detached;
            context.Entry <Encuesta>(entity).State = EntityState.Modified;  //en vez de local va entity para que se actualice correctamente
        }
        public IQueryable<Encuesta> GetAll()
        {
            return context.Encuestas.Select(c => c);
        }
        public IQueryable<Encuesta> FindBy(Expression<Func<Encuesta, bool>> Conditional)
        {
            return context.Encuestas.Select(c => c);
        }

    }
}