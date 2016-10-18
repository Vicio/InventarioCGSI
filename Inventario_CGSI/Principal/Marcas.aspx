<%@ Page Title="" Language="C#" MasterPageFile="~/Principal/MasterPage.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="Inventario_CGSI.Principal.Marcas" %>
<asp:Content ID="Contenido" ContentPlaceHolderID="contenidoCuerpo" runat="server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
        <!------------------------------------------------AGREGAR NUEVA MARCA--------------------------------------->
            <div id="divAgregarMarca" runat="server" class="divTablas" visible="true">
                <asp:GridView ID="GridViewMarca" runat="server" CssClass="tablas" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceMarca">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                    </Columns>
                    <HeaderStyle CssClass="tablasEncabezados" />                
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceMarca" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_marcas]"></asp:SqlDataSource>
                <br/>
                <label>Agregar Marca:</label>
                <asp:TextBox ID="TxtAgregar_Marca" CssClass="cajasTexto" runat="server"></asp:TextBox><br />
                <table class="tabla_td">
                    <tr>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonAgregar_Marca" Text="Aceptar" CssClass="botones" OnClick="ButtonAgregar_Marca_Click"/>
                        </td>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonCancelar_Marca" Text="Cancelar" CssClass="botones" OnClick="ButtonCancelar_Marca_Click"/>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
