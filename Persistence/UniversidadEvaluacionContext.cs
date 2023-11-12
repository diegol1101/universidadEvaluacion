using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

    public class UniversidadEvaluacionContext:DbContext
    {
        public UniversidadEvaluacionContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Alumno_se_Matricula_Asignatura> Alumno_Se_Matricula_Asignaturas {get; set;}
        public DbSet<Asignatura> Asignaturas {get; set;}
        public DbSet<Curso_Escolar> Curso_Escolares {get; set;}
        public DbSet<Departamento> Departamentos {get; set;}
        public DbSet<Grado> Grados {get; set;}
        public DbSet<Persona> Personas {get; set;}
        public DbSet<Profesor> Profesores {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}
