using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoInformaticaWeb
{
    public partial class GenerarQR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Puedes cargar el QR si ya existe
            }
        }

        protected void btnGenerarQR_Click(object sender, EventArgs e)
        {
            // Aquí generas el QR y lo asignas a imgQR.ImageUrl
            string datos = "https://tusitio.com/usuario"; // ejemplo
            //string rutaQR = GenerarCodigoQR(datos); // tu método para generar el QR
            //imgQR.ImageUrl = rutaQR;
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}