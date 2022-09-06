﻿using Microsoft.EntityFrameworkCore;
using projectoef.Models;

namespace projectoef
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");

                categoria.HasKey(p => p.CategoriaId);

                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(200);

                categoria.Property(p => p.Descripcion).HasMaxLength(200);
            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");

                tarea.HasKey(p => p.TareaId);

                tarea.HasOne(p => p.Categroia).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);

                tarea.Property(p => p.Descripcion).HasMaxLength(200);

                tarea.Property(p => p.PrioridadTarea);

                tarea.Property(p => p.FechaCreacion);

                tarea.Ignore(p => p.Resumen);

            });
        }
    }
}
