<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerarQR.aspx.cs" Inherits="ProyectoInformaticaWeb.GenerarQR" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Generar Código QR</title>
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
        }

        .qr-container {
            background-color: #fff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 0 20px rgba(0,0,0,0.2);
            width: 100%;
            max-width: 400px;
            text-align: center;
        }

        .qr-container h2 {
            margin-bottom: 20px;
            color: #333;
        }

        .qr-container img {
            max-width: 200px;
            margin: 20px 0;
        }

        .form-group {
            margin-bottom: 20px;
            text-align: left;
        }

        .form-group label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .form-group input[type="text"] {
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

        .btn-generate {
            background-color: #667eea;
            color: white;
        }

        .btn-generate:hover {
            background-color: #5a67d8;
        }

        .btn-close {
            background-color: #e53e3e;
            color: white;
        }

        .btn-close:hover {
            background-color: #c53030;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="qr-container">
            <h2>Generador de QR</h2>

            <div class="form-group">
                <label for="txtContenido">Texto para el QR:</label>
                <asp:TextBox ID="txtContenido" runat="server" CssClass="form-control" placeholder="Escribe aquí el texto..." />
            </div>

            <asp:Button ID="btnGenerarQR" runat="server" Text="Generar QR" CssClass="btn btn-generate" OnClick="btnGenerarQR_Click" />

            <asp:Image ID="imgQR" runat="server" AlternateText="Código QR" />

            <asp:Button ID="btnCerrar" runat="server" Text="Volver a la Página Principal" CssClass="btn btn-close" OnClick="btnCerrar_Click" />
        </div>
    </form>
</body>
</html>