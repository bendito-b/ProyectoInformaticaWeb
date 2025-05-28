using System;
using System.Data;
using System.Web.UI;

namespace ProyectoInformaticaWeb
{
    public partial class CreacionUsuarios : System.Web.UI.Page
    {
        // Guardamos los datos en una tabla temporal (ViewState)
        private DataTable Usuarios
        {
            get
            {
                if (ViewState["Usuarios"] == null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("DNI");
                    dt.Columns.Add("Nombres");
                    dt.Columns.Add("Apellidos");
                    dt.Columns.Add("Numero");
                    dt.Columns.Add("Rol");
                    ViewState["Usuarios"] = dt;
                }
                return (DataTable)ViewState["Usuarios"];
            }
            set { ViewState["Usuarios"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvUsuarios.DataSource = Usuarios;
                gvUsuarios.DataBind();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtDni.Text) || txtDni.Text.Length != 8 || !int.TryParse(txtDni.Text, out _))
            {
                MostrarAlerta("El DNI debe contener exactamente 8 dígitos numéricos.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MostrarAlerta("Debe ingresar los nombres.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MostrarAlerta("Debe ingresar los apellidos.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MostrarAlerta("Debe ingresar un número.");
                return;
            }

            // Agregar usuario
            DataTable dt = Usuarios;
            dt.Rows.Add(txtDni.Text, txtNombres.Text, txtApellidos.Text, txtNumero.Text, ddlRol.SelectedValue);
            Usuarios = dt;

            gvUsuarios.DataSource = dt;
            gvUsuarios.DataBind();

            lblMensaje.Text = "Usuario ingresado correctamente.";

            // Limpiar campos
            txtDni.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtNumero.Text = "";
            ddlRol.SelectedIndex = 0;
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Por simplicidad, solo elimina por DNI
            string dni = txtDni.Text;
            DataTable dt = Usuarios;

            foreach (DataRow row in dt.Select($"DNI = '{dni}'"))
            {
                dt.Rows.Remove(row);
            }

            Usuarios = dt;
            gvUsuarios.DataSource = dt;
            gvUsuarios.DataBind();

            lblMensaje.Text = $"Usuario con DNI {dni} eliminado.";

            // Limpiar campos
            txtDni.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtNumero.Text = "";
            ddlRol.SelectedIndex = 0;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default1.aspx");
        }
        private void MostrarAlerta(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{mensaje}');", true);
        }

    }
}
