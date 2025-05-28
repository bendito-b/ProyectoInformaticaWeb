<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario1.aspx.cs" Inherits="ProyectoInformaticaWeb.Usuario1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Usuarios</title>
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
            max-width: 600px;
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

        input[type="text"], input[type="password"] {
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
            max-width: 1000px;
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
            <h2>Registrar Usuario</h2>

            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" />
            </div>

            <div class="form-group">
                <label for="txtApellido">Apellido:</label>
                <asp:TextBox ID="txtApellido" runat="server" MaxLength="100" />
            </div>

            <div class="form-group">
                <label for="txtTelefono">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" MaxLength="20" />
            </div>

            <div class="form-group">
                <label for="txtContrasena">Contraseña:</label>
                <asp:TextBox ID="txtContrasena" runat="server" MaxLength="256" />
            </div>

            <div class="form-group">
                <label for="txtRolId">Rol ID:</label>
                <asp:TextBox ID="txtRolId" runat="server" />
            </div>

            <div class="form-group">
                <label for="txtEstado">Estado:</label>
                <asp:TextBox ID="txtEstado" runat="server" MaxLength="20" />
            </div>

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Usuario" CssClass="btn btn-ingresar" OnClick="btnRegistrar_Click" />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" />
        </div>

        <div class="tabla-usuarios">
            <h3>Usuarios Registrados</h3>
            
            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" OnRowCommand="gvUsuarios_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="id_usuario" />
                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                    <asp:BoundField HeaderText="Teléfono" DataField="telefono" />
                    <asp:BoundField HeaderText="Contraseña" DataField="contrasena" />
                    <asp:BoundField HeaderText="Rol ID" DataField="rol_id" />
                    <asp:BoundField HeaderText="Estado" DataField="estado" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEstado" runat="server"
                                Text='<%# Eval("estado").ToString() == "1" ? "Deshabilitar" : "Habilitar" %>'
                                CommandName='<%# Eval("estado").ToString() == "1" ? "Deshabilitar" : "Habilitar" %>'
                                CommandArgument='<%# Eval("id_usuario") %>'
                                CssClass='<%# Eval("estado").ToString() == "1" ? "btn btn-danger" : "btn btn-success" %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnVolver" runat="server" Text="Volver al Inicio" CssClass="btn btn-primary" OnClick="btnVolver_Click" />
        </div>
    </form>
</body>
</html>
