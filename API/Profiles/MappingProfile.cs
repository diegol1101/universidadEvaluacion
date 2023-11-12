
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile (){

            CreateMap<Alumno_se_Matricula_Asignatura,Alumno_se_Matricula_AsignaturaDto>().ReverseMap();
            CreateMap<Asignatura,AsignaturaDto>().ReverseMap();
            CreateMap<Curso_Escolar,Curso_EscolarDto>().ReverseMap();
            CreateMap<Departamento,DepartamentoDto>().ReverseMap();
            CreateMap<Grado,GradoDto>().ReverseMap();
            CreateMap<Persona,PersonaDto>().ReverseMap();
            CreateMap<Profesor,ProfesorDto>().ReverseMap();


        }
    }
}