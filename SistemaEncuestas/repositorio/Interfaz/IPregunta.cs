using SistemaEncuestas.Models.Domain;
using System;
using System.Linq;

namespace SistemaEncuestas.repositorio.Interfaz
{
    public interface IPregunta
    {
        void Create(Pregunta entity);       //para crear una pregunta        
        void Update(Pregunta entity);       //para actualizar una pregunta
        void Delete(int Id);                //eliminamos una pregunta por su id
        Pregunta GetById(int Id);           //mostramos una pregunta por su id

        IQueryable<Pregunta> GetAll();      //regresa la lista de todas las preguntas
       //IQueryable<Pregunta> FindBy(Expression<Func<Pregunta, bool>> Conditional); //opcional

    }
}