using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEncuestas.repositorio.Interfaz
{
    public interface ICategoria
    {
      
        void Create(Categoria entity);
        void Update(Categoria entity);
        void Delete(int Id);
        Categoria GetById(int Id);
        IQueryable<Categoria> GetAll();
        IQueryable<Categoria> FindBy(Expression<Func<Categoria, bool>> Conditional);

    }
}
