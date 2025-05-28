using System;
using System.Configuration; // Añadido para ConfigurationManager (si Conexiones.Conectar no lo usa internamente)
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoInformaticaWeb.ClasesCDAO; // Asegúrate de que esta referencia sea correcta

namespace ProyectoInformaticaWeb
{
    public partial class Incidencias : System.Web.UI.Page
    {
        // Ya no necesitamos la cadena de conexión aquí si Conexiones.Conectar() la maneja.
        // string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

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
                return;
            }

            if (!IsPostBack)
            {
                CargarIncidencias();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string tipo = txtTipo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(descripcion))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Complete todos los campos.";
                return;
            }

            using (SqlConnection conexion = Conexiones.Conectar()) // Usando tu clase Conexiones
            using (SqlCommand cmd = new SqlCommand("usp_InsertarIncidencia", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipo_incidencia", tipo);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                // El estado se establece en 1 por defecto en el procedimiento almacenado

                cmd.ExecuteNonQuery();
            }

            lblMensaje.ForeColor = System.Drawing.Color.Green;
            lblMensaje.Text = "Incidencia registrada correctamente.";

            txtTipo.Text = "";
            txtDescripcion.Text = "";
            CargarIncidencias();
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("~Report/ReporteIncidencias.aspx");
        }

        private void CargarIncidencias()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = Conexiones.Conectar()) // Usando tu clase Conexiones
            using (SqlCommand cmd = new SqlCommand("usp_ObtenerIncidencias", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(tabla);
            }

            gvIncidencias.DataSource = tabla;
            gvIncidencias.DataBind();
        }

        protected void gvIncidencias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvIncidencias.DataKeys[e.RowIndex].Value);
            using (SqlConnection conexion = Conexiones.Conectar()) // Usando tu clase Conexiones
            using (SqlCommand cmd = new SqlCommand("usp_EliminarIncidencia", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_incidencia", id);
                cmd.ExecuteNonQuery();
            }
            CargarIncidencias();
        }

        protected void gvIncidencias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvIncidencias.EditIndex = e.NewEditIndex;
            CargarIncidencias();
        }

        protected void gvIncidencias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvIncidencias.EditIndex = -1;
            CargarIncidencias();
        }

        protected void gvIncidencias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvIncidencias.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvIncidencias.Rows[e.RowIndex];

            string tipo = ((TextBox)row.FindControl("txtEditTipo")).Text; // Usa FindControl para buscar por ID
            string desc = ((TextBox)row.FindControl("txtEditDescripcion")).Text; // Usa FindControl para buscar por ID
            bool estado = ((CheckBox)row.FindControl("chkEstadoEdit")).Checked; // Obtener el estado del CheckBox

            using (SqlConnection conexion = Conexiones.Conectar()) // Usando tu clase Conexiones
            using (SqlCommand cmd = new SqlCommand("usp_ActualizarIncidencia", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_incidencia", id);
                cmd.Parameters.AddWithValue("@tipo_incidencia", tipo);
                cmd.Parameters.AddWithValue("@descripcion", desc);
                cmd.Parameters.AddWithValue("@estado", estado); // Pasa el nuevo estado
                cmd.ExecuteNonQuery();
            }

            gvIncidencias.EditIndex = -1;
            CargarIncidencias();
        }

        // --- NUEVOS MÉTODOS PARA HABILITAR/DESHABILITAR ---

        protected void ActualizarEstadoIncidencia(int idIncidencia, bool nuevoEstado)
        {
            using (SqlConnection conexion = Conexiones.Conectar()) // Usando tu clase Conexiones
            using (SqlCommand cmd = new SqlCommand("usp_ActualizarEstadoIncidencia", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);
                cmd.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = $"Incidencia {(nuevoEstado ? "habilitada" : "deshabilitada")} correctamente.";
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = $"Error al {(nuevoEstado ? "habilitar" : "deshabilitar")} la incidencia.";
                }
            }
            CargarIncidencias(); // Recargar el GridView para reflejar el cambio
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (gvIncidencias.SelectedDataKey != null)
            {
                int idIncidencia = Convert.ToInt32(gvIncidencias.SelectedDataKey.Value);
                ActualizarEstadoIncidencia(idIncidencia, true); // Pasar 'true' para habilitar
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Por favor, selecciona una incidencia para habilitar.";
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (gvIncidencias.SelectedDataKey != null)
            {
                int idIncidencia = Convert.ToInt32(gvIncidencias.SelectedDataKey.Value);
                ActualizarEstadoIncidencia(idIncidencia, false); // Pasar 'false' para deshabilitar
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Por favor, selecciona una incidencia para deshabilitar.";
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            // ¡IMPORTANTE! Aquí se especifica a qué página regresar.
            // Asegúrate de que "Default1.aspx" sea el nombre correcto de tu página principal.
            Response.Redirect("Default1.aspx");
        }

        protected void gvIncidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este evento es necesario para que SelectedDataKey funcione correctamente.
            // No necesita código dentro, solo la declaración para que el PostBack funcione.
        }
    }
}