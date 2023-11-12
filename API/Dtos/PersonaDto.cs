
using Domain.Entities;
using static Domain.Entities.Persona;

namespace API.Dtos;

    public class PersonaDto:BaseEntity
    {
        public string Nif {get; set;}
        public string Nombre {get; set;}
        public string Apellido1 {get; set;}
        public string Apellido2 {get; set;}
        public string Ciudad {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
        public DateTime Fecha_Nacimiento {get; set;}
        public Sexo Genero {get; set;}
        public Tipo TipoPersona {get; set;}
    }

    
