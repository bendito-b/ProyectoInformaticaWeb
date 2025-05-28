using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoInformaticaWeb.ClasesCDAO
{
    public static class PuertasDAO
    {
        // 1. Recuperar todas las puertas
        public static DataTable ObtenerTodas()
        {
            using (SqlConnection con = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_ObtenerPuertas", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Insertar nueva puerta
        public static void Insertar(string ubicacion, int estado)
        {
            using (SqlConnection con = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_InsertarPuerta", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ubicacion", ubicacion);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.ExecuteNonQuery();
            }
        }


        // 3. Actualizar puerta existente
        public static void Actualizar(int id, string ubicacion, int estado)
        {
            using (SqlConnection con = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_ActualizarPuerta", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_puerta", id);
                cmd.Parameters.AddWithValue("@ubicacion", ubicacion);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.ExecuteNonQuery();
            }
        }
        public static void Eliminar(int id)
        {
            using (SqlConnection conexion = Conexiones.Conectar())
            using (SqlCommand comando = new SqlCommand("usp_EliminarPuerta", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_puerta", id);
                comando.ExecuteNonQuery();
            }
        }
        public static DataTable ObtenerPorId(int id)
        {
            using (SqlConnection con = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM puertas WHERE id_puerta = @id", con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void ActualizarEstado(int id, int nuevoEstado)
        {
            using (SqlConnection con = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("UPDATE puertas SET estado = @estado WHERE id_puerta = @id", con))
            {
                cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }


    }




}
