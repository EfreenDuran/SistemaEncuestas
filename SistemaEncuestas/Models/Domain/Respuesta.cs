using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.Domain
{
    public class Respuesta
    {
        //propiedades de la clase
        [Key]
        public int Id { get; set; }
        public string Respuestas { get; set; }
        [ForeignKey]
        public String IdPregunta { get; set; }
        [ForeignKey]
        public String IdUsuario { get; set; }

        public virtual ApplicationUser AspNetUsers { get; set; }
        public virtual ICollection<Preguntas> Preguntas { get; set; }
    }
}
