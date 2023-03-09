
using System.ComponentModel.DataAnnotations;
using Entity;

namespace God_Church.Models;
 public class MiembroInputModel
    {
        [Required(ErrorMessage = "La identificacion es requerida")]
        public string? Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre es requerida")]

        public string? Nombre { get; set; }

        [Required( ErrorMessage="El Sexo de ser Femenino o Masculino")]
        public string? Sexo { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]

        public DateTime FechaNacimiento { get; set; }

        [Required( ErrorMessage="La direccion es requerida")]

        public string? Direccion { get; set; }

        [Range(5,10,ErrorMessage ="El telefono debe tener de 5 a 10 digitos")]
        public int Telefono { get; set; }
    }

    

    public class MiembroViewModel : MiembroInputModel
    {
        public MiembroViewModel()
        {

        }
        public MiembroViewModel(Miembro miembro)
        {
            Identificacion = miembro.Identificacion;
            Nombre = miembro.Nombre;
            Sexo = miembro.Sexo;
            FechaNacimiento = miembro.FechaNacimiento;
            Direccion = miembro.Direccion;
            Telefono = miembro.Telefono;
            
        }
    }