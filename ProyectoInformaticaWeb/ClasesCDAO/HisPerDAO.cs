using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProyectoInformaticaWeb.ClasesCDAO;

namespace ProyectoInformaticaWeb.DAOs
{
    public class HistorialPerDAO
    {
        public static void InsertarHistorial(int idAlumno, string evento, int puertaId, int usuarioId, string objetos, DateTime fecha)
        {
            using (SqlConnection cn = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("sp_insert_his_per", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_alumno", idAlumno);
                cmd.Parameters.AddWithValue("@evento", evento);
                cmd.Parameters.AddWithValue("@puerta_id", puertaId);
                cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                cmd.Parameters.AddWithValue("@objetos", objetos ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ListarHistorial()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM his_per ORDER BY fecha DESC", cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable BuscarPorIdAlumno(int idAlumno)
        {
            using (SqlConnection con = Conexiones.Conectar())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM his_per WHERE id_alumno = @idAlumno", con);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }



    }
}
