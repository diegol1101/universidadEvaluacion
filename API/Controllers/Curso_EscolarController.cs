


using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class Curso_EscolarController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public Curso_EscolarController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Curso_EscolarDto>>> Get()
    {
        var curso_Escolar = await unitofwork.Curso_Escolares.GetAllAsync();
        return mapper.Map<List<Curso_EscolarDto>>(curso_Escolar);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Curso_EscolarDto>> Get(int id)
    {
        var curso_Escolar = await unitofwork.Curso_Escolares.GetByIdAsync(id);
        if (curso_Escolar == null)
        {
            return NotFound();
        }
        return this.mapper.Map<Curso_EscolarDto>(curso_Escolar);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Curso_Escolar>> Post(Curso_EscolarDto curso_EscolarDto)
    {
        var curso_Escolar = this.mapper.Map<Curso_Escolar>(curso_EscolarDto);
        this.unitofwork.Curso_Escolares.Add(curso_Escolar);
        await unitofwork.SaveAsync();
        if (curso_Escolar == null)
        {
            return BadRequest();
        }
        curso_EscolarDto.Id = curso_Escolar.Id;
        return CreatedAtAction(nameof(Post), new { id = curso_EscolarDto.Id }, curso_EscolarDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Curso_EscolarDto>> Put(int id, [FromBody] Curso_EscolarDto curso_EscolarDto)
    {
        if (curso_EscolarDto == null)
        {
            return NotFound();
        }
        var curso_Escolar = this.mapper.Map<Curso_Escolar>(curso_EscolarDto);
        unitofwork.Curso_Escolares.Update(curso_Escolar);
        await unitofwork.SaveAsync();
        return curso_EscolarDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var curso_Escolar = await unitofwork.Curso_Escolares.GetByIdAsync(id);
        if (curso_Escolar == null)
        {
            return NotFound();
        }
        unitofwork.Curso_Escolares.Remove(curso_Escolar);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    
    }
}