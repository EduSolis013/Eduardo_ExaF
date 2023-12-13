using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosService;

namespace Eduardo_EF_API.Controllers;
[ApiController]
[Route("[controller]")]
public class UsuarioController : Controller {
    
    private UsuarioService usuarioService;

    public UsuarioController()
    {
        usuarioService = new UsuarioService("Server=localhost;Port=5432;User Id=postgres;Password=0000;Database=ParcialDB;");
    }
    
    
    [HttpGet()]
    public IActionResult ListaUsuario()
    {
        return Ok(usuarioService.ListaUsuario());
    }
    
    [HttpDelete("{id}")]
    public IActionResult quitarUsuario(int id)
    {
        return Ok(usuarioService.quitarUsuario(id));
    }
    
    [HttpPost()]
    public IActionResult agregarUsuario([FromBody] Models.UsuarioModels modelo)
    {
        usuarioService.agregarUsuario(
            new Infraestructura.Modelos.UsuarioModel()
            {
                nombre_usuario = modelo.nombre_usuario,
                contrasena = modelo.contrasena,
                nivel = modelo.nivel,
                estado = modelo.estado,
                persona  = new Infraestructura.Modelos.PersonaModel()
                {
                    id_persona = modelo.id_persona
                }
            });
        return Ok();
    }
    /*
    [HttpPut()]
    public IActionResult alterarUsuario([FromBody] Infraestructura.Modelos.UsuarioModel modelo) {
        try {
            usuarioService.alterarUsuario(modelo);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
            throw;
        }
        return Ok();
    }*/
    
    [HttpGet("{id}")]
    public IActionResult obtenerUsuario(int id)
    {
        return Ok(usuarioService.obtenerUsuario(id));
    }
    

}