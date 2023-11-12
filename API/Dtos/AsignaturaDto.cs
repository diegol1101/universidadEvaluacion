
using Domain.Entities;
using static Domain.Entities.Asignatura;

namespace API.Dtos;

    public class AsignaturaDto:BaseEntity
    {
        public string Nombre {get; set;}
        public double Creditos {get; set;}
        public TipoAsignatura AsignaturaTipo {get; set;}
        public int Curso {get; set;}
        public int Cuatrimestre {get; set;}
    }
