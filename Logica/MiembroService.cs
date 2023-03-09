using Datos;
using Entity;

namespace Logica;
public class MiembroService
    {
        private readonly ConnectionManager _conexion;
        private readonly MiembroRepository _repositorio;
        public MiembroService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new MiembroRepository(_conexion);
        }
        public GuardarMiembroResponse Guardar(Miembro miembro)
        {
            try
            {
                
                _conexion.Open();
                _repositorio.Guardar(miembro);
                _conexion.Close();
                return new GuardarMiembroResponse(miembro);
            }
            catch (Exception e)
            {
                return new GuardarMiembroResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public List<Miembro> ConsultarTodos()
        {
            _conexion.Open();
            List<Miembro> miembros = _repositorio.ConsultarTodos();
            _conexion.Close();
            return miembros;
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var miembro = _repositorio.BuscarPorIdentificacion(identificacion);
                if (miembro != null)
                {
                    _repositorio.Eliminar(miembro);
                    _conexion.Close();
                    return ($"El registro {miembro.Nombre} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }
        public Miembro BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Miembro miembro = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return miembro;
        }
        public int Totalizar()
        {
            return _repositorio.Totalizar();
        }
        public int TotalizarMujeres()
        {
            return _repositorio.TotalizarMujeres();
        }
        public int TotalizarHombres()
        {
            return _repositorio.TotalizarHombres();
        }
    }

    public class GuardarMiembroResponse 
    {
        public GuardarMiembroResponse(Miembro miembro)
        {
            Error = false;
            Miembro = miembro;
        }
        public GuardarMiembroResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Miembro Miembro { get; set; }
    }