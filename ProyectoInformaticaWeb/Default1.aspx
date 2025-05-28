<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default1.aspx.cs" Inherits="ProyectoInformaticaWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        /* Estilos del menú retráctil */
        .menu-btn {
            background-color: #333;
            color: white;
            padding: 15px;
            display: block;
            cursor: pointer;
            text-align: center;
            font-size: 18px;
        }

        .menu-content {
            background-color: #444;
            display: none;
            flex-direction: column;
            margin-bottom: 20px;
        }

        .menu-content a {
            padding: 12px 20px;
            color: white;
            text-decoration: none;
            border-top: 1px solid #555;
        }

        .menu-content a:hover {
            background-color: #555;
        }

        #menu-toggle {
            display: none;
        }

        #menu-toggle:checked + .menu-content {
            display: flex;
        }
    </style>

    <!-- Menú retráctil -->
    <label for="menu-toggle" class="menu-btn">☰ Menú</label>
    <input type="checkbox" id="menu-toggle" />
    <nav class="menu-content">
        <!-- <a href="CreacionTipos.aspx">CREACION TIPOS</a>
        <a href="JefesAdmin.aspx">JEFES ADMIN</a>
        <a href="Salida.aspx">SALIDA</a>-->
        <a href="Roles.aspx">MANTENIMIENTO ROLES/Pruebas</a>
        <a href="Supervisor.aspx">MANTENIMIENTO SUPERVISOR</a>
        <a href="Incidencias.aspx">INCIDENCIAS</a>
        <a href="Usuario1.aspx">CREACION USUARIOS</a>
        <a href="Puertas.aspx">MANTENIMIENTO PUERTAS</a>
    </nav>

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Proyecto Desarrollo Web</h1>
            <p class="lead">VISTA ADMIN</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-3" aria-labelledby="generateQrTitle">
                <h2 id="generateQrTitle">Generar QR</h2>
                <p>
                    Genera un código QR personalizado con tu información o enlace favorito desde nuestra herramienta integrada.
                </p>
                <p>
                    <a class="btn btn-default" href="GenerarQR.aspx">Ir a Generar QR &raquo;</a>
                </p>
            </section>
        </div>
    </main>

    <script>
        // Cierra el menú cuando se hace clic en un enlace
        document.querySelectorAll('.menu-content a').forEach(link => {
            link.addEventListener('click', () => {
                document.getElementById('menu-toggle').checked = false;
            });
        });
    </script>

</asp:Content>
