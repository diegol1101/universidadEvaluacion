using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Profesor:BaseEntity
    {
        public int ? Id_Profesor {get; set;}
        public Persona Persona {get; set;}

        public int Id_Departamento {get; set;}
        public Departamento Departamento {get; set;}

        public ICollection<Asignatura> Asignaturas {get; set;}
    }
