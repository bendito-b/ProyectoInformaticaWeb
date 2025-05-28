<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteIncidencias.aspx.cs" Inherits="ProyectoInformaticaWeb.Report.ReporteIncidencias" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte de Puertas</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="600px" />
    </form>
</body>
</html>
