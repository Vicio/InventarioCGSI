<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Principal/MasterPage.Master" CodeBehind="Cuentas.aspx.cs" Inherits="Inventario_CGSI.Principal.Cuentas" %>

<asp:Content ID="Contentido" ContentPlaceHolderID="contenidoCuerpo" runat="Server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <div runat="server" id="divCuenta" class="divSelect">
        <label>Usuarios</label>
        <br />
        <asp:GridView ID="GridViewCuentas" runat="server" CssClass="tablas" HeaderStyle-CssClass="tablasEncabezados" OnRowCommand="GridViewCuentas_RowCommand" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceCuentas">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                <asp:BoundField DataField="Correo Electrónico" HeaderText="Correo Electrónico" SortExpression="Correo Electrónico" />
                <asp:BoundField DataField="Nivel" HeaderText="Nivel" SortExpression="Nivel" />
                <asp:BoundField DataField="Área" HeaderText="Área" SortExpression="Área" />
                <asp:CheckBoxField DataField="Cuenta Activada" HeaderText="Cuenta Activada" SortExpression="Cuenta Activada" />
                <asp:CheckBoxField DataField="Acceso" HeaderText="Acceso" SortExpression="Acceso" />
                <asp:ButtonField ButtonType="Button" Text="Editar" HeaderText="" CommandName="Editar" ControlStyle-CssClass="botonesTablas" />
            </Columns>
            <HeaderStyle CssClass="tablasEncabezados" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceCuentas" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_usuarios]"></asp:SqlDataSource>
        <asp:Button ID="ButtonNuevoUsuario" runat="server" Text="Agregar" CssClass="botones" OnClick="ButtonNuevoUsuario_Click" />
    </div>
    <div runat="server" id="divNewCuenta" class="divTablas" visible="false">
        <label>Nuevo Usuario</label>
        <br />
        <table class="tabla_td">
            <tr>
                <td>
                    <label>ID:</label>
                    <label runat="server" id="labelIDUsuario"></label>

                </td>
            </tr>
            <tr>
                <td class="horizontal">
                    <label>Nombre:</label><br />
                    <asp:TextBox runat="server" ID="txtNombre_usuario" CssClass="cajasTexto"></asp:TextBox>
                </td>
                <td class="horizontal">
                    <label>Área:</label><br />
                    <asp:DropDownList runat="server" ID="DDLArea_usuario" CssClass="cajasTexto">           
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="horizontal">
                    <label>Apellido:</label><br />
                    <asp:TextBox runat="server" ID="txtApellido_usuario" CssClass="cajasTexto"></asp:TextBox>
                </td>
                <td class="horizontal">
                    <label>Nivel:</label><br />
                    <asp:DropDownList runat="server" ID="DDLNivel_usuario" CssClass="cajasTexto">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="horizontal">
                    <label>Correo:</label><br />
                    <asp:TextBox runat="server" ID="txtCorreo_usuario" CssClass="cajasTexto" TextMode="Email"></asp:TextBox>
                </td>
                <td class="horizontal">
                    <asp:Label ID="lbl_error_correo" runat="server" ForeColor="#D64234"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="horizontal">
                    <label>Contraseña:</label><br />
                    <asp:TextBox runat="server" ID="txtHash_usuario" CssClass="cajasTexto" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="horizontal">
                    <label>Activar Cuenta:</label>
                    <asp:CheckBox ID="CheckBoxActivacion" runat="server" />
                </td>                
            </tr>
        </table>
        <table class="tabla_td">
            <tr>
                <td class="horizontal">
                    <asp:Button ID="ButtonAgregar" runat="server" Text="Aceptar" CssClass="botones" OnClick="ButtonAgregar_Click" />
                </td>
                <td class="horizontal">
                    <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CssClass="botones" OnClick="ButtonCancelar_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>