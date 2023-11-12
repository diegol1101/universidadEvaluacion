using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ProfesorDto:BaseEntity
    {
        public int Id_Profesor {get; set;}
        public Persona Persona {get; set;}

        public int Id_Departamento {get; set;}
        public Departamento Departamento {get; set;}
    }
}