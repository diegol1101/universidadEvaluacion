using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly UniversidadEvaluacionContext _context;
        private Alumno_se_Matricula_AsignaturaRepository _alumno_se_Matricula_Asignaturas;
        private AsignaturaRepository _asignaturas;
        private Curso_EscolarRepository _curso_Escolares;
        private DepartamentoRepository _departamentos;
        private GradoRepository _grados;
        private PersonaRepository _personas;
        private ProfesorRepository _profesores;


        public UnitOfWork(UniversidadEvaluacionContext context)
        {
            _context = context;
        }


        public IAlumno_se_Matricula_Asignatura Alumno_se_Matricula_Asignaturas
        {
            get
            {
                if (_alumno_se_Matricula_Asignaturas == null)
                {
                    _alumno_se_Matricula_Asignaturas = new Alumno_se_Matricula_AsignaturaRepository(_context);
                }
                return _alumno_se_Matricula_Asignaturas;
            }
        }

        public IAsignatura Asignaturas
        {
            get
            {
                if (_asignaturas == null)
                {
                    _asignaturas = new AsignaturaRepository(_context);
                }
                return _asignaturas;
            }
        }

        
        public ICurso_Escolar Curso_Escolares
            {
                get
                {
                    if (_curso_Escolares == null)
                    {
                        _curso_Escolares = new Curso_EscolarRepository(_context);
                    }
                    return _curso_Escolares;
                }
            }

        
        public IDepartamento Departamentos
            {
                get
                {
                    if (_departamentos == null)
                    {
                        _departamentos = new DepartamentoRepository(_context);
                    }
                    return _departamentos;
                }
            }
        
        public IGrado Grados
            {
                get
                {
                    if (_grados == null)
                    {
                        _grados = new GradoRepository(_context);
                    }
                    return _grados;
                }
            }
        
        public IPersona Personas
            {
                get
                {
                    if (_personas == null)
                    {
                        _personas = new PersonaRepository(_context);
                    }
                    return _personas;
                }
            }
        
        public IProfesor Profesores
            {
                get
                {
                    if (_profesores == null)
                    {
                        _profesores = new ProfesorRepository(_context);
                    }
                    return _profesores;
                }
            }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}