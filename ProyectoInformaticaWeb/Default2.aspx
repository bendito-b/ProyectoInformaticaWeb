<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoInformaticaWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Proyecto Desarrollo Web</h1>
            <p class="lead">VISTA ALUMNO</p>
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

</asp:Content>