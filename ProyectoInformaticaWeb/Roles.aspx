<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="ProyectoInformaticaWeb.Roles" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Roles</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
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
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 0 20px rgba(0,0,0,0.2);
            width: 100%;
            max-width: 450px;
            text-align: center;
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

        input[type="text"] {
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

        .btn-ingresar { background-color: #48bb78; color: white; }
        .btn-ingresar:hover { background-color: #38a169; }

        .tabla-usuarios {
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
            <h2>Agregar Rol</h2>

            <div class="form-group">
                <label for="txtNombreRol">Nombre del Rol:</label>
                <asp:TextBox ID="txtNombreRol" runat="server" MaxLength="50" />
            </div>

            <div class="form-group">
                <label for="txtEstadoRol">Estado:</label>
                <asp:TextBox ID="txtEstadoRol" runat="server" MaxLength="50" />
            </div>

            <asp:Button ID="btnAgregarRol" runat="server" Text="Ingresar Rol" CssClass="btn btn-ingresar" OnClick="btnAgregarRol_Click" />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" />
        </div>

        <div class="tabla-usuarios">
            <h3>Roles Registrados</h3>
            <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False"
    OnRowCommand="gvRoles_RowCommand"
    OnRowEditing="gvRoles_RowEditing"
    OnRowCancelingEdit="gvRoles_RowCancelingEdit"
    OnRowUpdating="gvRoles_RowUpdating"
    DataKeyNames="id_rol">

    <Columns>
        <asp:BoundField DataField="id_rol" HeaderText="ID" ReadOnly="true" />
        <asp:TemplateField HeaderText="Nombre">
            <ItemTemplate>
                <%# Eval("nombre") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtNombreEdit" runat="server" Text='<%# Bind("nombre") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="estado" HeaderText="Estado" />

        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnHabilitar" runat="server" CommandName="Habilitar"
                    CommandArgument='<%# Container.DataItemIndex %>' Text="Habilitar"
                    Visible='<%# Eval("estado").ToString().Trim() == "0" %>' />

                <asp:Button ID="btnDeshabilitar" runat="server" CommandName="Deshabilitar"
                    CommandArgument='<%# Container.DataItemIndex %>' Text="Deshabilitar"
                    Visible='<%# Eval("estado").ToString().Trim() == "1" %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" />
    </Columns>
</asp:GridView>

        </div>
    </form>
</body>
</html>
