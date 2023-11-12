

using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AsignaturaController : ApiBaseController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public AsignaturaController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> Get()
        {
            var asignatura = await unitofwork.Asignaturas.GetAllAsync();
            return mapper.Map<List<AsignaturaDto>>(asignatura);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AsignaturaDto>> Get(int id)
        {
            var asignatura = await unitofwork.Asignaturas.GetByIdAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }
            return this.mapper.Map<AsignaturaDto>(asignatura);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Asignatura>> Post(AsignaturaDto asignaturaDto)
        {
            var asignatura = this.mapper.Map<Asignatura>(asignaturaDto);
            this.unitofwork.Asignaturas.Add(asignatura);
            await unitofwork.SaveAsync();
            if (asignatura == null)
            {
                return BadRequest();
            }
            asignaturaDto.Id = asignatura.Id;
            return CreatedAtAction(nameof(Post), new { id = asignaturaDto.Id }, asignaturaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AsignaturaDto>> Put(int id, [FromBody] AsignaturaDto asignaturaDto)
        {
            if (asignaturaDto == null)
            {
                return NotFound();
            }
            var asignatura = this.mapper.Map<Asignatura>(asignaturaDto);
            unitofwork.Asignaturas.Update(asignatura);
            await unitofwork.SaveAsync();
            return asignaturaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var asignatura = await unitofwork.Asignaturas.GetByIdAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }
            unitofwork.Asignaturas.Remove(asignatura);
            await unitofwork.SaveAsync();
            return NoContent();
        }

        [HttpGet("AsignaturasPrimerCuatrimestreTercerCursoDelGrado7")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> ObtenerAsignaturasEnPrimerCuatrimestreTercerCursoDelGrado7()
        {
            var entidad = await unitofwork.Asignaturas.AsignaturasEnPrimerCuatrimestreTercerCursoDelGrado7();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }

        [HttpGet("AlumnoNif")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> AlumnoNif()
        {
            var entidad = await unitofwork.Asignaturas.AlumnoNif();
            var dto = mapper.Map<IEnumerable<object>>(entidad);
            return Ok(dto);
        }

        [HttpGet("AsignaturaSinProfesor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> AsignaturaSinProfesor()
        {
            var data = await unitofwork.Asignaturas.AsignaturaSinProfesor();
            return mapper.Map<List<object>>(data);
        }

        [HttpGet("DeptoAsignatura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> DeptoAsignatura()
        {
            var data = await unitofwork.Asignaturas.DeptoAsignatura();
            return mapper.Map<List<object>>(data);
        }

    }
}