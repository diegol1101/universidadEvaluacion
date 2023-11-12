using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
        {
            public void Configure(EntityTypeBuilder<Profesor> builder)
            {
                builder.ToTable("profesor");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id);
    
                builder.HasOne(p => p.Departamento)
                .WithMany(p => p.Profesores)
                .HasForeignKey(p => p.Id_Departamento);

                builder.HasOne(p => p.Persona)
                .WithMany(p => p.Profesores)
                .HasForeignKey(p => p.Id_Profesor)
                .IsRequired(false);
            }
        }