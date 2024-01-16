using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisacadFinal.Models;
using Microsoft.AspNetCore.Cors;
using SisacadFinal.Models.Dto;
using AutoMapper;

namespace SisacadFinal.Controllers
{

    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        public readonly FinalmuContext _dbContex;
        private readonly IMapper _mapper;


        public EstudiantesController(FinalmuContext _context, IMapper mapper)
        {
            // _dbContex = _context;
            _dbContex = _context ?? throw new ArgumentNullException();
            _mapper = mapper;
        }


        // GET: api/Materias
      

        // GET: api/Materias
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<string>>> GetNombresMaterias(int id)
        {
            var nombresMaterias = await _dbContex.Matriculaciones
                .Where(m => m.EstudianteId == id)
                .Select(m => m.Materia.Nombre)
                .ToListAsync();

            if (nombresMaterias == null)
            {
                return NotFound();
            }

            return nombresMaterias;
        }







        [HttpGet]
        [ProducesResponseType(200)]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<EstudiantesDto> lista = new List<EstudiantesDto>();
            try
            {

                var estudiantes = _dbContex.Estudiantes.ToList();

                // Usa AutoMapper para mapear la lista de estudiantes a una lista de EstudiantesDto
                lista = _mapper.Map<List<EstudiantesDto>>(estudiantes);


                // lista = _dbContex.EstudiantesDto.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message, response = lista });
            }

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [Route("Obtener/{IdEstudiante:int}")]
        public IActionResult Obtener(int IdEstudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else { 
            Estudiante oEstudiante = _dbContex.Estudiantes.Find(IdEstudiante);
            if (oEstudiante == null)
            {
                return BadRequest("Estudiante no encontrado");
            }


            try
            {

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = oEstudiante });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message, response = oEstudiante });
            }
        }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [Route("GuardarEstudiante")]
        public IActionResult GuardarEstudiante([FromBody]Estudiante objeto)
        {
            try
            {
                _dbContex.Estudiantes.Add(objeto);
            _dbContex.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });


            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message});

            }

        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("EditarEstudiante")]
        public IActionResult EditarEstudiante([FromBody] Estudiante objeto)
        {
        //    if (objeto.Id == 0)
        //    {
        //        return BadRequest("El id debe ser mayor a 0");
        //    }


            
                Estudiante oEstudiante = _dbContex.Estudiantes.Find(objeto.Id);
                if (oEstudiante == null)
                {
                    return BadRequest("Estudiante no encontrado");
                }
            


            try
            {
                oEstudiante.Apellido=objeto.Apellido is null? oEstudiante.Apellido:objeto.Apellido;
                oEstudiante.Contrasena = objeto.Contrasena is null ? oEstudiante.Contrasena : objeto.Contrasena;
                oEstudiante.Correo = objeto.Correo is null ? oEstudiante.Correo : objeto.Correo;
                oEstudiante.Dni = objeto.Dni is null ? oEstudiante.Dni : objeto.Dni;
                oEstudiante.Nombre = objeto.Nombre is null ? oEstudiante.Nombre : objeto.Nombre;
                oEstudiante.FechaCreacion = objeto.FechaCreacion is null ? oEstudiante.FechaCreacion : objeto.FechaCreacion;




                _dbContex.Estudiantes.Update(oEstudiante);
                _dbContex.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha actualizado el estudiante" });


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message });

            }

        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [Route("Eliminar/{Id:int}")]
        public IActionResult EliminarEstudiante(int Id)
        {


            Estudiante oEstudiante = _dbContex.Estudiantes.Find(Id);
            if (oEstudiante == null)
            {
                return BadRequest("Estudiante no encontrado");
            }


            try
            {
             

                _dbContex.Estudiantes.Remove(oEstudiante);
                _dbContex.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha eliminado el estudiante" });


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message });

            }


        }





    }
}
