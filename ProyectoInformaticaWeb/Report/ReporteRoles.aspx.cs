using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using ProyectoInformaticaWeb.ClasesCDAO;

namespace ProyectoInformaticaWeb
{
    public partial class ReporteRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = RolesDAOcs.ObtenerTodas();

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/ReporteRoles.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("DataSet1", dt)); // Asegúrate que coincida con tu .rdlc
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}