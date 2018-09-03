using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.repositorio.Infraestructura;
using SistemaEncuestas.Repositorio.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//COMENTARIO

namespace SistemaEncuestas.Negocio
{
    public class RespuestaService
    {   
        //inyeccion de dependencias
        IUnitOfWork unitOfWork;
        IRespuesta RespuestaRepo;

        public RespuestaService() : this(new RespuestaRepositorio(), new UnitOfWork()) { }
        public RespuestaService(IRespuesta _RespuestaRepo, IUnitOfWork _unitOfWork)
        {
            this.RespuestaRepo = _RespuestaRepo;
            this.unitOfWork = _unitOfWork;
        }

        public List<Respuesta> ListarTodo()
        {
            try
            {
                return RespuestaRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Guardar(Respuesta entity)
        {
            try
            {
                RespuestaRepo.Create(entity);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return false;
            }
        }
        public Respuesta ObtenerPorId(int id)
        {
            try
            {
                Respuesta temp = RespuestaRepo.GetById(id);
                if (temp != null)
                    return temp;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Eliminar(int id)
        {
            try
            {
                RespuestaRepo.Delete(id);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
            }
        }
        public void Actualizar(Respuesta entity)
        {
            try
            {
                RespuestaRepo.Update(entity);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
            }
        }

    }

 
}