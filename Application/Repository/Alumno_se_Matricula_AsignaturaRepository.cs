
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository
{
    public class Alumno_se_Matricula_AsignaturaRepository : GenericRepository<Alumno_se_Matricula_Asignatura>, IAlumno_se_Matricula_Asignatura
    {
        protected readonly UniversidadEvaluacionContext _context;

        public Alumno_se_Matricula_AsignaturaRepository(UniversidadEvaluacionContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Alumno_se_Matricula_Asignatura>> GetAllAsync()
        {
            return await _context.Alumno_Se_Matricula_Asignaturas
                .ToListAsync();
        }

        public override async Task<Alumno_se_Matricula_Asignatura> GetByIdAsync(int id)
        {
            return await _context.Alumno_Se_Matricula_Asignaturas

            .FirstOrDefaultAsync(p => p.Id == id);
        }


    }
}