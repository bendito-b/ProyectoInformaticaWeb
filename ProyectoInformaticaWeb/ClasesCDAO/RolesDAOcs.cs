using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoInformaticaWeb.ClasesCDAO
{
    public class RolesDAOcs
    {
        public static DataTable ObtenerTodas()
        {
            using (SqlConnection con = Conexiones.Conectar())
            using (SqlCommand cmd = new SqlCommand("usp_ObtenerRoles", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}