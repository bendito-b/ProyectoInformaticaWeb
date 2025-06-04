<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialPer.aspx.cs" Inherits="ProyectoInformaticaWeb.HistorialPer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión Historial Personal</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background: linear-gradient(to right, #00c6ff, #0072ff);
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
            min-height: 100vh;
        }

        .form-container {
            background-color: #fff;
            padding: 30px;
            border-radius: 12px;
            box-shadow: 0 0 20px rgba(0,0,0,0.2);
            width: 100%;
            max-width: 500px;
            margin-top: 30px;
        }

        .form-group {
            margin-bottom: 15px;
            text-align: left;
        }

        label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"], input[type="number"], input[type="datetime-local"], textarea {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 6px;
            box-sizing: border-box;
        }

        .btn {
            width: 100%;
            padding: 12px;
            margin-top: 10px;
            border: none;
            border-radius: 6px;
            font-size: 16px;
            cursor: pointer;
        }

        .btn-guardar { background-color: #48bb78; color: white; }
        .btn-guardar:hover { background-color: #38a169; }

        .btn-regresar { background-color: #4299e1; color: white; }
        .btn-regresar:hover { background-color: #3182ce; }

        .tabla-datos {
            margin-top: 30px;
            background-color: #fff;
            padding: 20px;
            border-radius: 12px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            width: 90%;
            max-width: 800px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: center;
        }

        th {
            background-color: #0072ff;
            color: white;
        }

        .reporte-container {
            margin-top: 30px;
            background-color: #fff;
            padding: 20px;
            border-radius: 12px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            width: 90%;
            max-width: 800px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <div class="form-container">
            <h2>Registrar Historial Personal</h2>

            <div class="form-group">
                <label for="txtIdAlumno">ID Alumno:</label>
                <asp:TextBox ID="txtIdAlumno" runat="server" TextMode="Number" />
            </div>

            <div class="form-group">
                <label for="txtEvento">Evento:</label>
                <asp:TextBox ID="txtEvento" runat="server" MaxLength="20" />
            </div>

            <div class="form-group">
                <label for="txtPuertaId">ID Puerta:</label>
                <asp:TextBox ID="txtPuertaId" runat="server" TextMode="Number" />
            </div>

            <div class="form-group">
                <label for="txtUsuarioId">ID Usuario:</label>
                <asp:TextBox ID="txtUsuarioId" runat="server" TextMode="Number" />
            </div>

            <div class="form-group">
                <label for="txtObjetos">Objetos:</label>
                <asp:TextBox ID="txtObjetos" runat="server" TextMode="MultiLine" Rows="3" />
            </div>

            <div class="form-group">
                <label for="txtFecha">Fecha:</label>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="DateTime" />
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-guardar" OnClick="btnGuardar_Click" />
            <div class="form-group">
                <label for="txtFiltroIdAlumno">Filtrar por ID Alumno:</label>
                <asp:TextBox ID="txtFiltroIdAlumno" runat="server" TextMode="Number" />
            </div>

            <asp:Button ID="btnMostrarReporte" runat="server" Text="Mostrar Reporte" CssClass="btn btn-regresar" OnClick="btnMostrarReporte_Click" />


            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" />
        </div>

        <div class="tabla-datos">
            <h3>Listado de Historial</h3>
            <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="False" DataKeyNames="id_his_per">
                <Columns>
                    <asp:BoundField DataField="id_his_per" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="id_alumno" HeaderText="ID Alumno" />
                    <asp:BoundField DataField="evento" HeaderText="Evento" />
                    <asp:BoundField DataField="puerta_id" HeaderText="ID Puerta" />
                    <asp:BoundField DataField="usuario_id" HeaderText="ID Usuario" />
                    <asp:BoundField DataField="objetos" HeaderText="Objetos" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                </Columns>
            </asp:GridView>
        </div>

        <div class="reporte-container" style="display:none;" id="divReporte" runat="server">
            <h3>Reporte Historial</h3>
            <asp:UpdatePanel ID="UpdatePanelReporte" runat="server">
                <ContentTemplate>
                    <rsweb:ReportViewer ID="ReportViewerHistorial" runat="server" Width="100%" Height="600px"
                        ProcessingMode="Local" ShowParameterPrompts="False" ZoomMode="PageWidth" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
