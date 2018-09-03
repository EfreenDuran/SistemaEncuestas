using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEncuestas.Models.domain
{
    public class Pregunta
    {
        //Primary Key
        [Key]
        public int Id { get; set; }
        //preguntas de maximo 60 caracteres
        [StringLength(60)]
        public string Pregunta { get; set; }
        //llave foranea(tabla de referencia)
        [ForeignKey("Encuestas")]
        public int IdEncuesta { get; set; }
        
       
        public virtual Encuesta Encuestas { get; set; }        
        public virtual ICollection<Respuesta> Respuestas { get; set; }

    }
}