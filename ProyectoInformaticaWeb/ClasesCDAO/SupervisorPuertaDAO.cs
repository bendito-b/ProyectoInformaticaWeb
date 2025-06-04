using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoInformaticaWeb.ClasesCDAO
{
    public class SupervisorPuertaDAO
    {
        public static DataTable ReporteSupervisoresPuertas(string filtroSupervisor, string filtroPuerta)
        {
            using (SqlConnection connection = Conexiones.Conectar())
            {
                using (SqlCommand command = new SqlCommand("usp_ReporteSupervisoresPuertas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Supervisor", string.IsNullOrEmpty(filtroSupervisor) ? (object)DBNull.Value : filtroSupervisor);
                    command.Parameters.AddWithValue("@Puerta", string.IsNullOrEmpty(filtroPuerta) ? (object)DBNull.Value : filtroPuerta);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

    }
}