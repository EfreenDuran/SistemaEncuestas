using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SistemaEncuestas.Models.Domain
{
    public class Categoria
    {
        [Key]
        public int Id { get; set;}
        [StringLength(100)]
        public string Nombre { get; set;}
        public int Status { get; set;}

        public virtual ICollection<Encuesta> Encuestas { get; set; }

    }

}