using System;
using ProyectoInformaticaWeb.ClasesCDAO;

namespace ProyectoInformaticaWeb
{
    public partial class LoginInicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_log_Click(object sender, EventArgs e)
        {
            string usuario = Usuario.Text.Trim();
            string clave = Contra.Text.Trim();

            string resultado = InformaticaDAO.VerificarInicioSesion(usuario, clave);

            if (resultado == "4" || resultado == "5")
            {
                // Guarda la sesión como combinación de usuario y clave
                Session["credencial"] = usuario + "|" + clave;

                if (resultado == "4")
                    Response.Redirect("Default2.aspx");
                else
                    Response.Redirect("Default1.aspx");
            }
            else
            {
                Response.Write("<script>alert('Usuario o contraseña incorrectos o estado no válido');</script>");
            }
        }

    }
}