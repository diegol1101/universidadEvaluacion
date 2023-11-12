using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonaController : ApiBaseController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public PersonaController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var persona = await unitofwork.Personas.GetAllAsync();
            return mapper.Map<List<PersonaDto>>(persona);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var persona = await unitofwork.Personas.GetByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return this.mapper.Map<PersonaDto>(persona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Persona>> Post(PersonaDto personaDto)
        {
            var persona = this.mapper.Map<Persona>(personaDto);
            this.unitofwork.Personas.Add(persona);
            await unitofwork.SaveAsync();
            if (persona == null)
            {
                return BadRequest();
            }
            personaDto.Id = persona.Id;
            return CreatedAtAction(nameof(Post), new { id = personaDto.Id }, personaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto personaDto)
        {
            if (personaDto == null)
            {
                return NotFound();
            }
            var persona = this.mapper.Map<Persona>(personaDto);
            unitofwork.Personas.Update(persona);
            await unitofwork.SaveAsync();
            return personaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var persona = await unitofwork.Personas.GetByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            unitofwork.Personas.Remove(persona);
            await unitofwork.SaveAsync();
            return NoContent();
        }




        [HttpGet("Alumnos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> Alumnos()
        {
            var entidad = await unitofwork.Personas.Alumnos();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }


        [HttpGet("AlumnosTelefono")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> ObtenerAlumnosSinTelefono()
        {
            var entidad = await unitofwork.Personas.AlumnosTelefono();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }


        [HttpGet("AlumnosNacidosEn1999")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> ObtenerAlumnosNacidosEn1999()
        {
            var entidad = await unitofwork.Personas.AlumnosNacidosEn1999();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }

        [HttpGet("ProfesoresSinTelefonoYConNifTerminadoEnK")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> ObtenerProfesoresSinTelefonoYConNIFTerminadoEnK()
        {
            var entidad = await unitofwork.Personas.ProfesoresSinTelefonoYConNIFTerminadoEnK();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }

        [HttpGet("AlumnasIngenieriaInformatica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> AlumnasIngenieriaInformatica()
        {
            var entidad = await unitofwork.Personas.AlumnasIngenieriaInformatica();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }

        [HttpGet("OfertaIngInformatica2015")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> OfertaIngInformatica2015()
        {
            var entidad = await unitofwork.Personas.OfertaIngInformatica2015();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }

        [HttpGet("ProfesorDepartamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> ProfesorDepartamento()
        {
            var entidad = await unitofwork.Personas.ProfesorDepartamento();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }

        [HttpGet("Curso20182019")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> Curso20182019()
        {
            var entidad = await unitofwork.Personas.Curso20182019();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }

        [HttpGet("ProfesoresConDepartamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> ProfesoresConDepartamentos()
        {
            var entidad = await unitofwork.Personas.ConsultaProfesoresConDepartamentos();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }

        [HttpGet("ContarAlumnas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> ContarAlumnas()
        {
            var cantidadAlumnas = await unitofwork.Personas.ContarAlumnas();
            return Ok(cantidadAlumnas);
        }

        [HttpGet("ContarAlumnosNacidosEn1999")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> ContarAlumnosNacidosEn1999()
        {
            var cantidadAlumnos = await unitofwork.Personas.ContarAlumnosNacidosEn1999();
            return Ok(cantidadAlumnos);
        }

        [HttpGet("ContarProfesoresPorDepartamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> ContarProfesoresPorDepartamento()
        {
            var entidad = await unitofwork.Personas.ContarProfesoresPorDepartamento();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }

        [HttpGet("ContarLosProfesoresPorDepartamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> ContarLosProfesoresPorDepartamentos()
        {
            var entidad = await unitofwork.Personas.ContarLosProfesoresPorDepartamentos();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }








    }
}