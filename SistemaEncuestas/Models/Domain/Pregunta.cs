using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.Domain
{
    public class Pregunta
    {
        //Primary Key
        [Key]
        public int Id { get; set; }
        //preguntas de maximo 60 caracteres
        [StringLength(60)]
        public string NPregunta { get; set; }
        //llave foranea(tabla de referencia)
        [ForeignKey("Encuestas")]
        public int IdEncuesta { get; set; }
        
       
        public virtual Encuesta Encuestas { get; set; }        
        public virtual ICollection<Respuesta> Respuestas { get; set; }

    }
}