using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisacadFinal.Models;
using SisacadFinal.Models.Dto;

namespace SisacadFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReglasCors")]
    public class MateriasController : ControllerBase
    {

        public readonly FinalmuContext _dbContex;
        private readonly IMapper _mapper;

        public MateriasController(FinalmuContext _context, IMapper mapper)
        {
            _dbContex = _context ?? throw new ArgumentNullException();
            _mapper = mapper;

        }



        [HttpGet]
        [ProducesResponseType(200)]
        [Route("Lista")]
        public IActionResult ListaMaterias()
        {
            List <Materia> lista = new List<Materia>();
            try
            {

                var materias = _dbContex.Materias.ToList();

                // Usa AutoMapper para mapear la lista de estudiantes a una lista de EstudiantesDto
                lista = _mapper.Map<List<Materia>>(materias);


                // lista = _dbContex.EstudiantesDto.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message, response = lista });
            }

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Route("GuardarMateria")]
        public IActionResult GuardarMateria([FromBody] MateriasDto objetoDto)
        {
            try
            {

                var objeto = _mapper.Map<Materia>(objetoDto);
                _dbContex.Materias.Add(objeto);
                //var profesorDto = _mapper.Map<ProfesoresDto>(objeto);
                //_dbContex.Profesores.Add(profesorDto);
                _dbContex.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });


            }
            catch (Exception ex)
            {
                // return StatusCode(StatusCodes.Status200OK, new { ex.Message });
                return BadRequest(new { message = ex.Message });
            }

        }






    }
}
