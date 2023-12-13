using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactosService;

public class CuentasService 
{
    
    CuentasDatos cuentasData;
    
    public CuentasModel quitarCuenta(int id) 
    {
        return cuentasData.quitarCuenta(id);
    }
    
    public CuentasService(string cadenaConexion) 
    {
        cuentasData = new CuentasDatos(cadenaConexion);
    }
    

    
    public CuentasModel obtenerCuenta(int id) 
    {
        return cuentasData.obtenerCuenta(id);
    }
    

    public void alterarCuenta(CuentasModel cuentas) 
    {
        cuentasData.alterarCuenta(cuentas);
    } 
    
    public void agregarCuenta(CuentasModel cuentas)
    {
        cuentasData.agregarCuenta(cuentas);
    }

    
    public List<CuentasModel> ListaCuentas()
    {
        return cuentasData.ListaCuentas();
    }
    
}