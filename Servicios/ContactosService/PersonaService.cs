using Infraestructura.Datos;
using Infraestructura.Modelos;


namespace Servicios.ContactosService;

public class PersonaService 
{
    
    PersonaDatos personaData;
    
    

    
  
    
    public void alterarPersona(PersonaModel persona) 
    {
        personaData.alterarPersona(persona);
    } 
    
    public List<PersonaModel> ListaPersonsa()
    {
        return personaData.ListaPersonsa();
    }
    
    public PersonaService(string cadenaConexion) 
    {
        personaData = new PersonaDatos(cadenaConexion);
    }
    
    public PersonaModel quitarPersona(int id) 
    {
        return personaData.quitarPersona(id);
    }
    
    public PersonaModel obtenerPersona(int id)
    {
        return personaData.obtenerPersona(id);
    }
    
    public void agregarPersona(PersonaModel persona)
    {
        personaData.agregarPersona(persona);
    }
    

    
}