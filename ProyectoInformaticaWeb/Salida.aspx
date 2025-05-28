<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salida.aspx.cs" Inherits="ProyectoInformaticaWeb.Salida" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Registro de Entrada y Salida</title>
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

        .form-container {
            background-color: #fff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 0 20px rgba(0,0,0,0.2);
            width: 100%;
            max-width: 420px;
            text-align: center;
        }

        .form-container h2 {
            margin-bottom: 25px;
            color: #333;
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

        .btn-verify {
            background-color: #48bb78;
            color: white;
        }

        .btn-verify:hover {
            background-color: #38a169;
        }

        .btn-add {
            background-color: #4299e1;
            color: white;
        }

        .btn-add:hover {
            background-color: #3182ce;
        }

        .btn-back {
            background-color: #e53e3e;
            color: white;
        }

        .btn-back:hover {
            background-color: #c53030;
        }

        #listaObjetos {
            margin-top: 20px;
            text-align: left;
            background-color: #f0f0f0;
            padding: 15px;
            border-radius: 6px;
            font-size: 14px;
            color: #333;
        }

        #listaObjetos strong {
            display: block;
            margin-bottom: 8px;
        }

        #listaObjetos ul {
            margin: 0;
            padding-left: 20px;
        }

        #listaObjetos li {
            margin-bottom: 5px;
        }
    </style>

    <script type="text/javascript">
        var objetosAgregados = [];

        function validarDatos() {
            var idVal = document.getElementById('<%= txtID.ClientID %>').value.trim();
            var codVal = document.getElementById('<%= txtCodigo.ClientID %>').value.trim();

            var esNumero = /^\d+$/.test(idVal);

            if (
                idVal === "" || codVal === "" ||
                idVal.length > 8 || codVal.length > 0 && !esNumero || codVal.length !== 17
            ) {
                alert("Faltan datos o datos inválidos");
                return false;
            }

            return true;
        }

        function agregarSalida() {
            if (!validarDatos()) return false;

            var codigoInput = document.getElementById('<%= txtCodigo.ClientID %>');
            var codVal = codigoInput.value.trim();

            // Agregar a lista
            objetosAgregados.push(codVal);
            actualizarListaObjetos();

            // Limpiar solo el campo Código
            codigoInput.value = "";

            alert("Campos agregados");
            return false;
        }

        function verificarSalida() {
            if (!validarDatos()) return false;

            // Limpiar ambos campos y la lista
            document.getElementById('<%= txtID.ClientID %>').value = "";
            document.getElementById('<%= txtCodigo.ClientID %>').value = "";
            objetosAgregados = [];
            actualizarListaObjetos();

            alert("Campos agregados");
            return false;
        }

        function actualizarListaObjetos() {
            var listaDiv = document.getElementById("listaObjetos");
            if (objetosAgregados.length === 0) {
                listaDiv.innerHTML = "";
                return;
            }

            var html = "<strong>Objetos agregados:</strong><ul>";
            for (var i = 0; i < objetosAgregados.length; i++) {
                html += "<li>" + objetosAgregados[i] + "</li>";
            }
            html += "</ul>";
            listaDiv.innerHTML = html;
        }

        function regresar() {
            window.location.href = 'Default1.aspx';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Registro de Salida</h2>

            <div class="form-group">
                <label for="txtID">ID Alumno:</label>
                <asp:TextBox ID="txtID" runat="server" MaxLength="8" />
            </div>

            <div class="form-group">
                <label for="txtCodigo">Código Objeto:</label>
                <asp:TextBox ID="txtCodigo" runat="server" MaxLength="17" />
            </div>

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Salida" CssClass="btn btn-add"
                OnClientClick="return agregarSalida();" UseSubmitBehavior="false" />

            <asp:Button ID="btnVerificar" runat="server" Text="Verificar Salida" CssClass="btn btn-verify"
                OnClientClick="return verificarSalida();" UseSubmitBehavior="false" />

            <input type="button" value="Regresar" class="btn btn-back" onclick="regresar()" />

            <div id="listaObjetos"></div>
        </div>
    </form>
</body>
</html>
