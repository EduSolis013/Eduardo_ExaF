using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactosService;

public class UsuarioService
{
    UsuarioDatos usuarioData;
    

    
    public UsuarioService(string cadenaConexion) {
        usuarioData = new UsuarioDatos(cadenaConexion);
    }
    

    public void alterarUsuario(UsuarioModel usuario)
    {
        usuarioData.alterarUsuario(usuario);
    }  

    public UsuarioModel obtenerUsuario2(string username)
    {
        return usuarioData.obtenerUsuario2(username);
    }
    
    public UsuarioModel quitarUsuario(int id) {
        return usuarioData.quitarUsuario(id);
    }
    
    public UsuarioModel obtenerUsuario(int id)
    {
        return usuarioData.obtenerUsuario(id);
    }

    public List<UsuarioModel> ListaUsuario()
    {
        return usuarioData.ListaUsuario();
    }
    
    public void agregarUsuario(UsuarioModel usuario)
    {
        usuarioData.agregarUsuario(usuario);
    }
    
}