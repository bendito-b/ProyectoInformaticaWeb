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
    public partial class ReporteSupervisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = SupervisorDao.CargarDatosSupervisor(); // Asegúrate de que este método devuelve un DataTable con los datos necesarios

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/ReporteSupervisor.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("SupervisorD", dt)); // Asegúrate que coincida con tu .rdlc
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}