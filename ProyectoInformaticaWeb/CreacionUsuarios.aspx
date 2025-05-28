<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreacionUsuarios.aspx.cs" Inherits="ProyectoInformaticaWeb.CreacionUsuarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Creación de Usuarios</title>
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

        input[type="text"], select {
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

        .btn-eliminar { background-color: #e53e3e; color: white; }
        .btn-eliminar:hover { background-color: #c53030; }

        .btn-volver { background-color: #4299e1; color: white; }
        .btn-volver:hover { background-color: #3182ce; }

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
            <h2>Crear Usuario</h2>

            <div class="form-group">
                <label for="txtDni">DNI:</label>
                <asp:TextBox ID="txtDni" runat="server" MaxLength="8" />
            </div>

            <div class="form-group">
                <label for="txtNombres">Nombres:</label>
                <asp:TextBox ID="txtNombres" runat="server" />
            </div>

            <div class="form-group">
                <label for="txtApellidos">Apellidos:</label>
                <asp:TextBox ID="txtApellidos" runat="server" />
            </div>

            <div class="form-group">
                <label for="txtNumero">Número:</label>
                <asp:TextBox ID="txtNumero" runat="server" />
            </div>

            <div class="form-group">
                <label for="ddlRol">Rol:</label>
                <asp:DropDownList ID="ddlRol" runat="server">
                    <asp:ListItem Text="Admin" Value="Admin" />
                    <asp:ListItem Text="Alumno" Value="Alumno" />
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-ingresar" OnClick="btnIngresar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-eliminar" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver a Inicio" CssClass="btn btn-volver" OnClick="btnVolver_Click" />

            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" />
        </div>

        <div class="tabla-usuarios">
            <h3>Usuarios Ingresados</h3>
            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="DNI" DataField="DNI" />
                    <asp:BoundField HeaderText="Nombres" DataField="Nombres" />
                    <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
                    <asp:BoundField HeaderText="Número" DataField="Numero" />
                    <asp:BoundField HeaderText="Rol" DataField="Rol" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
