using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Grado:BaseEntity
    {
        public string Nombre {get; set;}

        /*llaves*/
        public ICollection<Asignatura> Asignaturas {get; set;}
    }
