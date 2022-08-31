﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectoef.Models
{
    public class Tarea
    {
        [Key]
        public Guid TareaId { get; set; }

        [ForeignKey("CagegoriaId")]
        public Guid CategoriaId{ get; set; }

        [Required]
        [MaxLength(200)]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Categoria Categroia { get; set; }

        [NotMapped]
        public string Resumen { get; set; }

    }

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
}
