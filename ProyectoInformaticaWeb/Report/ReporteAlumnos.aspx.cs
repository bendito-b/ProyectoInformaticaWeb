using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

// Asegúrate de que estos namespaces coincidan con los de tu proyecto
using Proyecto.Datos;   // Para AlumnoDAO
using Proyecto.Modelos; // Para la clase Alumno

namespace ProyectoInformaticaWeb.Report
{
    public partial class ReporteAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only load the report the first time the page loads (not on postbacks)
            if (!IsPostBack)
            {
                // Initial load without filters
                CargarReporteAlumnos();
            }
        }

        /// <summary>
        /// Loads the student report, optionally applying filters.
        /// </summary>
        /// <param name="nombresFiltro">Filter string for student names.</param>
        /// <param name="apellidosFiltro">Filter string for student last names.</param>
        private void CargarReporteAlumnos(string nombresFiltro = null, string apellidosFiltro = null)
        {
            try
            {
                // 1. Create an instance of your DAO
                AlumnoDAO alumnoDao = new AlumnoDAO();

                // 2. Get the list of students, passing the filters to the DAO
                List<Alumno> datosAlumnos = alumnoDao.ObtenerAlumnos(nombresFiltro, apellidosFiltro);

                // 3. Clear existing data sources from the ReportViewer
                // Ensure your ReportViewer control in the .aspx is named "ReportViewer1"
                ReportViewer1.LocalReport.DataSources.Clear();

                // 4. Create a new data source for the report
                // "DataSetAlumnos" MUST EXACTLY MATCH the Dataset name you gave in the RDLC
                ReportDataSource rds = new ReportDataSource("DataSet1", datosAlumnos);

                // 5. Add the data source to the local report
                ReportViewer1.LocalReport.DataSources.Add(rds);

                // 6. Specify the path to your RDLC file
                // Server.MapPath("~/") gives you the physical path of your web application root
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/ReporteAlumnos.rdlc");

                // 7. Refresh the report to display the data
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                // Error handling: You can display a message to the user in the UI
                // For example, if you have a Label in your .aspx named lblErrorMessage, you could do:
                // lblErrorMessage.Text = "Error loading student report: " + ex.Message;
                Console.WriteLine("Error loading student report: " + ex.Message); // For debugging
            }
        }

        /// <summary>
        /// Event handler for the Filter Report button click.
        /// </summary>
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Call the method to load the report, passing the filter values from the text boxes
            CargarReporteAlumnos(txtNombres.Text, txtApellidos.Text);
        }
    }
}
