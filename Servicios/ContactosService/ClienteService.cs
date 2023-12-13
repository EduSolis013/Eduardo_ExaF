using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactosService;

public class ClienteService 
{
    
    ClienteDatos clienteData;

    public ClienteService(string cadenaConexion)
    {
        clienteData = new ClienteDatos(cadenaConexion);
    }
    
    public ClienteModel obtenerCliente(int id) 
    {
        return clienteData.obtenerCliente(id);
    }
    


    public void alterarCliente(ClienteModel cliente) 
    {
        clienteData.alterarCliente(cliente);
    } 
    
    public ClienteModel quitarCliente(int id) 
    {
        return clienteData.quitarCliente(id);
    }
    
    public void AgregarCliente(ClienteModel cliente)
    {
        clienteData.AgregarCliente(cliente);
    }
    
    public List<ClienteModel> ListaClientes()
    {
        return clienteData.ListaClientes();
    }
    
       
  
}