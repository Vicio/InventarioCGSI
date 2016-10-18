<%@ Page Title="" Language="C#" MasterPageFile="~/Principal/MasterPage.Master" AutoEventWireup="true" CodeBehind="Estados.aspx.cs" Inherits="Inventario_CGSI.Principal.Estados" %>
<asp:Content ID="Contenido" ContentPlaceHolderID="contenidoCuerpo" runat="server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
        <!------------------------------------------------AGREGAR NUEVO ESTADO--------------------------------------->
            <div id="divAgregarEstado" runat="server" class="divTablas" visible="true">
                <asp:GridView ID="GridViewEstado" runat="server" CssClass="tablas" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceEstado">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus" />
                    </Columns>
                    <HeaderStyle CssClass="tablasEncabezados" />                
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceEstado" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_estatus]"></asp:SqlDataSource>
                <br/>
                <label>Agregar Estado:</label>
                <asp:TextBox ID="TxtAgregar_Estado" CssClass="cajasTexto" runat="server"></asp:TextBox><br />
                <table class="tabla_td">
                    <tr>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonAgregar_Estado" Text="Aceptar" CssClass="botones" OnClick="ButtonAgregar_Estado_Click"/>
                        </td>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonCancelar_Estado" Text="Cancelar" CssClass="botones" OnClick="ButtonCancelar_Estado_Click"/>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
