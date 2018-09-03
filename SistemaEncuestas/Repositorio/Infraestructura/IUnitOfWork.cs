using System;

namespace SistemaEncuestas.repositorio.Infraestructura
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    }
}