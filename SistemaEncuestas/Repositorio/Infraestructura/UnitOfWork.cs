using System;

namespace SistemaEncuestas.repositorio.Infraestructura
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context = null;
        private ApplicationDbContext Context
        {
            get { return context = context ?? ContextFactory.GetContext(); }
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void RollBack()
        {
            foreach (var entry in Context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Detached;
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}