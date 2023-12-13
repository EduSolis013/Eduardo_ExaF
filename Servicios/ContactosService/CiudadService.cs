using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactosService;

public class CiudadService 
{
    
    CiudadDatos ciudadData;
    
    public void alterarCiudad(CiudadModel ciudad) 
    {
        ciudadData.alterarCiudad(ciudad);
    }  
    
    public List<CiudadModel> ListaCiudades()
    {
        return ciudadData.ListaCiudades();
    }
    
    public CiudadModel BorrarCiudad(int id) 
    {
        return ciudadData.BorrarCiudad(id);
    }
    
    public CiudadService(string cadenaConexion) 
    {
        ciudadData = new CiudadDatos(cadenaConexion);
    }


    
    public CiudadModel obtenerCiudad(int id) 
    {
        return ciudadData.obtenerCiudad(id);
    }
    
    public void AgreCiudad(CiudadModel ciudad) {
        ciudadData.AgreCiudad(ciudad);
    }
    

    
}