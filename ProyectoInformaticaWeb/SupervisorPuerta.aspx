<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorPuerta.aspx.cs" Inherits="ProyectoInformaticaWeb.SupervisorPuerta" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Reporte Supervisor-Puerta</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.7.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container py-5">
            <!-- Filtros -->
            <div class="card shadow mb-4">
                <div class="card-header bg-info text-white text-center">
                    <h2>Reporte Supervisor-Puerta</h2>
                </div>
                <div class="card-body">
                    <div class="row g-3">
                        <div class="col-md-4">
                            <label for="txtFiltroSupervisor" class="form-label">Supervisor</label>
                            <asp:TextBox ID="txtFiltroSupervisor" runat="server" CssClass="form-control" placeholder="Nombre o parte del nombre" />
                        </div>
                        <div class="col-md-4">
                            <label for="txtFiltroPuerta" class="form-label">Puerta</label>
                            <asp:TextBox ID="txtFiltroPuerta" runat="server" CssClass="form-control" placeholder="Nombre de la puerta" />
                        </div>
                    </div>
                    <div class="mt-4 d-flex justify-content-center gap-3 flex-wrap">
                        <asp:Button ID="btnBuscar" runat="server" Text="🔍 Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                        <asp:Button ID="btnExportarPDF" runat="server" Text="📄 Exportar PDF" CssClass="btn btn-danger" OnClick="btnExportarPDF_Click" />
                    </div>
                </div>
            </div>

            <!-- Reporte -->
            <div class="card shadow">
                <div class="card-body">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="500px" ProcessingMode="Local" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
