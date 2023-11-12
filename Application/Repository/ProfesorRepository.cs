using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository
{
    public class ProfesorRepository : GenericRepository<Profesor>, IProfesor
    {
        protected readonly UniversidadEvaluacionContext _context;

        public ProfesorRepository(UniversidadEvaluacionContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            return await _context.Profesores
                .ToListAsync();
        }

        public override async Task<Profesor> GetByIdAsync(int id)
        {
            return await _context.Profesores
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<object> ProfesorSinAsignatura()
        {
            var consulta =
                from profesor in _context.Profesores
                join asignatura in _context.Asignaturas on profesor.Id_Profesor equals asignatura.Id_profesor into asignaturasProfesor
                where !asignaturasProfesor.Any()
                select new
                {
                    IdProfesor = profesor.Id_Profesor,
                    NombreProfesor = profesor.Persona.Nombre,
                    Apellido1Profesor = profesor.Persona.Apellido1,
                    Apellido2Profesor = profesor.Persona.Apellido2,
                    Mensaje = "Este profesor no tiene una asignatura asignada, asigna una asignatura"
                };

            var entidad = await consulta.ToListAsync();
            return entidad;
        }
    }
}