using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.repositorio;
using SistemaEncuestas.repositorio.Infraestructura;
using SistemaEncuestas.repositorio.repositorios;

namespace SistemaEncuestas.Negocios
{
    public class CategoriaService
    {
        //Inyeccion de dependencias 
        IUnitOfWork unitOfWork;
        ICategoria categoriaRepo;

        public CategoriaService() : this(new CategoriaRepositorio(), new UnitOfWork()) { }
        public CategoriaService(ICategoria _categoriaRepo, IUnitOfWork _unitOfWork)
        {
            this.categoriaRepo = _categoriaRepo;
            this.unitOfWork = _unitOfWork;
        }
        public List<Categoria> ListarTodo()
        {
            try
            {
                return categoriaRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Guardar(Categoria entity)
        {
            try
            {
                categoriaRepo.Create(entity);
                unitOfWork.Commit();
                return true;

            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return false;
            }
        }
        public Categoria ObtenerPorId(int id)
        {
            try
            {
                Categoria temp = categoriaRepo.GetById(id);
                if (temp != null)
                    return temp;
                return null;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return null;
            }
        }
        public void Eliminar(int id)
        {
            try
            {
                var temp = categoriaRepo.GetbyId(id);
                if (temp.Status == 1)
                    temp.Status = 0;
                else if (temp.Status == 0)
                    temp.Status = 1;
                categoriaRepo.Update(temp);
                unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                unitOfWork.RollBack();
            }
        
            /*
            try
            {
                categoriaRepo.Delete(id);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();

            }*/
        }
        public void Actualizar(Categoria entity)
        {
            try
            {
                categoriaRepo.Update(entity);
                unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();

            }


        }
    }
}