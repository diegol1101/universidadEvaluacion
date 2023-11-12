using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

    public interface IPersona :IGenericRepository<Persona>
    {
        Task<IEnumerable<Object>> Alumnos();
        Task<IEnumerable<object>> AlumnosTelefono();
        Task<IEnumerable<object>> AlumnosNacidosEn1999();
        Task<IEnumerable<object>> ProfesoresSinTelefonoYConNIFTerminadoEnK();
        Task<IEnumerable<object>> AlumnasIngenieriaInformatica();
        Task<IEnumerable<object>> OfertaIngInformatica2015();
        Task<IEnumerable<object>> ProfesorDepartamento();
        Task<IEnumerable<object>> Curso20182019();
        Task<IEnumerable<object>> ConsultaProfesoresConDepartamentos();
        Task<int> ContarAlumnas();
        Task<int> ContarAlumnosNacidosEn1999();
        Task<IEnumerable<object>> ContarProfesoresPorDepartamento();
        Task<IEnumerable<object>> ContarLosProfesoresPorDepartamentos();
    }
