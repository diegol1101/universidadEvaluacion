using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    protected readonly UniversidadEvaluacionContext _context;

    public PersonaRepository(UniversidadEvaluacionContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Object>> Alumnos()
    {
        var dato = await _context.Personas
            .Where(p => p.TipoPersona == Persona.Tipo.alumno)
            .OrderBy(p => p.Apellido1)
            .ThenBy(P => P.Apellido2)
            .ThenBy(P => P.Nombre)
            .Select(p => new
            {
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                Nombre = p.Nombre
            }).ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> AlumnosTelefono()
    {
        var datos = await _context.Personas
            .Where(p => p.TipoPersona == Persona.Tipo.alumno && string.IsNullOrEmpty(p.Telefono))
            .OrderBy(p => p.Apellido1)
            .ThenBy(p => p.Apellido2)
            .ThenBy(p => p.Nombre)
            .Select(p => new
            {
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                Nombre = p.Nombre
            })
            .ToListAsync();

        return datos;
    }

    public async Task<IEnumerable<object>> AlumnosNacidosEn1999()
    {
        var datos = await _context.Personas
            .Where(p => p.TipoPersona == Persona.Tipo.alumno && p.Fecha_Nacimiento.Year == 1999)
            .OrderBy(p => p.Apellido1)
            .ThenBy(p => p.Apellido2)
            .ThenBy(p => p.Nombre)
            .Select(p => new
            {
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                Nombre = p.Nombre,
                Fecha = p.Fecha_Nacimiento
            })
            .ToListAsync();

        return datos;
    }

    public async Task<IEnumerable<object>> ProfesoresSinTelefonoYConNIFTerminadoEnK()
    {
        var datos = await _context.Profesores
            .Where(p => string.IsNullOrEmpty(p.Persona.Telefono) && p.Persona.Nif.EndsWith("K"))
            .OrderBy(p => p.Persona.Apellido1)
            .ThenBy(p => p.Persona.Apellido2)
            .ThenBy(p => p.Persona.Nombre)
            .Select(p => new
            {
                PrimerApellido = p.Persona.Apellido1,
                SegundoApellido = p.Persona.Apellido2,
                Nif = p.Persona.Nif,
                Nombre = p.Persona.Nombre
            })
            .ToListAsync();

        return datos;
    }
    public async Task<IEnumerable<object>> AlumnasIngenieriaInformatica()
    {
        var dato = await (
            from m in _context.Alumno_Se_Matricula_Asignaturas
            join p in _context.Personas on m.Id_Alumno equals p.Id
            join a in _context.Asignaturas on m.Id_Asignatura equals a.Id
            join g in _context.Grados on a.Id_Grado equals g.Id
            where p.Genero == Persona.Sexo.M
            where g.Nombre.Contains("Grado en Ingeniería Informática (Plan 2015)")
            select new
            {
                nif = p.Nif,
                Nombre = p.Nombre,
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,

            }).Distinct()
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> OfertaIngInformatica2015()
    {
        var dato = await (
            from a in _context.Asignaturas
            join g in _context.Grados on a.Id_Grado equals g.Id
            where g.Nombre.Contains("Grado en Ingeniería Informática (Plan 2015)")
            select new
            {
                Asignatura = a.Nombre,
                curso = a.Curso,
                creditos = a.Creditos
            }).Distinct()
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> ProfesorDepartamento()
    {
        var dato = await (
            from pr in _context.Profesores
            join d in _context.Departamentos on pr.Id_Departamento equals d.Id
            join p in _context.Personas on pr.Id_Profesor equals p.Id
            where p.TipoPersona == Persona.Tipo.profesor
            select new
            {
                primerApellido = p.Apellido1,
                segundoApellido = p.Apellido2,
                nombre = p.Nombre,
                nombreDepartamento = d.Nombre
            }).Distinct()
            .OrderBy(p => p.primerApellido)
            .ThenBy(p => p.segundoApellido)
            .ThenBy(p => p.nombre)
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> Curso20182019()
    {
        var dato = await _context.Alumno_Se_Matricula_Asignaturas
            .Where(a => a.Curso_Escolar.Anyo_Inicio == 2018 && a.Curso_Escolar.Anyo_Fin == 2019)
            .Join(_context.Personas,
                matricula => matricula.Id_Alumno,
                persona => persona.Id,
                (matricula, persona) => new
                {
                    PrimerApellido = persona.Apellido1,
                    SegundoApellido = persona.Apellido2,
                    Nombre = persona.Nombre
                })
            .OrderBy(p => p.PrimerApellido)
            .ThenBy(p => p.SegundoApellido)
            .ThenBy(p => p.Nombre)
            .ToListAsync();

        return dato;
    }

    public async Task<IEnumerable<object>> ConsultaProfesoresConDepartamentos()
    {
        var dato = await (
            from prof in _context.Profesores
            join p in _context.Personas on prof.Id_Profesor equals p.Id
            join dep in _context.Departamentos on prof.Id_Departamento equals dep.Id into departments
            from department in departments.DefaultIfEmpty()
            select new
            {
                NombreDepartamento = department != null ? department.Nombre : "Sin departamento",
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                NombreProfesor = p.Nombre
            })
            .OrderBy(dto => dto.NombreDepartamento)
            .ThenBy(dto => dto.PrimerApellido)
            .ThenBy(dto => dto.SegundoApellido)
            .ThenBy(dto => dto.NombreProfesor)
            .ToListAsync();

        return dato;
    }

    public async Task<int> ContarAlumnas()
    {
        var cantidadAlumnas = await _context.Personas
            .Where(p => p.TipoPersona == Persona.Tipo.alumno && p.Genero == Persona.Sexo.M) // Ajusta la comparación de género según tu modelo
            .CountAsync();

        return cantidadAlumnas;
    }

    public async Task<int> ContarAlumnosNacidosEn1999()
    {
        var cantidadAlumnos = await _context.Personas
            .Where(p => p.TipoPersona == Persona.Tipo.alumno && p.Fecha_Nacimiento.Year == 1999)
            .CountAsync();

        return cantidadAlumnos;
    }

    public async Task<IEnumerable<object>> ContarProfesoresPorDepartamento()
    {
        var datos = await _context.Profesores
            .Join(_context.Departamentos,
                  profesor => profesor.Id_Departamento,
                  departamento => departamento.Id,
                  (profesor, departamento) => new { Profesor = profesor, Departamento = departamento })
            .GroupBy(p => p.Departamento.Nombre)
            .OrderByDescending(g => g.Count())
            .Select(g => new
            {
                NombreDepartamento = g.Key,
                CantidadProfesores = g.Count()
            })
            .ToListAsync();

        return datos;
    }

    public async Task<IEnumerable<object>> ContarLosProfesoresPorDepartamentos()
    {
        var datos = await (
            from departamento in _context.Departamentos
            join profesor in _context.Profesores on departamento.Id equals profesor.Id_Departamento into profesoresGroup
            select new
            {
                NombreDepartamento = departamento.Nombre,
                NumeroProfesores = profesoresGroup.Count()
            }
        ).ToListAsync();

        return datos;
    }











}






