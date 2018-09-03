using SistemaEncuestas.Models.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.Domain
{
    public class Escuesta
    {
        //llave primaria
        [Key]
        public int Id { get; set; }
        //RESTRICCION DEL STRING DE 40 CARACTERES
        [StringLength(40)]
        public string Encuesta { get; set; }
        //Restriccion de string 30 caracteres
        [StringLength(30)]
        public string Status { get; set; }
        //llave foranea(tabla de referencia)
        [ForeignKey("Categorias")]
        public int IdCategorias { get; set; }



        //propiedad de navegacion(en bd son las cardinalidades)
        //HACE REFERENCIA A LA CLASE CATEGORIA
        public virtual Categoria Categorias { get; set; }
        //
        public virtual ICollection<Pregunta> Preguntas { get; set; }

    }
}

