using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ProyectoInformaticaWeb.ClasesCDAO;

namespace ProyectoInformaticaWeb
{
    public partial class Usuario1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["credencial"] == null)
            {
                Response.Redirect("LoginInicial.aspx");
                return;
            }

            string[] partes = Session["credencial"].ToString().Split('|');
            if (partes.Length != 2 || !InformaticaDAO.VerificarSesion(partes[0], partes[1]))
            {
                Session.Clear();
                Response.Redirect("LoginInicial.aspx");
            }
            if (!IsPostBack)
            {
                CargarUsuarios();
                gvUsuarios.RowCommand += gvUsuarios_RowCommand;

            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deshabilitar" || e.CommandName == "Habilitar")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);
                int nuevoEstado = (e.CommandName == "Deshabilitar") ? 0 : 1;

                string connectionString = ConfigurationManager.ConnectionStrings["InformaticaWeb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE usuario1  SET estado = @estado WHERE id_usuario = @id", conn);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.ExecuteNonQuery();
                }

                // Recargar usuarios
                CargarUsuarios();
            }
        }




        private void CambiarEstadoUsuario(int id, int nuevoEstado)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InformaticaWeb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuarios SET estado = @estado WHERE id_usuario = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarUsuarios(); // Refresca la grilla después de cambiar el estado
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default1.aspx");
        }



        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            string rolIdText = txtRolId.Text.Trim();
            string estado = txtEstado.Text.Trim();

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido) &&
                !string.IsNullOrEmpty(telefono) && !string.IsNullOrEmpty(contrasena) &&
                int.TryParse(rolIdText, out int rolId) && !string.IsNullOrEmpty(estado))
            {
                using (SqlConnection conexion = Conexiones.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO usuario1 (nombre, apellido, telefono, contrasena, rol_id, estado) VALUES (@nombre, @apellido, @telefono, @contrasena, @rol_id, @estado)", conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);
                        cmd.Parameters.AddWithValue("@rol_id", rolId);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.ExecuteNonQuery();
                    }
                }

                lblMensaje.Text = "Usuario registrado correctamente.";
                LimpiarCampos();
                CargarUsuarios();
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Complete todos los campos correctamente.";
            }
        }

        private void CargarUsuarios()
        {
            using (SqlConnection conexion = Conexiones.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuario1 ORDER BY id_usuario DESC", conexion))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    gvUsuarios.DataSource = tabla;
                    gvUsuarios.DataBind();
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtContrasena.Text = "";
            txtRolId.Text = "";
            txtEstado.Text = "";
        }
    }
}