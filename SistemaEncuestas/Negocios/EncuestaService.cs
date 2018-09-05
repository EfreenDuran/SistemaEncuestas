using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.repositorio.Infraestructura;
using SistemaEncuestas.repositorio.Interfaz;
using SistemaEncuestas.repositorio.repositorios;
using SistemaEncuestas.Repositorio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Negocios
{
    public class EncuestaService
    {
        //Inyeccion de dependencia
        IUnitOfWork unitOfWork;
        IEncuesta encuestaRepo;

        public EncuestaService() : this(new EncuestaRepository(), new UnitOfWork()) { }
        public EncuestaService(IEncuesta _encuestaRepo, IUnitOfWork _unitOfWork)
        {
            //mis variable, la hace propia (variable local) solo en el metodo
            this.encuestaRepo = _encuestaRepo;
            this.unitOfWork = _unitOfWork;
        }

        public List<Encuesta> ListarTodo()
        {
            try
            {
                return encuestaRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Guardar(Encuesta entity)
        {
            try
            {
                encuestaRepo.Create(entity);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return false;

            }
        }

        //objeto temporal, si en null no existe nos regresa nulo
        public Encuesta ObtenerPorId(int Id)
        {
            try
            {
                Encuesta temp = encuestaRepo.GetById(Id);
                if (temp != null)
                    return temp;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //cambio su status
        //aca el activa o desactiva el status
        public void Eliminar(int Id)
        {
            try
            {
                var temp = encuestaRepo.GetById(Id);
                if (temp.Status == 1)
                    temp.Status = 0;
                else if (temp.Status == 0)
                    temp.Status = 1;
                encuestaRepo.Update(temp);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
            }
        }

        public void Actualizar(Encuesta entity)
        {
            try
            {
                encuestaRepo.Update(entity);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }



    }
}