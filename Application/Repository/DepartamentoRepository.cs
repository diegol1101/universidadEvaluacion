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
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
    {
        protected readonly UniversidadEvaluacionContext _context;

        public DepartamentoRepository(UniversidadEvaluacionContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos
                .ToListAsync();
        }

        public override async Task<Departamento> GetByIdAsync(int id)
        {
            return await _context.Departamentos
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<object>> ProfesorDepAsig()
        {
            var dato = await (
                from a in _context.Asignaturas
                join pr in _context.Profesores on a.Id_profesor equals pr.Id_Profesor
                join p in _context.Personas on pr.Id_Profesor equals p.Id
                join d in _context.Departamentos on pr.Id_Departamento equals d.Id
                join g in _context.Grados on a.Id_Grado equals g.Id
                where g.Nombre.Contains("Grado en Ingeniería Informática (Plan 2015)")
                where p.TipoPersona == Persona.Tipo.profesor
                select new
                {
                    nombredepto = d.Nombre
                }).Distinct()
                .ToListAsync();
            return dato;
        }

        public async Task<object> DeptoSinProfesor()
        {
            var consulta =
                from departamento in _context.Departamentos
                join profesor in _context.Profesores on departamento.Id equals profesor.Id_Departamento into profesoresDepartamento
                where !profesoresDepartamento.Any()
                select new
                {
                    IdDepartamento = departamento.Id,
                    NombreDepartamento = departamento.Nombre,
                    Mensaje = "Este departamento no tiene profesores asociados, asocia un profesor!"
                };

            var entidad = await consulta.ToListAsync();
            return entidad;
        }
    }
}