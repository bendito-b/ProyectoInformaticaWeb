using System;
using System.Web.UI.WebControls;
using ProyectoInformaticaWeb.ClasesCDAO;

namespace ProyectoInformaticaWeb
{
    public partial class Supervisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SesionValida())
            {
                Response.Redirect("LoginInicial.aspx");
                return;
            }

            if (!IsPostBack)
                CargarSupervisores();
        }

        private bool SesionValida()
        {
            if (Session["credencial"] == null)
                return false;

            var partes = Session["credencial"].ToString().Split('|');
            return partes.Length == 2 && InformaticaDAO.VerificarSesion(partes[0], partes[1]);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            if (int.TryParse(txtEstacionId.Text.Trim(), out int estacionId))
            {
                SupervisorDAO.InsertarSupervisor(txtNombre.Text.Trim(), txtCorreo.Text.Trim(), estacionId, ddlEstado.SelectedValue);
                MostrarMensaje("Supervisor agregado correctamente.", true);
                LimpiarFormulario();
                CargarSupervisores();
            }
            else
            {
                MostrarMensaje("ID de estación inválido.", false);
            }
        }

        private void MostrarMensaje(string mensaje, bool exito)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = $"mt-3 d-block fw-bold text-{(exito ? "success" : "danger")}";
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = txtCorreo.Text = txtEstacionId.Text = "";
            ddlEstado.SelectedIndex = 0;
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Report/ReporteSupervisor.aspx");
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default1.aspx");
        }

        private void CargarSupervisores()
        {
            gvSupervisores.DataSource = SupervisorDAO.CargarDatosSupervisor();
            gvSupervisores.DataBind();
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
            var row = gvSupervisores.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvSupervisores.DataKeys[e.RowIndex].Value);

            string nombre = ((TextBox)row.FindControl("txtNombreEdit"))?.Text.Trim();
            string correo = ((TextBox)row.FindControl("txtCorreoEdit"))?.Text.Trim();
            string estacionText = ((TextBox)row.FindControl("txtEstacionEdit"))?.Text.Trim();

            if (int.TryParse(estacionText, out int estacionId))
            {
                SupervisorDAO.ActualizarSupervisor(id, nombre, correo, estacionId, "1"); // asume activo
                gvSupervisores.EditIndex = -1;
                CargarSupervisores();
            }
        }

        protected void gvSupervisores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Habilitar" || e.CommandName == "Deshabilitar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvSupervisores.DataKeys[index].Value);
                string nuevoEstado = e.CommandName == "Habilitar" ? "1" : "0";

                SupervisorDAO.CambiarEstadoSupervisor(id, nuevoEstado);
                CargarSupervisores();
            }
        }

        public string ObtenerEstado(object estado)
        {
            switch (estado?.ToString().Trim())
            {
                case "1": return "Activo";
                case "0": return "Inactivo";
                default: return "Desconocido";
            }
        }
    }
}
