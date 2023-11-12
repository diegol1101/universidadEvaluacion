using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class Alumno_se_Matricula_AsignaturaConfiguration : IEntityTypeConfiguration<Alumno_se_Matricula_Asignatura>
        {
            public void Configure(EntityTypeBuilder<Alumno_se_Matricula_Asignatura> builder)
            {
                builder.ToTable("alumnosematriculaasignatura");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.HasOne(p => p.Curso_Escolar)
                .WithMany(p => p.Alumno_Se_Matricula_Asignaturas)
                .HasForeignKey(p => p.Id_Curso_Escolar);

                builder.HasOne(p => p.Persona)
                .WithMany(p => p.Alumno_se_Matricula_Asignaturas)
                .HasForeignKey(p => p.Id_Alumno);

                builder.HasOne(p => p.Asignatura)
                .WithMany(p => p.Alumno_se_Matricula_Asignaturas)
                .HasForeignKey(p => p.Id_Asignatura);
            }
        }
