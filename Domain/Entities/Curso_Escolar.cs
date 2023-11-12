using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Curso_Escolar:BaseEntity
    {
        public int Anyo_Inicio {get; set;}
        public int Anyo_Fin {get; set;}

        public ICollection<Alumno_se_Matricula_Asignatura> Alumno_Se_Matricula_Asignaturas {get; set;}
    }
