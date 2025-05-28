using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using ProyectoInformaticaWeb.ClasesCDAO;

namespace ProyectoInformaticaWeb
{
    public partial class ReportePuertas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = PuertasDAO.ObtenerTodas();

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/ReportePuertas.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("PuertasDS", dt));
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}
