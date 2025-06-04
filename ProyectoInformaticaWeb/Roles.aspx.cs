using System;
using System.Data;
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
                RolesDAOcs.InsertarRol(txtNombreRol.Text.Trim(), txtEstadoRol.Text.Trim());

                txtNombreRol.Text = "";
                txtEstadoRol.Text = "";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
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
            gvRoles.DataSource = RolesDAOcs.ObtenerRoles();
            gvRoles.DataBind();
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Report/ReporteRoles.aspx");
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

            RolesDAOcs.ActualizarRol(idRol, nombreNuevo);

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

                RolesDAOcs.CambiarEstadoRol(idRol, nuevoEstado);
                CargarRoles();
            }
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            // ¡IMPORTANTE! Aquí se especifica a qué página regresar.
            // Asegúrate de que "Default1.aspx" sea el nombre correcto de tu página principal.
            Response.Redirect("Default1.aspx");
        }

    }
}
