using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisacadFinal.Models.Dto;
using SisacadFinal.Models;

namespace SisacadFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReglasCors")]
    public class MatriculacionesCaerrerasProfesorController : ControllerBase
    {


        public readonly FinalmuContext _dbContex;
        private readonly IMapper _mapper;


        public MatriculacionesCaerrerasProfesorController(FinalmuContext _context, IMapper mapper)
        {
            _dbContex = _context ?? throw new ArgumentNullException();
            _mapper = mapper;

        }



        [HttpGet]
        [ProducesResponseType(200)]
        [Route("ListaMatriculacionesCarreraEst")]
        public IActionResult ListaMatriculacionesCarreraEst()
        {
            List<MatriculacionesCarrerasProfesore> lista = new List<MatriculacionesCarrerasProfesore>();
            try
            {

                var matriculaciones = _dbContex.MatriculacionesCarrerasProfesores.ToList();

                // Usa AutoMapper para mapear la lista de estudiantes a una lista de EstudiantesDto
                lista = _mapper.Map<List<MatriculacionesCarrerasProfesore>>(matriculaciones);


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
        [Route("GuardarMatriculacionCarreraProfesor")]
        public IActionResult GuardarMatriculacionCarreraProfesor([FromBody] MatriCarreProfesorDto objetoDto)
        {
            try
            {

                var objeto = _mapper.Map<MatriculacionesCarrerasProfesore>(objetoDto);
                _dbContex.MatriculacionesCarrerasProfesores.Add(objeto);
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
