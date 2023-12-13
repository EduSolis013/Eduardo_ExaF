using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosService;

namespace Eduardo_EF_API.Controllers;
[ApiController]
[Route("[controller]")]
public class PersonaController : Controller {
    
    private PersonaService personaServicio;

    public PersonaController()
    {
        personaServicio = new PersonaService("Server=localhost;Port=5432;User Id=postgres;Password=0000;Database=ParcialDB;");
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(personaServicio.obtenerPersona(id));
    }
    
 
    
    [HttpPut]
    public IActionResult alterarPersona([FromBody] Infraestructura.Modelos.PersonaModel modelo) {
        try {
            personaServicio.alterarPersona(modelo);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
            throw;
        }
        return Ok();
    }
    
    [HttpGet]
    public IActionResult ListaPersonsa()
    {
        return Ok(personaServicio.ListaPersonsa());
    }
    
    [HttpDelete("{id}")]
    public IActionResult quitarPersona(int id)
    {
        return Ok(personaServicio.quitarPersona(id));
    }
    
    
    [HttpPost]
    public IActionResult agregarPersona([FromBody] Models.PersonaModels modelo)
    {
        personaServicio.agregarPersona(
            new Infraestructura.Modelos.PersonaModel
            {
                nombre = modelo.nombre,
                apellido = modelo.apellido,
                nro_documento = modelo.nro_documento,
                direccion = modelo.direccion,
                email = modelo.email,
                celular = modelo.celular,
                estado = modelo.estado,
                ciudad  = new Infraestructura.Modelos.CiudadModel
                {
                    id_ciudad = modelo.id_ciudad
                }
            });
        return Ok();
    } 


}