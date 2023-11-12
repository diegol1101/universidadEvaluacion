using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

    public interface IAsignatura :IGenericRepository<Asignatura>
    {
        Task<IEnumerable<object>> AsignaturasEnPrimerCuatrimestreTercerCursoDelGrado7();
        Task<IEnumerable<object>> AlumnoNif();
        Task<object> AsignaturaSinProfesor();
        Task<object> DeptoAsignatura();
    }
