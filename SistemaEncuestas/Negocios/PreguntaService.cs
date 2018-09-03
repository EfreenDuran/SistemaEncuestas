using System;

namespace SistemaEncuestas.Negocios { 
    public class PreguntaService
    {
        //Inyeccion de dependencia
        IUnitOfWork unitOfWork;
        IEncuesta encuestaRepo;

        public PreguntaService() : this(new PreguntaRepository(), new UnittOfWork()) { }
        public PreguntaService(IPregunta _preguntaRepo, IUnitOfWork _unitOfWork)
        {
            this.preguntaRepo = _preguntaRepo;
            this.unitOfWork = _unitOfWork;
        }

        public List<Pregunta> ListarTodo()
        {
            try
            {
                return preguntaRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Guardar(Pregunta entity)
        {
            try
            {
                preguntaRepo.Create(entity);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return false;

            }
        }

        public Pregunta ObtenerPorId(int Id)
        {
            try
            {
                Pregunta temp = preguntaRepo.GetById(Id);
                if (temp != null)
                    return temp;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
        public void Eliminar(int Id)
        {
            try
            {
                preguntaRepo.Delete(Id);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
            }
        }

        public void Actualizar(Pregunta entity)
        {
            try
            {
                preguntaRepo.Update(entity);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }
    }
}