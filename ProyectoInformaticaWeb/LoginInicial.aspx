<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginInicial.aspx.cs" Inherits="ProyectoInformaticaWeb.LoginInicial" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Iniciar Sesión</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(to right, #667eea, #764ba2);
            margin: 0;
            padding: 0;
            display: flex;
            height: 100vh;
            justify-content: center;
            align-items: center;
    x|    }

        .login-container {
            background-color: #fff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 0 20px rgba(0,0,0,0.2);
            width: 100%;
            max-width: 400px;
        }

        .login-container h2 {
            text-align: center;
            margin-bottom: 30px;
            color: #333;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 6px;
            font-weight: bold;
        }

        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 6px;
            box-sizing: border-box;
        }

        .btn-submit {
            width: 100%;
            background-color: #667eea;
            color: white;
            padding: 12px;
            border: none;
            border-radius: 6px;
            font-size: 16px;
            cursor: pointer;
        }

        .btn-submit:hover {
            background-color: #5a67d8;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Iniciar Sesión</h2>
            <div class="form-group">
                <label for="Usuario">Usuario:</label>
                <asp:TextBox ID="Usuario" runat="server" TextMode="SingleLine" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="Contra">Contraseña:</label>
                <asp:TextBox ID="Contra" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <asp:Button ID="btn_log" runat="server" Text="Iniciar Sesión" CssClass="btn-submit" OnClick="btn_log_Click" />
        </div>
    </form>
</body>
</html>
