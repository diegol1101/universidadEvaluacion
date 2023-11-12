using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
        {
            public void Configure(EntityTypeBuilder<Persona> builder)
            {
                builder.ToTable("persona");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Nif)
                .HasColumnName("nif")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(e => e.Apellido1)
                .HasColumnName("apellido1")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(e => e.Apellido2)
                .HasColumnName("apellido2")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(e => e.Ciudad)
                .HasColumnName("ciudad")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(e => e.Direccion)
                .HasColumnName("direccion")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(e => e.Telefono)
                .HasColumnName("telefono")
                .HasMaxLength(50);

                builder.Property(e => e.Fecha_Nacimiento)
                .HasColumnName("fechanacimiento")
                .HasColumnType("datetime")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(p => p.Genero)
                .HasColumnName("genero")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired()
                .HasConversion<string>();

                builder.Property(p => p.TipoPersona)
                .HasColumnName("tipopersona")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired()
                .HasConversion<string>();
            }
        }
