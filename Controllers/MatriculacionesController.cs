using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisacadFinal.Models;
using SisacadFinal.Models.Dto;

namespace SisacadFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReglasCors")]

    public class MatriculacionesController : ControllerBase
    {
        public readonly FinalmuContext _dbContex;
        private readonly IMapper _mapper;

        public MatriculacionesController(FinalmuContext _context, IMapper mapper)
        {
            _dbContex = _context ?? throw new ArgumentNullException();
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200)]
        [Route("ListaMatriculaciones")]
        public IActionResult ListaMatriculaciones()
        {
            List<Matriculacione> lista = new List<Matriculacione>();
            try
            {

                var matriculaciones = _dbContex.Matriculaciones.ToList();

                // Usa AutoMapper para mapear la lista de estudiantes a una lista de EstudiantesDto
                lista = _mapper.Map<List<Matriculacione>>(matriculaciones);


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
        [Route("GuardarMatriculacion")]
        public IActionResult GuardarMatriculacion([FromBody] MatriculacionesDto objetoDto)
        {
            try
            {

                var objeto = _mapper.Map<Matriculacione>(objetoDto);
                _dbContex.Matriculaciones.Add(objeto);
                //var profesorDto = _mapper.Map<ProfesoresDto>(objeto);
                //_dbContex.Profesores.Add(profesorDto);
                _dbContex.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });


            }
            catch (Exception ex)
            {
                string innerMessage = "";

                if (ex.InnerException != null)
                {
                    innerMessage = ex.InnerException.Message;
                }

                return BadRequest(new { message = ex.Message, innerMessage = innerMessage });
            }


        }


    }
}
