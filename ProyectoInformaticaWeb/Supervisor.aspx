<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supervisor.aspx.cs" Inherits="ProyectoInformaticaWeb.Supervisor" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Supervisores</title>
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
            max-width: 500px;
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

        .btn-ingresar { background-color: #48bb78; color: white; }
        .btn-ingresar:hover { background-color: #38a169; }

        .btn-regresar { background-color: #f56565; color: white; }
        .btn-regresar:hover { background-color: #e53e3e; }

        .tabla-usuarios {
            margin-top: 30px;
            background-color: #fff;
            padding: 20px;
            border-radius: 12px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            width: 90%;
            max-width: 900px;
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
            <h2>Agregar Supervisor</h2>

            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" />
            </div>

            <div class="form-group">
                <label for="txtCorreo">Correo:</label>
                <asp:TextBox ID="txtCorreo" runat="server" MaxLength="100" />
            </div>

            <div class="form-group">
                <label for="txtEstacionId">Estación ID:</label>
                <asp:TextBox ID="txtEstacionId" runat="server" TextMode="Number" />
            </div>

            <div class="form-group">
                <label for="txtEstado">Estado:</label>
                <asp:TextBox ID="txtEstado" runat="server" MaxLength="20" />
            </div>

            <asp:Button ID="btnAgregar" runat="server" Text="Ingresar Supervisor" CssClass="btn btn-ingresar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-regresar" OnClick="btnRegresar_Click" />
            <asp:Button ID="btnReporte" runat="server" Text="Generar Reporte" CssClass="btn btn-regresar" OnClick="btnReporte_Click" />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" />
        </div>

        <div class="tabla-usuarios">
            <h3>Supervisores Registrados</h3>
            <asp:GridView ID="gvSupervisores" runat="server" AutoGenerateColumns="false"
                DataKeyNames="id_supervisor" OnRowEditing="gvSupervisores_RowEditing"
                OnRowUpdating="gvSupervisores_RowUpdating" OnRowCancelingEdit="gvSupervisores_RowCancelingEdit"
                OnRowCommand="gvSupervisores_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="id_supervisor" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate><%# Eval("nombre") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreEdit" runat="server" Text='<%# Eval("nombre") %>' MaxLength="100" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Correo">
                        <ItemTemplate><%# Eval("correo") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCorreoEdit" runat="server" Text='<%# Eval("correo") %>' MaxLength="100" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estación ID">
                        <ItemTemplate><%# Eval("estacion_id") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEstacionEdit" runat="server" Text='<%# Eval("estacion_id") %>' TextMode="Number" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Estado" DataField="estado" ReadOnly="true" />
                    <asp:CommandField ShowEditButton="true" />
                    <asp:ButtonField ButtonType="Button" Text="Deshabilitar" CommandName="Deshabilitar" />
                    <asp:ButtonField ButtonType="Button" Text="Habilitar" CommandName="Habilitar" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
