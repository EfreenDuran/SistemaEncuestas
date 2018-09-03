using SistemaEncuestas.Models.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace SistemaEncuestas.repositorio.Interfaz
{
    public interface ICategoria
    {
      
        void Create(Categoria entity);
        void Update(Categoria entity);
        void Delete(int id);
        Categoria GetById(int id);
        IQueryable<Categoria> GetAll();
        IQueryable<Categoria> FindBy(Expression<Func<Categoria, bool>> Conditional);
      
    }
}
