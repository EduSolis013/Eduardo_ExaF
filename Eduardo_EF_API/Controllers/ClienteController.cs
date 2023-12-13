using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosService;


namespace Eduardo_EF_API.Controllers;
[ApiController]
[Route("[controller]")]

public class ClienteController : Controller
{
    private ClienteService clienteServicio;
    
    public ClienteController()
    {
        clienteServicio = new ClienteService("Server=localhost;Port=5432;User Id=postgres;Password=0000;Database=ParcialDB;");
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(clienteServicio.obtenerCliente(id));
    }
    
    
    [HttpPost]
    public IActionResult AgregarCliente([FromBody] Models.ClienteModels modelo)
    {
        clienteServicio.AgregarCliente(
            new Infraestructura.Modelos.ClienteModel()
            {
                fecha_ingreso = modelo.fecha_ingreso,
                calificacion = modelo.calificacion,
                estado = modelo.estado,
                persona  = new Infraestructura.Modelos.PersonaModel()
                {
                    id_persona = modelo.id_persona
                }
            });
        return Ok();
    }   
    /*
    [HttpPut]
    public IActionResult alterarCliente([FromBody] Infraestructura.Modelos.ClienteModel modelo) {
        try {
            clienteServicio.alterarCliente(modelo);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
            throw;
        }
        return Ok();
    }*/

    
    [HttpDelete("{id}")]
    public IActionResult quitarCliente(int id)
    {
        return Ok(clienteServicio.quitarCliente(id));
    }
    
    [HttpGet]
    public IActionResult ListaClientes()
    {
        return Ok(clienteServicio.ListaClientes());
    }
}