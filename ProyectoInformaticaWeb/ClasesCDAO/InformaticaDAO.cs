using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProyectoInformaticaWeb.ClasesCDAO
{
    public class InformaticaDAO
    {

        public static DataTable InicioSesion(string usuario, string contraseña, string llave)
        {
            using (SqlConnection connection = Conexiones.Conectar())
            {
                using (SqlCommand command = new SqlCommand("SP_ValidarUsuario", connection))
                {
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Usuario", SqlDbType.VarChar, 30).Value = usuario;
                    command.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 30).Value = contraseña;
                    command.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = llave;


                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public static string VerificarInicioSesion(string usuario, string clave)
        {
            using (SqlConnection connection = Conexiones.Conectar())
            {
                using (SqlCommand oComando = new SqlCommand("usp_VerificarInicioSesion", connection))
                {
                    oComando.CommandTimeout = 0;
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@usuario", SqlDbType.VarChar, 11).Value = usuario;
                    oComando.Parameters.Add("@clave", SqlDbType.VarChar, 15).Value = clave;

                    object result = oComando.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }
        public static void CambiarEstadoRol(int idRol, string nuevoEstado)
        {
            using (SqlConnection con = Conexiones.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("usp_CambiarEstadoRol", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_rol", idRol);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void ActualizarEstadoRol(int idRol, string nuevoEstado)
        {
            using (SqlConnection con = Conexiones.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("sp_CambiarEstadoRol", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_rol", idRol);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static bool VerificarSesion(string usuario, string clave)
        {
            using (SqlConnection con = Conexiones.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("usp_VerificarSesion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave", clave);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}