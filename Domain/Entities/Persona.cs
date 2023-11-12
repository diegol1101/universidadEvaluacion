using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Persona:BaseEntity
    {
        public string Nif {get; set;}
        public string Nombre {get; set;}
        public string Apellido1 {get; set;}
        public string Apellido2 {get; set;}
        public string Ciudad {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
        public DateTime Fecha_Nacimiento {get; set;}
        public enum Sexo {
            H,M
        }
        public Sexo Genero {get; set;}

        public enum Tipo {
            profesor,alumno
        }
        public Tipo TipoPersona {get; set;}

        public ICollection<Profesor> Profesores {get; set;}
        public ICollection<Alumno_se_Matricula_Asignatura> Alumno_se_Matricula_Asignaturas {get; set;}
    }
