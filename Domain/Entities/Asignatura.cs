using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Asignatura:BaseEntity
    {
        public string Nombre {get; set;}
        public double Creditos {get; set;}
        public enum TipoAsignatura {
            basica,optativa,obligatoria
        }
        public TipoAsignatura AsignaturaTipo {get; set;}
        public int Curso {get; set;}
        public int Cuatrimestre {get; set;}


        public int? Id_profesor {get; set;}
        public Profesor Profesor {get; set;}

        public int Id_Grado {get; set;}
        public Grado Grado {get; set;}

        public ICollection<Alumno_se_Matricula_Asignatura> Alumno_se_Matricula_Asignaturas {get; set;}

    }
