
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class Alumno_se_Matricula_AsignaturaController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public Alumno_se_Matricula_AsignaturaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Alumno_se_Matricula_AsignaturaDto>>> Get()
    {
        var alumno_se_Matricula_Asignatura = await unitofwork.Alumno_se_Matricula_Asignaturas.GetAllAsync();
        return mapper.Map<List<Alumno_se_Matricula_AsignaturaDto>>(alumno_se_Matricula_Asignatura);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Alumno_se_Matricula_AsignaturaDto>> Get(int id)
    {
        var alumno_se_Matricula_Asignatura = await unitofwork.Alumno_se_Matricula_Asignaturas.GetByIdAsync(id);
        if (alumno_se_Matricula_Asignatura == null)
        {
            return NotFound();
        }
        return this.mapper.Map<Alumno_se_Matricula_AsignaturaDto>(alumno_se_Matricula_Asignatura);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Alumno_se_Matricula_Asignatura>> Post(Alumno_se_Matricula_AsignaturaDto alumno_se_Matricula_AsignaturaDto)
    {
        var alumno_se_Matricula_Asignatura = this.mapper.Map<Alumno_se_Matricula_Asignatura>(alumno_se_Matricula_AsignaturaDto);
        this.unitofwork.Alumno_se_Matricula_Asignaturas.Add(alumno_se_Matricula_Asignatura);
        await unitofwork.SaveAsync();
        if (alumno_se_Matricula_Asignatura == null)
        {
            return BadRequest();
        }
        alumno_se_Matricula_AsignaturaDto.Id = alumno_se_Matricula_Asignatura.Id;
        return CreatedAtAction(nameof(Post), new { id = alumno_se_Matricula_AsignaturaDto.Id }, alumno_se_Matricula_AsignaturaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Alumno_se_Matricula_AsignaturaDto>> Put(int id, [FromBody] Alumno_se_Matricula_AsignaturaDto alumno_se_Matricula_AsignaturaDto)
    {
        if (alumno_se_Matricula_AsignaturaDto == null)
        {
            return NotFound();
        }
        var alumno_se_Matricula_Asignatura = this.mapper.Map<Alumno_se_Matricula_Asignatura>(alumno_se_Matricula_AsignaturaDto);
        unitofwork.Alumno_se_Matricula_Asignaturas.Update(alumno_se_Matricula_Asignatura);
        await unitofwork.SaveAsync();
        return alumno_se_Matricula_AsignaturaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var alumno_se_Matricula_Asignatura = await unitofwork.Alumno_se_Matricula_Asignaturas.GetByIdAsync(id);
        if (alumno_se_Matricula_Asignatura == null)
        {
            return NotFound();
        }
        unitofwork.Alumno_se_Matricula_Asignaturas.Remove(alumno_se_Matricula_Asignatura);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    
}
