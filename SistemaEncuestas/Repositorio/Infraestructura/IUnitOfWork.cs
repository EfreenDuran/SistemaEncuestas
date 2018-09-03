using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEncuestas.Repositorio.Infraestructura
{
    public interface IUnitOfWork
    {
        void commit();
        void RollBack();
    }
}
