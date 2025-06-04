using System;
using System.Collections.Generic; // Necessary for List<T>
using System.Data;
using System.Data.SqlClient; // Necessary for interacting with SQL Server
using ProyectoInformaticaWeb.ClasesCDAO; // Import the namespace of your Conexiones class
using Proyecto.Modelos; // Import the namespace of your Alumno model

namespace Proyecto.Datos // Ensure this namespace matches your project's if different
{
    public class AlumnoDAO
    {
        // No need for a connection string here, it will be obtained from the Conexiones class

        public AlumnoDAO()
        {
            // Constructor
        }

        /// <summary>
        /// Gets a list of Alumno objects from the database using the usp_ObtenerAlumno stored procedure.
        /// </summary>

        /// <returns>A list of Alumno objects.</returns>
        public List<Alumno> ObtenerAlumnos(string nombres , string apellidos )
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            // Use Conexiones.Conectar() to get the connection
            using (SqlConnection connection = Conexiones.Conectar())
            {
                using (SqlCommand command = new SqlCommand("usp_ObtenerAlumno", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    // If the input string is null or empty, send DBNull.Value to the stored procedure
                    command.Parameters.AddWithValue("@Nombres", string.IsNullOrEmpty(nombres) ? (object)DBNull.Value : nombres);
                    command.Parameters.AddWithValue("@Apellidos", string.IsNullOrEmpty(apellidos) ? (object)DBNull.Value : apellidos);

                    try
                    {
                        // The connection is already opened in Conexiones.Conectar(),
                        // so no need to call connection.Open() here.

                        SqlDataReader reader = command.ExecuteReader();

                        // Read data from SqlDataReader and create Alumno objects
                        while (reader.Read())
                        {
                            Alumno alumno = new Alumno();
                            // Ensure column names match those in the stored procedure
                            alumno.id_alumno = Convert.ToInt32(reader["id_alumno"]);
                            alumno.dni = reader["dni"].ToString();
                            alumno.nombres = reader["nombres"].ToString();
                            alumno.apellidos = reader["apellidos"].ToString();
                            alumno.carrera = reader["carrera"].ToString();
                            alumno.facultad = reader["facultad"].ToString();
                            alumno.estado = reader["estado"].ToString();

                            listaAlumnos.Add(alumno);
                        }
                        reader.Close(); // Close the data reader
                    }
                    catch (SqlException ex)
                    {
                        // SQL error handling
                        Console.WriteLine($"SQL error getting students: {ex.Message}");
                        throw; // Re-throw the exception
                    }
                    catch (Exception ex)
                    {
                        // General error handling
                        Console.WriteLine($"General error getting students: {ex.Message}");
                        throw;
                    }
                }
            } // The connection is automatically closed when exiting the 'using' block
            return listaAlumnos;
        }
    }
}
