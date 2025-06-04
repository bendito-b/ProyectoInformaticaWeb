<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteAlumnos.aspx.cs" Inherits="ProyectoInformaticaWeb.Report.ReporteAlumnos" %>
<%--
    El atributo Inherits se ha corregido para que apunte a la clase CodeBehind correcta (ReporteAlumnos).
    El control ReportViewer y el título se han añadido dentro del div del formulario.
    Asegúrate de que la versión del ensamblado de ReportViewer (Version=15.0.0.0) coincida con la que tienes en tu proyecto.
    Si arrastras el control ReportViewer desde el "Cuadro de herramientas" en Visual Studio, la directiva @Register se generará automáticamente con la versión correcta.
--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reporte de Alumnos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Reporte de Alumnos</h2>
            <br />
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="800px"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
