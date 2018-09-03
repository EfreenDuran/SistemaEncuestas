using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.domain
{
    public class Categoria
    {
        [Key]
        public int Id { get; set;}
        [StringLength(100)]
        public string Categoria { get; set;}
        public int Status { get; set;}

        public virtual ICollection<Encuesta> Encuentas { get; set; }

    }

}