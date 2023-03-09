using System.Data.SqlClient;
using Entity;

namespace Datos;
public class MiembroRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Miembro> _miembros = new List<Miembro>();
        public MiembroRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Miembro miembro)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Miembro (Identificacion,Nombre,Sexo,FechaNacimiento, Direccion, Telefono) 
                                        values (@Identificacion,@Nombre,@Sexo,@FechaNacimiento,@Direccion,@Telefono)";
                command.Parameters.AddWithValue("@Identificacion", miembro.Identificacion);
                command.Parameters.AddWithValue("@Nombre", miembro.Nombre);
                command.Parameters.AddWithValue("@Sexo", miembro.Sexo);
                command.Parameters.AddWithValue("@FechaNacimiento", miembro.FechaNacimiento);
                command.Parameters.AddWithValue("@Direccion", miembro.Direccion);
                command.Parameters.AddWithValue("@Telefono", miembro.Telefono);
                var filas = command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Miembro miembro)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from miebro where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", miembro.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public List<Miembro> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Miembro> miembros = new List<Miembro>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from miembro ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Miembro miembro = DataReaderMapToMiembro(dataReader);
                        miembros.Add(miembro);
                    }
                }
            }
            return miembros;
        }
        public Miembro BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from miembro where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToMiembro(dataReader);
            }
        }
        private Miembro DataReaderMapToMiembro(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Miembro miembro = new Miembro();
            miembro.Identificacion = (string)dataReader["Identificacion"];
            miembro.Nombre = (string)dataReader["Nombre"];
            miembro.Sexo = (string)dataReader["Sexo"];
            miembro.FechaNacimiento = (DateTime)dataReader["FechaNacimiento"];
            return miembro;
        }
        public int Totalizar()
        {
            return _miembros.Count();
        }
        public int TotalizarMujeres()
        {
            ConsultarTodos();
            return _miembros.Where(p => p.Sexo.Equals("Femenino")).Count();
        }
        public int TotalizarHombres()
        {
            ConsultarTodos();
            return _miembros.Where(p => p.Sexo.Equals("Masculino")).Count();
        }
    }
