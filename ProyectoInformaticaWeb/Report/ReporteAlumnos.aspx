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
    <style>
        /* Basic styling for better layout */
        .filter-container {
            margin-bottom: 20px;
            padding: 15px;
            border: 1px solid #ddd;
            border-radius: 8px;
            background-color: #f9f9f9;
            display: flex;
            flex-wrap: wrap;
            gap: 15px;
            align-items: center;
        }
        .filter-item {
            display: flex;
            flex-direction: column;
        }
        .filter-item label {
            font-weight: bold;
            margin-bottom: 5px;
        }
        .filter-item input[type="text"] {
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            width: 200px; /* Adjust as needed */
        }
        .filter-button {
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            transition: background-color 0.3s ease;
        }
        .filter-button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Reporte de Alumnos</h2>
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server" />

            <div class="filter-container">
                <div class="filter-item">
                    <asp:Label ID="lblNombres" runat="server" Text="Nombres:"></asp:Label>
                    <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox>
                </div>
                <div class="filter-item">
                    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos:"></asp:Label>
                    <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar Reporte" CssClass="filter-button" OnClick="btnFiltrar_Click" />
            </div>

            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="800px"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
