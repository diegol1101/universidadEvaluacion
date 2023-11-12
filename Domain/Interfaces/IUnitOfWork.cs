using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;

    public interface IUnitOfWork 
    {
        IAlumno_se_Matricula_Asignatura Alumno_se_Matricula_Asignaturas {get;}
        IAsignatura Asignaturas {get;}
        ICurso_Escolar Curso_Escolares {get;}
        IDepartamento Departamentos {get;}
        IGrado Grados {get;}
        IPersona Personas {get;}
        IProfesor Profesores {get;}
        Task<int> SaveAsync();
    }
