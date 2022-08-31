using System.ComponentModel.DataAnnotations;

namespace projectoef.Models
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
