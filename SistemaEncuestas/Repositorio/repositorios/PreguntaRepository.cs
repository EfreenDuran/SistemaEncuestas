using System;

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
        public Preguntas GetById(int Id)
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
            context.Entry<Pregunta>(local).State = EntityState.Modified;
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