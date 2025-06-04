using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls; 
using Microsoft.Reporting.WebForms; 

using Proyecto.Datos;   
using Proyecto.Modelos; 

namespace ProyectoInformaticaWeb.Report
{
    public partial class ReporteAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo carga el reporte la primera vez que se carga la página (no en postbacks)
            if (!IsPostBack)
            {
                CargarReporteAlumnos();
            }
        }

        private void CargarReporteAlumnos()
        {
            try
            {
                // 1. Crear una instancia de tu DAO
                AlumnoDAO alumnoDao = new AlumnoDAO();

                // 2. Obtener la lista de alumnos
                List<Alumno> datosAlumnos = alumnoDao.ObtenerAlumnos();

                // 3. Limpiar las fuentes de datos existentes del ReportViewer
                // Asegúrate de que tu control ReportViewer en el .aspx se llame "ReportViewer1"
                ReportViewer1.LocalReport.DataSources.Clear();

                // 4. Crear una nueva fuente de datos para el reporte
                // "DataSetAlumnos" DEBE COINCIDIR EXACTAMENTE con el nombre del Dataset que le diste en el RDLC
                ReportDataSource rds = new ReportDataSource("DataSetAlumnos", datosAlumnos);

                // 5. Añadir la fuente de datos al reporte local
                ReportViewer1.LocalReport.DataSources.Add(rds);

                // 6. Especificar la ruta de tu archivo RDLC
                // Server.MapPath("~/") te da la ruta física de la raíz de tu aplicación web
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/ReporteAlumnos.rdlc");

                // 7. Refrescar el reporte para mostrar los datos
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                // Manejo de errores: Puedes mostrar un mensaje al usuario en la UI
                // Por ejemplo, si tienes un Label en tu .aspx llamado lblMensajeError, podrías hacer:
                // lblMensajeError.Text = "Error al cargar el reporte de alumnos: " + ex.Message;
                Console.WriteLine("Error al cargar el reporte de alumnos: " + ex.Message); // Para depuración
            }
        }
    }
}
