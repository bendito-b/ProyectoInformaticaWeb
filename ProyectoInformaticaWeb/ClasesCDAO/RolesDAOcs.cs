using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoInformaticaWeb.ClasesCDAO
{
    public class RolesDAOcs
    {
        public static DataTable ObtenerTodas()
        {
            using (SqlConnection con = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_ObtenerRoles", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static void InsertarRol(string nombre, string estado)
        {
            using (SqlConnection conn = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_InsertarRol", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ObtenerRoles()
        {
            using (SqlConnection conn = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_ObtenerRoles", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static void ActualizarRol(int idRol, string nuevoNombre)
        {
            using (SqlConnection conn = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_ActualizarRol", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_rol", idRol);
                cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
                cmd.ExecuteNonQuery();
            }
        }

        public static void CambiarEstadoRol(int idRol, string nuevoEstado)
        {
            using (SqlConnection conn = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_CambiarEstadoRol", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_rol", idRol);
                cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
