<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreacionTipos.aspx.cs" Inherits="ProyectoInformaticaWeb.CreacionTipos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Creación de Tipos de Rol</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(to right, #6a11cb, #2575fc);
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            background-color: #fff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 0 20px rgba(0,0,0,0.2);
            width: 90%;
            max-width: 800px;
        }

        h2 {
            text-align: center;
            color: #333;
            margin-bottom: 30px;
        }

        .form-group {
            display: flex;
            margin-bottom: 15px;
            gap: 15px;
        }

        .form-group input, .form-group select {
            flex: 1;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 6px;
            font-size: 14px;
        }

        .btn {
            padding: 10px 20px;
            margin-right: 10px;
            border: none;
            border-radius: 6px;
            font-size: 14px;
            cursor: pointer;
            color: white;
        }

        .btn-add { background-color: #38a169; }
        .btn-add:hover { background-color: #2f855a; }

        .btn-edit { background-color: #3182ce; }
        .btn-edit:hover { background-color: #2b6cb0; }

        .btn-delete { background-color: #e53e3e; }
        .btn-delete:hover { background-color: #c53030; }

        .btn-back { background-color: #805ad5; }
        .btn-back:hover { background-color: #6b46c1; }

        table {
            width: 100%;
            margin-top: 25px;
            border-collapse: collapse;
        }

        th, td {
            padding: 10px;
            border: 1px solid #ccc;
            text-align: center;
        }

        th {
            background-color: #f7fafc;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript">
        let roles = [];
        let editIndex = -1;

        function validarCampos(codigo, nombre, estado) {
            if (!/^\d{1,10}$/.test(codigo)) {
                alert("El código debe tener solo números y máximo 10 dígitos.");
                return false;
            }
            if (nombre.trim() === "") {
                alert("El nombre del rol no puede estar vacío.");
                return false;
            }
            if (estado !== "Activo" && estado !== "Inactivo") {
                alert("Estado no válido.");
                return false;
            }
            return true;
        }

        function agregarRol() {
            const codigo = document.getElementById("txtCodigo").value.trim();
            const nombre = document.getElementById("txtNombre").value.trim();
            const estado = document.getElementById("ddlEstado").value;

            if (!validarCampos(codigo, nombre, estado)) return;

            if (editIndex === -1) {
                roles.push({ codigo, nombre, estado });
            } else {
                roles[editIndex] = { codigo, nombre, estado };
                editIndex = -1;
            }

            limpiarFormulario();
            renderizarTabla();
        }

        function editarRol(index) {
            const rol = roles[index];
            document.getElementById("txtCodigo").value = rol.codigo;
            document.getElementById("txtNombre").value = rol.nombre;
            document.getElementById("ddlEstado").value = rol.estado;
            editIndex = index;
        }

        function eliminarRol(index) {
            if (confirm("¿Deseas eliminar este rol?")) {
                roles.splice(index, 1);
                renderizarTabla();
            }
        }

        function limpiarFormulario() {
            document.getElementById("txtCodigo").value = "";
            document.getElementById("txtNombre").value = "";
            document.getElementById("ddlEstado").value = "Activo";
        }

        function renderizarTabla() {
            const tabla = document.getElementById("tablaRoles");
            tabla.innerHTML = `
                <tr>
                    <th>Código</th>
                    <th>Nombre</th>
                    <th>Estado</th>
                    <th>Acciones</th>
                </tr>
            `;

            roles.forEach((rol, index) => {
                tabla.innerHTML += `
                    <tr>
                        <td>${rol.codigo}</td>
                        <td>${rol.nombre}</td>
                        <td>${rol.estado}</td>
                        <td>
                            <button class="btn btn-edit" onclick="editarRol(${index})">Editar</button>
                            <button class="btn btn-delete" onclick="eliminarRol(${index})">Eliminar</button>
                        </td>
                    </tr>
                `;
            });
        }

        function regresar() {
            window.location.href = 'Default1.aspx';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Creación de Tipos de Rol</h2>
            <div class="form-group">
                <input type="text" id="txtCodigo" placeholder="Código del tipo (números, máx 10)" maxlength="10" />
                <input type="text" id="txtNombre" placeholder="Nombre del rol" />
                <select id="ddlEstado">
                    <option value="Activo">Activo</option>
                    <option value="Inactivo">Inactivo</option>
                </select>
            </div>
            <div>
                <button type="button" class="btn btn-add" onclick="agregarRol()">Ingresar</button>
                <button type="button" class="btn btn-back" onclick="regresar()">Volver a Principal</button>
            </div>

            <table id="tablaRoles"></table>
        </div>
    </form>
</body>
</html>

