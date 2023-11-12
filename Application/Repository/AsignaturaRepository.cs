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
    public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignatura
    {
        protected readonly UniversidadEvaluacionContext _context;

        public AsignaturaRepository(UniversidadEvaluacionContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Asignatura>> GetAllAsync()
        {
            return await _context.Asignaturas
                .ToListAsync();
        }

        public override async Task<Asignatura> GetByIdAsync(int id)
        {
            return await _context.Asignaturas
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<object>> AsignaturasEnPrimerCuatrimestreTercerCursoDelGrado7()
        {
            var datos = await _context.Asignaturas
                .Where(a => a.Cuatrimestre == 1 && a.Curso == 3 && a.Id_Grado == 7)
                .OrderBy(a => a.Nombre)
                .Select(a => new
                {
                    NombreAsignatura = a.Nombre,
                    Creditos = a.Creditos,
                    TipoAsignatura = a.AsignaturaTipo
                })
                .ToListAsync();

            return datos;
        }

        public async Task<IEnumerable<object>> AlumnoNif()
        {
            var dato = await (
                from al in _context.Alumno_Se_Matricula_Asignaturas
                join p in _context.Personas on al.Id_Alumno equals p.Id
                join asg in _context.Asignaturas on al.Id_Asignatura equals asg.Id
                join c in _context.Curso_Escolares on al.Id_Curso_Escolar equals c.Id
                where p.TipoPersona == Persona.Tipo.alumno
                where p.Nif == "26902806M"
                select new
                {
                    NombreEstudiante = p.Nombre,
                    Nit = p.Nif,
                    NombreAsig = asg.Nombre,
                    AñoInicio = c.Anyo_Inicio,
                    AñoFinal = c.Anyo_Fin
                }).ToListAsync();

            return dato;
        }

        public async Task<object> AsignaturaSinProfesor()
        {
            var consulta =
            from e in _context.Asignaturas
            where e.Id_profesor == null
            select new
            {
                IdAsignatura = e.Id,
                Nombre = e.Nombre,
                Creditos = e.Creditos,
                Tipo = e.AsignaturaTipo,
                Curso = e.Curso,
                Cuatrimestre = e.Cuatrimestre,
                IdGrado = e.Id_Grado,
                Mensaje = "Esta asignatura no tiene un profesor asignado, asigne un profesor!"
            };

            var entidad = await consulta.ToListAsync();
            return entidad;
        }

        public async Task<object> DeptoAsignatura()
        {
            var consulta =
            from asignatura in _context.Asignaturas
            where !_context.Alumno_Se_Matricula_Asignaturas.Any(matricula => matricula.Id_Asignatura == asignatura.Id)
            select new
            {
                NombreDepartamento = asignatura.Profesor.Departamento.Nombre,
                IdAsignatura = asignatura.Id,
                NombreAsignatura = asignatura.Nombre
            };

            var entidad = await consulta.ToListAsync();
            return entidad;
        }
    }
}