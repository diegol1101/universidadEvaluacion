using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Alumno_se_Matricula_Asignatura:BaseEntity
    {
        public int Id_Alumno {get; set;}
        public Persona Persona {get; set;}

        public int Id_Curso_Escolar {get; set;}
        public Curso_Escolar Curso_Escolar {get; set;}
        
        public int Id_Asignatura {get; set;}
        public Asignatura Asignatura {get; set;}

    }
