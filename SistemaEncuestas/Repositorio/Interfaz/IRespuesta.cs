using SistemaEncuestas.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEncuestas
{
    public interface IRespuesta
    {
        void Create(Respuesta entity);
        void Update(Respuesta entity);
        void Delete(int id);
        IQueryable<Respuesta> GetAll();
        Respuesta GetById(int id);
    }
}
