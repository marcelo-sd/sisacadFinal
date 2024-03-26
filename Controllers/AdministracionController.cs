using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisacadFinal.Models.Dto;
using SisacadFinal.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace SisacadFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReglasCors")]
    public class AdministracionController : ControllerBase
    {
        public readonly FinalmuContext _dbContex;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public AdministracionController(FinalmuContext _context, IMapper mapper,IDistributedCache cache)
        {
            _dbContex = _context ?? throw new ArgumentNullException();
            _mapper = mapper;
            _cache = cache;

        }


        //enn esta consulata vamos a implementar cache
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("ListaAdm")]
        public async Task<IActionResult> ListaP()
        //task es una clase, que reprecenta una operacion asincrona, Tasl<T> es su tipo generico, recordar que si no devuelve nada solo podes usar Task
        //IActionResult es una interfaz que representa el resultado de una operacion,Puede ser cualquier cosa que implemente IActionResult, como ViewResult, JsonResult, ContentResult, etc.
        { 
            string? respuesta = await _cache.GetStringAsync("MiClave");
        
            // Mueve la declaración de la lista fuera del bloque if
            List<AdministracionDto> li = new List<AdministracionDto>();
            //bloque if para verificar si "respuesta" tiene algun valor
            if (respuesta == null)
            {

               
                try
                {


                 
                    var administradores =await _dbContex.Administracions.ToListAsync();
                    respuesta = JsonConvert.SerializeObject(administradores);
                    // Convierte tu lista a un string JSON antes de guardarla en el caché
                    await _cache.SetStringAsync("MiClave", respuesta, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                        //aqui configuro  el tiempo que va a durar la respuesta en el cache
                    });
                    //aqui estoy guardando en el cache a administradores con el metodo SetStringAsinc


                    li = _mapper.Map<List<AdministracionDto>>(administradores);
                 
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                li = JsonConvert.DeserializeObject<List<AdministracionDto>>(respuesta);
            }

            return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = li });
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
