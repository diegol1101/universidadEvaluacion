


using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GradoController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public GradoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<GradoDto>>> Get()
    {
        var grado = await unitofwork.Grados.GetAllAsync();
        return mapper.Map<List<GradoDto>>(grado);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<GradoDto>> Get(int id)
    {
        var grado = await unitofwork.Grados.GetByIdAsync(id);
        if (grado == null)
        {
            return NotFound();
        }
        return this.mapper.Map<GradoDto>(grado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Grado>> Post(GradoDto gradoDto)
    {
        var grado = this.mapper.Map<Grado>(gradoDto);
        this.unitofwork.Grados.Add(grado);
        await unitofwork.SaveAsync();
        if (grado == null)
        {
            return BadRequest();
        }
        gradoDto.Id = grado.Id;
        return CreatedAtAction(nameof(Post), new { id = gradoDto.Id }, gradoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<GradoDto>> Put(int id, [FromBody] GradoDto gradoDto)
    {
        if (gradoDto == null)
        {
            return NotFound();
        }
        var grado = this.mapper.Map<Grado>(gradoDto);
        unitofwork.Grados.Update(grado);
        await unitofwork.SaveAsync();
        return gradoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var grado = await unitofwork.Grados.GetByIdAsync(id);
        if (grado == null)
        {
            return NotFound();
        }
        unitofwork.Grados.Remove(grado);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    
        
    }
}