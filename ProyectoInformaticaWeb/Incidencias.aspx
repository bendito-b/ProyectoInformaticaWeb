<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Incidencias.aspx.cs" Inherits="ProyectoInformaticaWeb.Incidencias" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Registro de Incidencias</title>
    <style>
        /* Tu CSS existente */
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

        .form-container { /* No usado en el HTML actual, pero puede ser útil si lo reorganizas */
            background-color: #fff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 0 20px rgba(0,0,0,0.2);
            width: 100%;
            max-width: 500px;
            text-align: center;
            margin-top: 30px;
        }

        .form-group { /* No usado en el HTML actual, pero puede ser útil si lo reorganizas */
            margin-bottom: 15px;
            text-align: left;
        }

        label { /* No usado directamente en el HTML actual, pero puede ser útil */
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"], textarea {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 6px;
            box-sizing: border-box;
            margin-bottom: 10px; /* Añadido para espaciar los inputs */
        }

        textarea {
            height: 100px;
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

        .btn-ingresar {
            background-color: #48bb78;
            color: white;
            max-width: 200px; /* Limita el ancho del botón registrar */
            margin: 10px auto; /* Centra el botón registrar */
        }
        .btn-ingresar:hover { background-color: #38a169; }

        /* Estilos para los nuevos botones de acción */
        .btn-accion {
            background-color: #007bff; /* Azul para Habilitar */
            color: white;
            padding: 8px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin: 5px; /* Espaciado entre botones */
        }
        .btn-accion:hover { background-color: #0056b3; }

        .btn-deshabilitar {
            background-color: #dc3545; /* Rojo para Deshabilitar */
        }
        .btn-deshabilitar:hover { background-color: #c82333; }

        .btn-regresar {
            background-color: #6c757d; /* Gris para Regresar */
            color: white;
            margin-top: 30px; /* Más espacio arriba del botón regresar */
            width: auto; /* Ancho automático para el botón de regresar */
            padding: 12px 25px;
            border: none;
            border-radius: 6px;
            font-size: 16px;
            cursor: pointer;
        }
        .btn-regresar:hover { background-color: #5a6268; }

        .tabla-inci {
            margin-top: 30px;
            background-color: #fff;
            padding: 20px;
            border-radius: 12px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            width: 90%;
            max-width: 900px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: center;
            vertical-align: middle; /* Centra el contenido verticalmente */
        }

        th {
            background-color: #0072ff;
            color: white;
        }

        /* Estilo para el CheckBox dentro del GridView */
        .gv-checkbox {
            margin: 0 auto; /* Centra el checkbox */
            display: block; /* Asegura que tome el ancho completo y permita margin auto */
        }
    </style>
</head>
<body>
  <form id="form1" runat="server">
    <h2>Registrar Incidencia</h2>
    <asp:TextBox ID="txtTipo" runat="server" Placeholder="Tipo de incidencia" /><br />
    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4" Placeholder="Descripción" /><br />
    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CssClass="btn btn-ingresar" /><br />
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Bold="true" /><br /><br />

    <div class="tabla-inci">
        <asp:GridView ID="gvIncidencias" runat="server" AutoGenerateColumns="false"
            DataKeyNames="id_incidencia"
            OnRowDeleting="gvIncidencias_RowDeleting"
            OnRowEditing="gvIncidencias_RowEditing"
            OnRowCancelingEdit="gvIncidencias_RowCancelingEdit"
            OnRowUpdating="gvIncidencias_RowUpdating"
            OnSelectedIndexChanged="gvIncidencias_SelectedIndexChanged"> <%-- ¡Importante! Agregamos este evento aquí --%>

          <Columns>
            <asp:BoundField HeaderText="ID" DataField="id_incidencia" ReadOnly="true" />
            <asp:BoundField HeaderText="Fecha / Hora" DataField="fecha_hora" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />

            <%-- Modificamos los BoundField existentes para Tipo y Descripción a TemplateField
                 para que la edición funcione correctamente con TextBox. --%>
            <asp:TemplateField HeaderText="Tipo">
                <ItemTemplate>
                    <asp:Label ID="lblTipo" runat="server" Text='<%# Eval("tipo_incidencia") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditTipo" runat="server" Text='<%# Bind("tipo_incidencia") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción">
                <ItemTemplate>
                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("descripcion") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditDescripcion" runat="server" Text='<%# Bind("descripcion") %>' TextMode="MultiLine" Rows="4" />
                </EditItemTemplate>
            </asp:TemplateField>

            <%-- ¡NUEVA! Columna para mostrar el estado con un CheckBox --%>
           <asp:TemplateField HeaderText="Estado">
    <ItemTemplate>
        <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# Eval("Estado") != DBNull.Value ? Convert.ToBoolean(Eval("Estado")) : false %>' Enabled="false" CssClass="gv-checkbox" />
    </ItemTemplate>
    <EditItemTemplate>
        <%-- Opcional: Si quieres poder cambiar el estado desde el modo edición del GridView,
             deja este CheckBox. --%>
        <asp:CheckBox ID="chkEstadoEdit" runat="server" Checked='<%# Eval("Estado") != DBNull.Value ? Convert.ToBoolean(Eval("Estado")) : false %>' CssClass="gv-checkbox" />
    </EditItemTemplate>
</asp:TemplateField>

            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
            <%-- ¡NUEVA Y CRUCIAL! Botón para seleccionar la fila. Es vital para Habilitar/Deshabilitar --%>
            <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
          </Columns>
        </asp:GridView>

        <div style="margin-top: 20px;">
            <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar Incidencia" OnClick="btnHabilitar_Click" CssClass="btn-accion" />
            <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar Incidencia" OnClick="btnDeshabilitar_Click" CssClass="btn-accion btn-deshabilitar" />
        </div>
    </div>

    <%-- Botón de Regresar (fuera del div de la tabla para que tenga su propio espacio) --%>
    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" CssClass="btn-regresar" />

  </form>
</body>
</html>