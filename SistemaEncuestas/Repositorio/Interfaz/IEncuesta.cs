using SistemaEncuestas.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEncuestas.Repositorio.Interfaz
{
    public interface IEncuesta
    {
        //crear una encuesta
        void Create(Encuesta entity);
        //actualizar, se actualiza una encuesta
        void Update(Encuesta entity);
        //eliminar 
        void Delete(int id);
        //mostrar (GetByld obtener por id)
        Encuesta GetById(int id);          

        //regresa una lista de alguna encuesta
        IQueryable<Encuesta> GetAll();
        IQueryable<Encuesta> FindBy(Expression<Func<Encuesta, bool>> Conditional);

    }
}
