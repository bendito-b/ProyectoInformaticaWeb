using Proyecto.Modelos;
using ProyectoInformaticaWeb.ClasesCDAO; 
using System;
using System.Collections.Generic; 
using System.Data;
using System.Data.SqlClient; 

namespace Proyecto.Datos 
{
    public class AlumnoDAO
    {

        public AlumnoDAO()
        {
            // Constructor
        }

        public List<Alumno> ObtenerAlumnos()
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            // Usamos Conexiones.Conectar() para obtener la conexión
            using (SqlConnection connection = Conexiones.Conectar())
            {
                using (SqlCommand command = new SqlCommand("usp_ObtenerAlumno", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {

                        SqlDataReader reader = command.ExecuteReader();

                        // Leemos los datos del SqlDataReader y creamos objetos Alumno
                        while (reader.Read())
                        {
                            Alumno alumno = new Alumno();
                            // Asegúrate de que los nombres de las columnas coincidan con los del SP
                            alumno.id_alumno = Convert.ToInt32(reader["id_alumno"]);
                            alumno.dni = reader["dni"].ToString();
                            alumno.nombres = reader["nombres"].ToString();
                            alumno.apellidos = reader["apellidos"].ToString();
                            alumno.carrera = reader["carrera"].ToString();
                            alumno.facultad = reader["facultad"].ToString();
                            alumno.estado = reader["estado"].ToString();

                            listaAlumnos.Add(alumno);
                        }
                        reader.Close(); // Cierra el lector de datos
                    }
                    catch (SqlException ex)
                    {
                        // Manejo de errores de SQL
                        Console.WriteLine($"Error de SQL al obtener alumnos: {ex.Message}");
                        throw; // Vuelve a lanzar la excepción
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        Console.WriteLine($"Error general al obtener alumnos: {ex.Message}");
                        throw;
                    }
                }
            } // La conexión se cierra automáticamente al salir del bloque 'using'
            return listaAlumnos;
        }
    }
}
