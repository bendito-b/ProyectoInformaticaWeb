using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace ProyectoInformaticaWeb.ClasesCDAO
{
    public class SupervisorDAO
    {
        // Obtener todos los supervisores
        public static DataTable CargarDatosSupervisor()
        {
            using (SqlConnection connection = Conexiones.Conectar())
            {
                using (SqlCommand command = new SqlCommand("usp_ObtenerSupervisor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        // Insertar un nuevo supervisor
        public static void InsertarSupervisor(string nombre, string correo, int estacionId, string estado)
        {
            using (SqlConnection connection = Conexiones.Conectar())
            {
                using (SqlCommand command = new SqlCommand("usp_InsertarSupervisor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@estacion_id", estacionId);
                    command.Parameters.AddWithValue("@estado", estado);

                    
                    command.ExecuteNonQuery();
                }
            }
        }

        // Actualizar un supervisor existente
        public static void ActualizarSupervisor(int idSupervisor, string nombre, string correo, int estacionId, string estado)
        {
            using (SqlConnection connection = Conexiones.Conectar())
            {
                using (SqlCommand command = new SqlCommand("usp_ActualizarSupervisor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_supervisor", idSupervisor);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@estacion_id", estacionId);
                    command.Parameters.AddWithValue("@estado", estado);

                    
                    command.ExecuteNonQuery();
                }
            }
        }

        // Cambiar el estado de un supervisor (activo/inactivo)
        public static void CambiarEstadoSupervisor(int idSupervisor, string nuevoEstado)
        {
            using (SqlConnection connection = Conexiones.Conectar())
            {
                using (SqlCommand command = new SqlCommand("usp_cambiarEstadoSupervisor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_supervisor", idSupervisor);
                    command.Parameters.AddWithValue("@nuevo_estado", nuevoEstado);

                    
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
