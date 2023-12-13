using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infraestructura.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Servicios.ContactosService;

namespace Eduardo_EF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private const string connectionString = "Server=localhost;Port=5432;UserId=postgres;Password=0000;Database=ParcialDB;";

        private readonly IConfiguration config;
        private UsuarioService UsuarioService;

        public AuthController(IConfiguration configuration)
        {
            config = configuration;
            UsuarioService = new UsuarioService(connectionString);
        }
        
        private object GenerateJWT(UsuarioModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.nombre_usuario),
                new Claim(JwtRegisteredClaimNames.Name, user.persona?.nombre ?? ""),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.persona?.apellido ?? ""),
                new Claim(JwtRegisteredClaimNames.Email, user.persona?.email ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(320),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] LoginModel login)
        {
            var usuario = UsuarioService.obtenerUsuario2(login.UserName);
            int intentos = 0;


            if (usuario == null || usuario.contrasena != login.Password)
            {
                intentos++;
                if ( intentos > 3)
                {
                    return Unauthorized("Bloqueado, cominiarse con antencion al cliente");
                }
                return Unauthorized();
            }


            var token = GenerateJWT(usuario);
            return Ok(new { jwt = token });
        }
        
        public class LoginModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        
        private bool ValidUser(LoginModel login)
        {
            var usuario = UsuarioService.obtenerUsuario2(login.UserName);
            return usuario != null && usuario.contrasena == login.Password;
        }
    }
}
