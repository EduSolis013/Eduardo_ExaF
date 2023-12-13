using Microsoft.AspNetCore.Mvc;
using Servicios.ContactosService;

namespace Eduardo_EF_API.Controllers;
[ApiController]
[Route("[controller]")]

public class CuentasController : Controller
{
    private CuentasService cuentasService;
    
    public CuentasController()
    {
        cuentasService = new CuentasService("Server=localhost;Port=5432;User Id=postgres;Password=0000;Database=ParcialDB;");
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(cuentasService.obtenerCuenta(id));
    }
    
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(cuentasService.ListaCuentas());
    }
    
    
    [HttpPost]
    public IActionResult agregarCuenta([FromBody] Models.CuentasModels modelo)
    {
        cuentasService.agregarCuenta(
            new Infraestructura.Modelos.CuentasModel()
            {
                nro_cuenta = modelo.nro_cuenta,
                fecha_alta = modelo.fecha_alta,
                tipo_cuenta = modelo.tipo_cuenta,
                estado = modelo.estado,
                saldo = modelo.saldo,
                nro_contrato = modelo.nro_contrato,
                costo_mantenimiento = modelo.costo_mantenimiento,
                promedio_acreditacion = modelo.promedio_acreditacion,
                moneda = modelo.moneda,
                cliente  = new Infraestructura.Modelos.ClienteModel()
                {
                    id_cliente = modelo.id_cliente
                }
            });
        return Ok();
    }
    
    /*
    [HttpPut]
    public IActionResult alterarCuenta([FromBody]  Infraestructura.Modelos.CuentasModel modelo) {
        try {
            cuentasService.alterarCuenta(modelo);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
            throw;
        }
        return Ok();
        
    }*/
    
    
 
    [HttpDelete("{id}")]
    public IActionResult quitarCuenta(int id)
    {
        return Ok(cuentasService.quitarCuenta(id));
    }

}