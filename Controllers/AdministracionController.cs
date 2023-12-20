using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisacadFinal.Models.Dto;
using SisacadFinal.Models;
using Microsoft.AspNetCore.Cors;

namespace SisacadFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReglasCors")]
    public class AdministracionController : ControllerBase
    {
        public readonly FinalmuContext _dbContex;
        private readonly IMapper _mapper;

        public AdministracionController(FinalmuContext _context, IMapper mapper)
        {
            _dbContex = _context ?? throw new ArgumentNullException();
            _mapper = mapper;

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("ListaAdm")]
        public IActionResult ListaP()
        {
            List<AdministracionDto> li = new List<AdministracionDto>();
            try
            {


                var administradores = _dbContex.Administracions.ToList();
                li = _mapper.Map<List<AdministracionDto>>(administradores);
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = li });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [Route("Obtener/{IdAdmin:int}")]
        public IActionResult Obtener(int IdAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                Administracion oAdmin = _dbContex.Administracions.Find(IdAdmin);
                if (oAdmin == null)
                {
                    return BadRequest("Adminstrador no encontrado");
                }


                try
                {
                    var adminDto = _mapper.Map<AdministracionDto>(oAdmin);
                    return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = adminDto });

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ex.Message,});
                }
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Route("GuardarAdmin")]
        public IActionResult GuardarAdmin([FromBody] AdministracionDto objetoDto)
        {
            try
            {

                var objeto = _mapper.Map<Administracion>(objetoDto);
                _dbContex.Administracions.Add(objeto);
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
        [Route("EditarAdmin")]
        public IActionResult EditarProfesor([FromBody] Administracion objeto)
        {



            Administracion oAdmin = _dbContex.Administracions.Find(objeto.Id);
            if (oAdmin == null)
            {
                return BadRequest("Administrador no encontrado");
            }



            try
            {
                oAdmin.Apellido = objeto.Apellido is null ? oAdmin.Apellido : objeto.Apellido;
                oAdmin.Contrasena = objeto.Contrasena is null ? oAdmin.Contrasena : objeto.Contrasena;
                oAdmin.Correo = objeto.Correo is null ? oAdmin.Correo : objeto.Correo;
                oAdmin.Dni = objeto.Dni is null ? oAdmin.Dni : objeto.Dni;
                oAdmin.Nombre = objeto.Nombre is null ? oAdmin.Nombre : objeto.Nombre;
                oAdmin.FechaCreacion = objeto.FechaCreacion is null ? oAdmin.FechaCreacion : objeto.FechaCreacion;




                _dbContex.Administracions.Update(oAdmin);
                _dbContex.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha actualizado el Administrador" });


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
        public IActionResult EliminarAdmin(int Id)
        {


            Administracion oAdmin = _dbContex.Administracions.Find(Id);
            if (oAdmin == null)
            {
                return BadRequest("Profesor no encontrado");
            }


            try
            {


                _dbContex.Administracions.Remove(oAdmin);
                _dbContex.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { message = "Se ha eliminado el Adminstrador" });


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message });

            }


        }




    }
}
