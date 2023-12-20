using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisacadFinal.Models;
using SisacadFinal.Models.Dto;

namespace SisacadFinal.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        public readonly FinalmuContext _dbContex;
        private readonly IMapper _mapper;

        public ProfesoresController(FinalmuContext _context, IMapper mapper)
        {
            _dbContex = _context ?? throw new ArgumentNullException();
            _mapper = mapper;

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("ListaP")]
        public IActionResult ListaP()
        {
            List<ProfesoresDto> li = new List<ProfesoresDto>();
            try
            {
                var profesores=_dbContex.Profesores.ToList();
                li=_mapper.Map<List<ProfesoresDto>>(profesores);
                return StatusCode(StatusCodes.Status200OK, new {message="ok",response=li});
            }catch(Exception ex) 
            { 
            return BadRequest(ex.Message);
            }


        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("ObtenerProfesor/{id:int}")]
        public IActionResult GetP(int id) 
        {
            
           
                Profesore oProfesor= _dbContex.Profesores.Find(id);
            if (oProfesor == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new {message="Profesor no encontrado"});
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = oProfesor });


            }catch(Exception ex) {

                return BadRequest(ex);
            }
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Route("GuardarProfesor")]
        public IActionResult GuardarProfesor([FromBody] ProfesoresDto objetoDto)
        {
            try
            {

                var objeto = _mapper.Map<Profesore>(objetoDto);
                _dbContex.Profesores.Add(objeto);
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


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("EditarProfesor")]
        public IActionResult EditarProfesor([FromBody] Profesore objeto)
        {



            Profesore oProfesor = _dbContex.Profesores.Find(objeto.Id);
            if (oProfesor == null)
            {
                return BadRequest("Profesor no encontrado");
            }



            try
            {
                oProfesor.Apellido = objeto.Apellido is null ? oProfesor.Apellido : objeto.Apellido;
                oProfesor.Contrasena = objeto.Contrasena is null ? oProfesor.Contrasena : objeto.Contrasena;
                oProfesor.Correo = objeto.Correo is null ? oProfesor.Correo : objeto.Correo;
                oProfesor.Dni = objeto.Dni is null ? oProfesor.Dni : objeto.Dni;
                oProfesor.Nombre = objeto.Nombre is null ? oProfesor.Nombre : objeto.Nombre;
                oProfesor.FechaCreacion = objeto.FechaCreacion is null ? oProfesor.FechaCreacion : objeto.FechaCreacion;




                _dbContex.Profesores.Update(oProfesor);
                _dbContex.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha actualizado el profesor" });


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
        public IActionResult EliminarProfesor(int Id)
        {


            Profesore  oProfesor= _dbContex.Profesores.Find(Id);
            if (oProfesor == null)
            {
                return BadRequest("Profesor no encontrado");
            }


            try
            {


                _dbContex.Profesores.Remove(oProfesor);
                _dbContex.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha eliminado el Profesor" });


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message });

            }


        }








    }
}
