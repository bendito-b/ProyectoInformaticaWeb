using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using ProyectoInformaticaWeb.DAOs;

namespace ProyectoInformaticaWeb
{
    public partial class HistorialPer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHistorial();
                divReporte.Style["display"] = "none"; // Oculta reporte al inicio
            }
        }

        private void CargarHistorial()
        {
            gvHistorial.DataSource = HistorialPerDAO.ListarHistorial();
            gvHistorial.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idAlumno = int.Parse(txtIdAlumno.Text.Trim());
                string evento = txtEvento.Text.Trim();
                int puertaId = int.Parse(txtPuertaId.Text.Trim());
                int usuarioId = int.Parse(txtUsuarioId.Text.Trim());
                string objetos = txtObjetos.Text.Trim();
                DateTime fecha = DateTime.Parse(txtFecha.Text.Trim());

                HistorialPerDAO.InsertarHistorial(idAlumno, evento, puertaId, usuarioId, objetos, fecha);

                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Historial guardado exitosamente.";
                LimpiarCampos();
                CargarHistorial();
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private void LimpiarCampos()
        {
            txtIdAlumno.Text = "";
            txtEvento.Text = "";
            txtPuertaId.Text = "";
            txtUsuarioId.Text = "";
            txtObjetos.Text = "";
            txtFecha.Text = "";
        }

        protected void btnMostrarReporte_Click(object sender, EventArgs e)
        {
            divReporte.Style["display"] = "block"; // Mostrar reporte
            CargarReporte();
        }

        private void CargarReporte()
        {
            ReportViewerHistorial.LocalReport.DataSources.Clear();

            DataTable dt;
            int filtroId;

            // Si el campo de filtro tiene valor numérico válido, buscar por ID Alumno
            if (int.TryParse(txtFiltroIdAlumno.Text.Trim(), out filtroId))
            {
                dt = HistorialPerDAO.BuscarPorIdAlumno(filtroId);
            }
            else
            {
                dt = HistorialPerDAO.ListarHistorial(); // Sin filtro, todos los registros
            }

            ReportDataSource rds = new ReportDataSource("DataSet2", dt);
            ReportViewerHistorial.LocalReport.ReportPath = Server.MapPath("~/Report/ReporteHistorialPer.rdlc");
            ReportViewerHistorial.LocalReport.DataSources.Add(rds);
            ReportViewerHistorial.LocalReport.Refresh();
        }

    }
}
