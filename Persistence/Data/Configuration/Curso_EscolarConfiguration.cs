using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class Curso_EscolarConfiguration : IEntityTypeConfiguration<Curso_Escolar>
        {
            public void Configure(EntityTypeBuilder<Curso_Escolar> builder)
            {
                builder.ToTable("cursoescolar");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Anyo_Inicio)
                .HasColumnName("añoinicio")
                .HasColumnType("int")
                .IsRequired();


                builder.Property(e => e.Anyo_Fin)
                .HasColumnName("añofin")
                .HasColumnType("int")
                .IsRequired();

            }
        }
