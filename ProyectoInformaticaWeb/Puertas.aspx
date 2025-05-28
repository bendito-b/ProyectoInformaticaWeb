<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Puertas.aspx.cs" Inherits="ProyectoInformaticaWeb.Puertas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Puertas</title>
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

        input[type="text"], input[type="number"] {
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Registrar Puerta</h2>

            <!-- Campo ID ocultable -->
            <div id="divIdPuerta" runat="server" class="form-group">
                <label for="txtId">ID Puerta:</label>
                <asp:TextBox ID="txtId" runat="server" TextMode="Number" />
            </div>

            <div class="form-group">
                <label for="txtUbicacion">Ubicación:</label>
                <asp:TextBox ID="txtUbicacion" runat="server" MaxLength="100" />
            </div>

            <div class="form-group">
                <label for="txtEstado">Estado:</label>
                <asp:DropDownList ID="ddlEstado" runat="server">
    <asp:ListItem Text="Habilitado" Value="1" />
    <asp:ListItem Text="Inhabilitado" Value="0" />
</asp:DropDownList>

            </div>

            <asp:Button
                ID="btnGuardar"
                runat="server"
                Text="Guardar"
                CssClass="btn btn-guardar"
                OnClick="btnGuardar_Click" />

            <asp:Button
                ID="btnRegresar"
                runat="server"
                Text="Regresar"
                CssClass="btn btn-regresar"
                OnClick="btnRegresar_Click" />
            <asp:Button ID="btnReporte" runat="server" Text="Generar Reporte" CssClass="btn btn-regresar" OnClick="btnReporte_Click" />


            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" />
        </div>

        <div class="tabla-datos">
            <h3>Listado de Puertas</h3>
            <asp:GridView ID="gvPuertas" runat="server" AutoGenerateColumns="False"
    OnRowEditing="gvPuertas_RowEditing"
    OnRowUpdating="gvPuertas_RowUpdating"
    OnRowCancelingEdit="gvPuertas_RowCancelingEdit"
    OnRowDeleting="gvPuertas_RowDeleting"
    OnRowCommand="gvPuertas_RowCommand"
    DataKeyNames="id_puerta">
    <Columns>
        <asp:BoundField DataField="id_puerta" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" />
        <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
                <%# Convert.ToInt32(Eval("estado")) == 1 ? "Habilitado" : "Inhabilitado" %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cambiar Estado">
            <ItemTemplate>
                <asp:Button ID="btnCambiarEstado" runat="server"
                    CommandName="CambiarEstado"
                    CommandArgument='<%# Eval("id_puerta") %>'
                    Text='<%# Convert.ToInt32(Eval("estado")) == 1 ? "Deshabilitar" : "Habilitar" %>' 
                    CssClass="btn btn-sm btn-warning" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

        </div>
    </form>
</body>
</html>