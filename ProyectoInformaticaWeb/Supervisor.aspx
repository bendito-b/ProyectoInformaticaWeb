<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supervisor.aspx.cs" Inherits="ProyectoInformaticaWeb.Supervisor" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Supervisores</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.7.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container py-5">
            <!-- Formulario -->
            <div class="card shadow mb-4">
                <div class="card-header bg-primary text-white text-center">
                    <h2>Agregar Supervisor</h2>
                </div>
                <div class="card-body">
                    <div class="row g-3">
                        <div class="col-md-6">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" />
                        </div>
                        <div class="col-md-6">
                            <label for="txtCorreo" class="form-label">Correo</label>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" MaxLength="100" TextMode="Email" />
                        </div>
                        <div class="col-md-6">
                            <label for="txtEstacionId" class="form-label">Estación ID</label>
                            <asp:TextBox ID="txtEstacionId" runat="server" CssClass="form-control" TextMode="Number" />
                        </div>
                        <div class="col-md-6">
                            <label for="ddlEstado" class="form-label">Estado</label>
                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Activo" Value="1" />
                                <asp:ListItem Text="Inactivo" Value="0" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="mt-4 d-flex justify-content-between flex-wrap gap-2">
                        <asp:Button ID="btnAgregar" runat="server" Text="✔ Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnReporte" runat="server" Text="📄 Reporte" CssClass="btn btn-primary" OnClick="btnReporte_Click" />
                        <asp:Button ID="btnRegresar" runat="server" Text="↩ Regresar" CssClass="btn btn-danger" OnClick="btnRegresar_Click" />
                    </div>

                    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 fw-bold d-block" />
                </div>
            </div>

            <!-- Tabla -->
            <div class="card shadow-sm">
                <div class="card-header bg-secondary text-white text-center">
                    <h3>Supervisores Registrados</h3>
                </div>
                <div class="card-body">
                    <asp:GridView ID="gvSupervisores" runat="server" CssClass="table table-striped table-hover text-center"
                        AutoGenerateColumns="False" DataKeyNames="id_supervisor"
                        OnRowEditing="gvSupervisores_RowEditing"
                        OnRowUpdating="gvSupervisores_RowUpdating"
                        OnRowCancelingEdit="gvSupervisores_RowCancelingEdit"
                        OnRowCommand="gvSupervisores_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="id_supervisor" ReadOnly="True" />
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate><%# Eval("nombre") %></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="form-control" Text='<%# Eval("nombre") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Correo">
                                <ItemTemplate><%# Eval("correo") %></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCorreoEdit" runat="server" CssClass="form-control" Text='<%# Eval("correo") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estación ID">
                                <ItemTemplate><%# Eval("estacion_id") %></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEstacionEdit" runat="server" CssClass="form-control" Text='<%# Eval("estacion_id") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate><%# ObtenerEstado(Eval("estado")) %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="✏️ Editar" UpdateText="💾 Guardar" CancelText="❌ Cancelar" />
                            <asp:TemplateField HeaderText="Acción">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-outline-warning"
                                        CommandName='<%# Convert.ToInt32(Eval("estado")) == 1 ? "Deshabilitar" : "Habilitar" %>'
                                        CommandArgument='<%# Container.DataItemIndex %>'>
                                        <%# Convert.ToInt32(Eval("estado")) == 1 ? "🚫 Desactivar" : "✅ Activar" %>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
