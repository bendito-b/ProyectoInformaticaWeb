using Microsoft.Reporting.WebForms;
using ProyectoInformaticaWeb.ClasesCDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoInformaticaWeb.Report
{
    public partial class ReporteIncidencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = IncidenciasDAO.CargarDatosIncidencias();

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/ReporteIncidencias.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("DataSet1", dt)); // Asegúrate que coincida con tu .rdlc
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}