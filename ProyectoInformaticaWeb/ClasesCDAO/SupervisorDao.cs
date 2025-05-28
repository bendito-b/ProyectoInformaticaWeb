using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoInformaticaWeb.ClasesCDAO
{
    public class SupervisorDao
    {
        public static DataTable CargarDatosSupervisor()
        {
            using (SqlConnection connection = Conexiones.Conectar())
            {
                using (SqlCommand command = new SqlCommand("usp_ObtenerSupervisor", connection))
                {
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;


                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}