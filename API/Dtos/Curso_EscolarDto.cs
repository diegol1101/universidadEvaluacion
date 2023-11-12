using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;

    public class Curso_EscolarDto:BaseEntity
    {
        public int Anyo_Inicio {get; set;}
        public int Anyo_Fin {get; set;}
    }
