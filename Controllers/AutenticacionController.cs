using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisacadFinal.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;



namespace SisacadFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly string secreckey;
        public AutenticacionController(IConfiguration config)
        {
            secreckey = config.GetSection("settings").GetSection("secreckey").ToString();
        }

        [HttpPost]
        [Route("Validar")]
        public IActionResult Validar([FromBody] UsuarioKey request)
        {
            //este if se debe hacer desde una tabla
            if (request.correo == "c@gmail.com" && request.clave == "123")
            {
                var KeyBytes = Encoding.ASCII.GetBytes(secreckey);
                //clains son solicitudes
                var clains = new ClaimsIdentity();
                //ClaimsIdentity es un objeto descrito por reclamaciones
                //son solicitudes de permisos
                clains.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.correo));
                //voy a agregarle un identificador clains 
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = clains,
                    //a la propiedad subjet le agrego la reclamaciones  insertadas en clains
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyBytes), SecurityAlgorithms.HmacSha256Signature)
                    //firmo las credencianles con KeyBytes


                };
                var tokenHandler = new JwtSecurityTokenHandler();
                /// JwtSecurityTokenHandler esta clase crea y valida el token
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                //aqui crea el token con todas la propiedades en tokenDescriptor
                var tokenCreated = tokenHandler.WriteToken(tokenConfig);
                //aqui lo serializa

                return StatusCode(StatusCodes.Status200OK, new
                {
                    token = tokenCreated
                });


            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    token = ""
                });
            }
        }

    }
}
