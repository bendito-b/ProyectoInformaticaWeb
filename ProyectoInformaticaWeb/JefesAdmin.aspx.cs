using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoInformaticaWeb
{
    public partial class JefesAdmin : Page
    {
        private const string SESSION_KEY = "dtJefes";
        private const string ADMIN_PASSWORD = "TATIANA"; // Cámbiala antes de producción:V

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session[SESSION_KEY] = CrearTablaTemporal();
                BindGrid((DataTable)Session[SESSION_KEY]);
            }
        }


        // Crea el DataTable con columnas y datos de prueba
        private DataTable CrearTablaTemporal()
        {
            var dt = new DataTable();
            dt.Columns.Add("SupervisorID", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Estacion", typeof(string));
            dt.Columns.Add("Estado", typeof(string));

            // Datos de ejemplo
            dt.Rows.Add(1, "Carlos Ramos", "carlos@uni.edu.pe", "Estación A", "activo");
            dt.Rows.Add(2, "Lucía Ortega", "lucia@uni.edu.pe", "Estación B", "inactivo");
            return dt;
        }

        // Buscando la tabla en Session y enlazando al GridView
        private void BindGrid(DataTable dt)
        {
            gvJefes.DataSource = dt;
            gvJefes.DataBind();
        }

        // *EDITAR*
        protected void gvJefes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvJefes.EditIndex = e.NewEditIndex;
            BindGrid((DataTable)Session[SESSION_KEY]);
        }

        // *CANCELAR EDICIÓN*
        protected void gvJefes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvJefes.EditIndex = -1;
            BindGrid((DataTable)Session[SESSION_KEY]);
        }

        // *ACTUALIZAR*
        protected void gvJefes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var dt = (DataTable)Session[SESSION_KEY];
            int id = (int)gvJefes.DataKeys[e.RowIndex].Value;
            GridViewRow row = gvJefes.Rows[e.RowIndex];

            // Lee nuevos valores
            string nuevoNombre = ((TextBox)row.Cells[1].Controls[0]).Text.Trim();
            string nuevoEmail = ((TextBox)row.Cells[2].Controls[0]).Text.Trim();
            string nuevaEstacion = ((TextBox)row.Cells[3].Controls[0]).Text.Trim();
            string nuevoEstado = ((TextBox)row.Cells[4].Controls[0]).Text.Trim().ToLower();

            // Validaciones
            if (!nuevoEmail.Contains("@") || !nuevoEmail.EndsWith(".com"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                  "alert('Email inválido. Debe contener @ y terminar en .com');", true);
                return;
            }
            if (nuevoEstado != "activo" && nuevoEstado != "inactivo")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                  "alert('Estado inválido. Solo \"activo\" o \"inactivo\"');", true);
                return;
            }

            // Actualiza fila
            DataRow dr = dt.Select($"SupervisorID = {id}")[0];
            dr["Nombre"] = nuevoNombre;
            dr["Email"] = nuevoEmail;
            dr["Estacion"] = nuevaEstacion;
            dr["Estado"] = nuevoEstado;

            gvJefes.EditIndex = -1;
            BindGrid(dt);
        }

        // *ELIMINAR*
        protected void gvJefes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var dt = (DataTable)Session[SESSION_KEY];
            int id = (int)gvJefes.DataKeys[e.RowIndex].Value;
            DataRow dr = dt.Select($"SupervisorID = {id}")[0];
            dt.Rows.Remove(dr);
            BindGrid(dt);
        }

        // *INSERTAR* (desde FooterTemplate)
        protected void gvJefes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                var dt = (DataTable)Session[SESSION_KEY];
                GridViewRow footer = gvJefes.FooterRow;

                string nombre = ((TextBox)footer.FindControl("txtNombreNew")).Text.Trim();
                string email = ((TextBox)footer.FindControl("txtEmailNew")).Text.Trim();
                string estacion = ((TextBox)footer.FindControl("txtEstacionNew")).Text.Trim();
                string estado = ((TextBox)footer.FindControl("txtEstadoNew")).Text.Trim().ToLower();

                // Validaciones
                if (!email.Contains("@") || !email.EndsWith(".com"))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                      "alert('Email inválido. Debe contener @ y terminar en .com');", true);
                    return;
                }
                if (estado != "activo" && estado != "inactivo")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                      "alert('Estado inválido. Solo \"activo\" o \"inactivo\"');", true);
                    return;
                }

                int nuevoID = dt.Rows.Count > 0
                              ? Convert.ToInt32(dt.Compute("MAX(SupervisorID)", "")) + 1
                              : 1;

                dt.Rows.Add(nuevoID, nombre, email, estacion, estado);
                BindGrid(dt);
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default1.aspx");
        }
    }


}