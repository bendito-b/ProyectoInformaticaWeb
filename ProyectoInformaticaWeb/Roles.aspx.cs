using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ProyectoInformaticaWeb.ClasesCDAO;

namespace ProyectoInformaticaWeb
{
    public partial class Roles : System.Web.UI.Page
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
                CargarRoles();
        }

        protected void btnAgregarRol_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombreRol.Text) && !string.IsNullOrWhiteSpace(txtEstadoRol.Text))
            {
                using (SqlConnection conn = Conexiones.Conectar())
                using (SqlCommand cmd = new SqlCommand("usp_InsertarRol", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", txtNombreRol.Text.Trim());
                    cmd.Parameters.AddWithValue("@estado", txtEstadoRol.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                txtNombreRol.Text = "";
                txtEstadoRol.Text = "";
                lblMensaje.Text = "Rol ingresado correctamente.";
                CargarRoles();
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Complete todos los campos.";
            }
        }

        private void CargarRoles()
        {
            using (SqlConnection conn = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_ObtenerRoles", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                gvRoles.DataSource = dt;
                gvRoles.DataBind();
            }
        }

        protected void gvRoles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRoles.EditIndex = e.NewEditIndex;
            CargarRoles();
        }

        protected void gvRoles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRoles.EditIndex = -1;
            CargarRoles();
        }

        protected void gvRoles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvRoles.Rows[e.RowIndex];
            int idRol = Convert.ToInt32(gvRoles.DataKeys[e.RowIndex].Value);
            TextBox txtNombre = (TextBox)row.FindControl("txtNombreEdit");
            string nombreNuevo = txtNombre.Text.Trim();

            using (SqlConnection conn = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_ActualizarRol", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_rol", idRol);
                cmd.Parameters.AddWithValue("@nombre", nombreNuevo);
                cmd.ExecuteNonQuery();
            }

            gvRoles.EditIndex = -1;
            CargarRoles();
        }

        protected void gvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Habilitar" || e.CommandName == "Deshabilitar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idRol = Convert.ToInt32(gvRoles.DataKeys[index].Value);
                string nuevoEstado = e.CommandName == "Habilitar" ? "1" : "0";

                using (SqlConnection conn = Conexiones.Conectar())
                using (SqlCommand cmd = new SqlCommand("usp_CambiarEstadoRol", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_rol", idRol);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.ExecuteNonQuery();
                }

                CargarRoles();
            }
        }
    }
}
