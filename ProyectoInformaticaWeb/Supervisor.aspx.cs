using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ProyectoInformaticaWeb.ClasesCDAO;

namespace ProyectoInformaticaWeb
{
    public partial class Supervisor : System.Web.UI.Page
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
                CargarSupervisores();
        }
        protected void btnReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Report/ReporteSupervisor.aspx");
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string estado = txtEstado.Text.Trim();
            int estacionId;

            if (!string.IsNullOrEmpty(nombre) &&
                !string.IsNullOrEmpty(correo) &&
                !string.IsNullOrEmpty(estado) &&
                int.TryParse(txtEstacionId.Text.Trim(), out estacionId))
            {
                using (SqlConnection conexion = Conexiones.Conectar())
                using (SqlCommand cmd = new SqlCommand("usp_InsertarSupervisor", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@estacion_id", estacionId);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.ExecuteNonQuery();
                }

                lblMensaje.Text = "Supervisor agregado correctamente.";
                txtNombre.Text = txtCorreo.Text = txtEstacionId.Text = txtEstado.Text = "";
                CargarSupervisores();
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Complete todos los campos correctamente.";
            }
        }

        private void CargarSupervisores()
        {
            using (SqlConnection conexion = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("SELECT id_supervisor, nombre, correo, estacion_id, estado FROM supervisor", conexion))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                gvSupervisores.DataSource = tabla;
                gvSupervisores.DataBind();
            }
        }

        protected void gvSupervisores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSupervisores.EditIndex = e.NewEditIndex;
            CargarSupervisores();
        }

        protected void gvSupervisores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSupervisores.EditIndex = -1;
            CargarSupervisores();
        }

        protected void gvSupervisores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvSupervisores.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvSupervisores.DataKeys[e.RowIndex].Value);
            string nombre = ((TextBox)row.FindControl("txtNombreEdit")).Text.Trim();
            string correo = ((TextBox)row.FindControl("txtCorreoEdit")).Text.Trim();
            int estacionId = Convert.ToInt32(((TextBox)row.FindControl("txtEstacionEdit")).Text.Trim());

            using (SqlConnection conn = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_ActualizarSupervisor", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_supervisor", id);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@estacion_id", estacionId);
                cmd.Parameters.AddWithValue("@estado", "Activo"); // o conserva el actual
                cmd.ExecuteNonQuery();
            }

            gvSupervisores.EditIndex = -1;
            CargarSupervisores();
        }

        protected void gvSupervisores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Habilitar" || e.CommandName == "Deshabilitar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvSupervisores.DataKeys[index].Value);
                string nuevoEstado = e.CommandName == "Habilitar" ? "1" : "0";

                using (SqlConnection conn = Conexiones.Conectar())
                using (SqlCommand cmd = new SqlCommand("usp_cambiarEstadoSupervisor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_supervisor", id);
                    cmd.Parameters.AddWithValue("@nuevo_estado", nuevoEstado);
                    cmd.ExecuteNonQuery();
                }

                CargarSupervisores();
            }
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default1.aspx");
        }

    }

}