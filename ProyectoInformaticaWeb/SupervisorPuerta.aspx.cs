using Microsoft.Reporting.WebForms;
using ProyectoInformaticaWeb.ClasesCDAO;
using System;
using System.Data;
using System.Web.UI;

namespace ProyectoInformaticaWeb
{
    public partial class SupervisorPuerta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReporte(); // Carga inicial sin filtros
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarReporte(); // Vuelve a cargar con los filtros
        }

        protected void btnExportarPDF_Click(object sender, EventArgs e)
        {
            // Vuelve a cargar los datos filtrados
            string filtroSupervisor = txtFiltroSupervisor.Text.Trim();
            string filtroPuerta = txtFiltroPuerta.Text.Trim();

            DataTable dt = SupervisorPuertaDAO.ReporteSupervisoresPuertas(filtroSupervisor, filtroPuerta);

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/SupervisorPuerta.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("SuPu", dt));
            ReportViewer1.LocalReport.Refresh();

            // Exportar a PDF
            Warning[] warnings;
            string[] streamIds;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamIds, out warnings);

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=ReporteSupervisorPuerta.pdf");
            Response.BinaryWrite(bytes);
            Response.End();
        }

        private void CargarReporte()
        {
            string filtroSupervisor = txtFiltroSupervisor.Text.Trim();
            string filtroPuerta = txtFiltroPuerta.Text.Trim();

            DataTable dt = SupervisorPuertaDAO.ReporteSupervisoresPuertas(filtroSupervisor, filtroPuerta);

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/SupervisorPuerta.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("SuPu", dt));
            ReportViewer1.LocalReport.Refresh();
        }
    }
}
