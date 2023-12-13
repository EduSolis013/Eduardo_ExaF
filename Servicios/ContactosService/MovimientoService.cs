using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactosService;

public class MovimientoService {
    MovimientoDatos movimientoDatos;


    
    public void agregarMovimiento(MovimientoModel movimiento) {
        movimientoDatos.agregarMovimiento(movimiento);
    }
    
    public MovimientoService(string cadenaConexion) {
        movimientoDatos = new MovimientoDatos(cadenaConexion);
    }
    
    public void alterarMovimiento(MovimientoModel movimiento) {
        movimientoDatos.alterarMovimiento(movimiento);
    } 
    
    public MovimientoModel quitarMovimiento(int id) {
        return movimientoDatos.quitarMovimiento(id);
    }
    
    public MovimientoModel obtenerMovimiento(int id) {
        return movimientoDatos.obtenerMovimiento(id);
    }
    
   
}