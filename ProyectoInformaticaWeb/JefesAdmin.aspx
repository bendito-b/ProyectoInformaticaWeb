<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JefesAdmin.aspx.cs"
    Inherits="ProyectoInformaticaWeb.JefesAdmin" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <div class="card p-4 mb-4 shadow-sm">
    <h2 class="mb-3">Administración de Supervisores</h2>

    <!-- Botón volver -->
    <asp:Button ID="btnVolver" runat="server" Text="← Volver a Principal"
                CssClass="btn btn-outline-secondary mb-3"
                OnClick="btnVolver_Click" />

    <!-- Tabla de supervisores -->
    <asp:Panel ID="pnlContent" runat="server">
      <asp:GridView ID="gvJefes" runat="server"
          AutoGenerateColumns="False"
          DataKeyNames="SupervisorID"
          CssClass="table table-bordered table-striped"
          OnRowEditing="gvJefes_RowEditing"
          OnRowCancelingEdit="gvJefes_RowCancelingEdit"
          OnRowUpdating="gvJefes_RowUpdating"
          OnRowDeleting="gvJefes_RowDeleting"
          OnRowCommand="gvJefes_RowCommand"
          ShowFooter="True">

        <Columns>
          <asp:BoundField DataField="SupervisorID" HeaderText="ID" ReadOnly="True" />
          <asp:BoundField DataField="Nombre"       HeaderText="Nombre" />
          <asp:BoundField DataField="Email"        HeaderText="Email" />
          <asp:BoundField DataField="Estacion"     HeaderText="Estación" />
          <asp:BoundField DataField="Estado"       HeaderText="Estado" />

          <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
              <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Edit"
                          CssClass="btn btn-sm btn-primary me-1" />
              <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Delete"
                          CssClass="btn btn-sm btn-danger" />
            </ItemTemplate>

            <EditItemTemplate>
              <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CommandName="Update"
                          CssClass="btn btn-sm btn-success me-1" />
              <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CommandName="Cancel"
                          CssClass="btn btn-sm btn-secondary" />
            </EditItemTemplate>

            <FooterTemplate>
              <asp:TextBox ID="txtNombreNew"   runat="server" CssClass="form-control mb-1" Placeholder="Nombre" />
              <asp:TextBox ID="txtEmailNew"    runat="server" CssClass="form-control mb-1" Placeholder="Email" />
              <asp:TextBox ID="txtEstacionNew" runat="server" CssClass="form-control mb-1" Placeholder="Estación" />
              <asp:TextBox ID="txtEstadoNew"   runat="server" CssClass="form-control mb-2" Placeholder="Estado" />
              <asp:Button  ID="btnInsertar"    runat="server" Text="Insertar" CommandName="Insert"
                           CssClass="btn btn-sm btn-success" />
            </FooterTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </asp:Panel>
  </div>
</asp:Content>
