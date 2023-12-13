using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosService;

namespace Eduardo_EF_API.Controllers;

[ApiController]
[Route("[controller]")]

public class CiudadController : ControllerBase {
    
    private const string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=0000;Database=ParcialDB;";
    private CiudadService servicio;

    public CiudadController() {
        servicio = new CiudadService(connectionString);
    }

    [HttpGet("{id}")]
    public IActionResult obtenerCiudad([FromQuery] int id) {
        var ciudad = servicio.obtenerCiudad(id);
        return Ok(ciudad);
    }
    
    [HttpPost]
    public IActionResult AgreCiudad([FromBody] Infraestructura.Modelos.CiudadModel ciudad) {
        servicio.AgreCiudad(ciudad);
        return Created("", ciudad);
    }
    
    [HttpDelete("{id}")]
    public IActionResult BorrarCiudad(int id)
    {
        return Ok(servicio.BorrarCiudad(id));
    }
    /*
    [HttpPut]
    public IActionResult alterarCiudad([FromBody] Infraestructura.Modelos.CiudadModel ciudad) {
        try {
            servicio.alterarCiudad(ciudad);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
            throw;
        }
        return Ok();
    }*/

    
    [HttpGet]
    public IActionResult ListaCiudades()
    {
        return Ok(servicio.ListaCiudades());
    }

}