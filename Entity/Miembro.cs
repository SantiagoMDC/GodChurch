using System.ComponentModel.DataAnnotations;

namespace Entity;
public class Miembro
{
    [Key]
    public string Identificacion { get; set; }
    public string Nombre { get; set; }
    public string Sexo { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Direccion { get; set; }
    public int Telefono { get; set; }

}
