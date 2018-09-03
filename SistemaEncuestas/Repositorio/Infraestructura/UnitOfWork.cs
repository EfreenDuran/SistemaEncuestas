using SistemaEncuestas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Repositorio.Infraestructura
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context = null;
        private ApplicationDbContext Context
        {
            get { return context = context ?? ContextFactory.GetContext(); }
        }
        public void commit()
        {
            context.SaveChanges();
        }
        public void RollBack()
        {
            foreach (var entry in context.ChangeTracker.Entries())
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