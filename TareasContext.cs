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
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("d7352e8e-7435-40d3-99bb-353290b10546"), Nombre = "Actividades pendientes", Peso = 20});
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("d7352e8e-7435-40d3-99bb-353290b10547"), Nombre = "Actividades personales", Peso = 50 });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");

                categoria.HasKey(p => p.CategoriaId);

                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(200);

                categoria.Property(p => p.Descripcion).HasMaxLength(200);

                categoria.Property(p => p.Peso);

                categoria.HasData(categoriasInit);
            });

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("d7352e8e-7435-40d3-99bb-353290b10548"),
                CategoriaId = Guid.Parse("d7352e8e-7435-40d3-99bb-353290b10546"),
                PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now
            });

            tareasInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("d7352e8e-7435-40d3-99bb-353290b10549"),
                CategoriaId = Guid.Parse("d7352e8e-7435-40d3-99bb-353290b10547"),
                PrioridadTarea = Prioridad.Baja,
                Titulo = "Terminar de ver serie",
                FechaCreacion = DateTime.Now
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

                tarea.HasData(tareasInit);

            });
        }
    }
}
