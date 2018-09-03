using SistemaEncuestas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Repositorio.Infraestructura
{
    public class ContextFactory
    {
        static ApplicationDbContext context = null;

        internal static ApplicationDbContext GetContext()
        {
            return context = context ?? new ApplicationDbContext(); //Singgleton
        }
    }
}