using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoInformaticaWeb.ClasesCDAO;

namespace ProyectoInformaticaWeb
{
    public partial class Puertas : System.Web.UI.Page
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
                // Oculta el campo ID al insertar
                divIdPuerta.Visible = false;
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            gvPuertas.DataSource = PuertasDAO.ObtenerTodas();
            gvPuertas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtUbicacion.Text) ||
                string.IsNullOrWhiteSpace(ddlEstado.Text))
            {
                MostrarAlerta("Todos los campos son obligatorios.");
                return;
            }

            // Parsear ID (opcional si lo generas en la BD)
            if (!int.TryParse(txtId.Text, out int id))
            {
                id = 0; // Valor por defecto si no se proporciona
            }

            // Convertir texto de estado a 0 o 1
            string estadoTexto = ddlEstado.Text.Trim().ToLower();
            int estado = estadoTexto == "Habilitado" ? 1 :
                         estadoTexto == "Inhabilitado" ? 0 : -1;

            if (estado == -1)
            {
                MostrarAlerta("El estado debe ser 'Habilitado' o 'Inhabilitado'.");
                return;
            }

            // Insertar puerta
            PuertasDAO.Insertar( txtUbicacion.Text.Trim(), estado);

            lblMensaje.ForeColor = System.Drawing.Color.Green;
            lblMensaje.Text = "Puerta registrada correctamente.";

            LimpiarCampos();
            CargarGrid();
        }


        protected void gvPuertas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPuertas.EditIndex = e.NewEditIndex;
            CargarGrid();
        }

        protected void gvPuertas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPuertas.EditIndex = -1;
            CargarGrid();
        }

        protected void gvPuertas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvPuertas.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvPuertas.Rows[e.RowIndex];
            TextBox txtUbicacion = (TextBox)row.FindControl("txtUbicacion");
            TextBox txtEstado = (TextBox)row.FindControl("ddlEstado");

            string ubicacion = txtUbicacion.Text.Trim();
            string estadoStr = txtEstado.Text.Trim().ToLower();
            int estado = (estadoStr == "Habilitado") ? 1 : 0;


            PuertasDAO.Actualizar(id, ubicacion, estado);

            gvPuertas.EditIndex = -1;
            lblMensaje.ForeColor = System.Drawing.Color.Green;
            lblMensaje.Text = "Puerta actualizada correctamente.";
            CargarGrid();
        }

        protected void gvPuertas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvPuertas.DataKeys[e.RowIndex].Value);

            // Llama al método para eliminar en la base de datos
            PuertasDAO.Eliminar(id); // <<--- FALTA ESTO

            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Text = $"Puerta {id} eliminada.";
            CargarGrid();
        }


        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default1.aspx");
        }

        private void MostrarAlerta(string mensaje)
        {
            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "alert",
                $"alert('{mensaje}');",
                true
            );
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtUbicacion.Text = "";
            ddlEstado.Text = "";
        }
        protected void gvPuertas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CambiarEstado")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                // Buscar el estado actual
                DataTable dt = PuertasDAO.ObtenerPorId(id);
                if (dt.Rows.Count > 0)
                {
                    int estadoActual = Convert.ToInt32(dt.Rows[0]["estado"]);
                    int nuevoEstado = estadoActual == 1 ? 0 : 1;

                    PuertasDAO.ActualizarEstado(id, nuevoEstado);
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Estado cambiado correctamente.";
                    CargarGrid();
                }
            }
        }

    }
}