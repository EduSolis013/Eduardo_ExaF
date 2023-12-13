namespace Eduardo_EF_API.Models;

public class ClienteModels
{
    public int id_cliente { get; set; }
    
    public string estado { get; set;  }
    
    public int id_persona { get; set; }

    public string calificacion { get; set; }
    
    public DateTime fecha_ingreso { get; set; }
    
}