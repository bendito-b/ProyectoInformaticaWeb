using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoInformaticaWeb.ClasesCDAO
{
    public class Conexiones
    {
        public static SqlConnection Conectar()
        {
            string sConexion = ConfigurationManager.ConnectionStrings["InformaticaWeb"].ConnectionString;
            SqlConnection sqlConexion = new SqlConnection(sConexion);
            sqlConexion.Open();
            return sqlConexion;
        }

    }
}