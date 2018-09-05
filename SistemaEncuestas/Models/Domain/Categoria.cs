using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SistemaEncuestas.Models.Domain
{
    public class Categoria
    {
        private Categoria categoria;

        public Categoria()
        {
        }

        public Categoria(int id)
        {
            Id = id;
        }

        public Categoria(Categoria categoria)
        {
            this.categoria = categoria;
        }

        [Key]
        public int Id { get; set;}
        [StringLength(100)]
        public string Nombre { get; set;}
        public int Status { get; set;}

        public virtual ICollection<Encuesta> Encuestas { get; set; }

    }

}