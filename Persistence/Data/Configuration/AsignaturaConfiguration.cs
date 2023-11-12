using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
        {
            public void Configure(EntityTypeBuilder<Asignatura> builder)
            {
                builder.ToTable("asignatura");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(150);

                builder.Property(e => e.Creditos)
                .HasColumnName("creditos")
                .HasColumnType("double")
                .IsRequired();
                
                builder.Property(p => p.AsignaturaTipo)
                .HasColumnName("asignaturatipo")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired()
                .HasConversion<string>();

                builder.Property(e => e.Curso)
                .HasColumnName("curso")
                .IsRequired();

                builder.Property(e => e.Cuatrimestre)
                .HasColumnName("cuatrimestre")
                .IsRequired()
                .HasMaxLength(50);

                builder.HasOne(p => p.Profesor)
                .WithMany(p => p.Asignaturas)
                .HasForeignKey(p => p.Id_profesor)
                .IsRequired(false);

                builder.HasOne(p => p.Grado)
                .WithMany(p => p.Asignaturas)
                .HasForeignKey(p => p.Id_Grado);
            }
        }
}