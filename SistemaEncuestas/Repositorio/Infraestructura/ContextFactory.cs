using System;

namespace SistemaEncuestas.Repositorio.Infraestructura
{
    public class ContextFactory
    {
        static ApplicationDbContext context = null;

        internal static ApplicationDbContext GetContext()   // estamos trabajando con el patron de diseño singleton el cual nos asegura que solo trabajemos con el mismo contexto para todo el proyecto
        {
            return context = context ?? new ApplicationDbContext();
        }
    }
}