<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteUsuario.aspx.cs" Inherits="ProyectoInformaticaWeb.Report.ReporteUsuario" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Reporte de Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="600px" />
    </form>
</body>
</html>
