<%@ Page Title="" Language="C#" MasterPageFile="~/Principal/MasterPage.Master" AutoEventWireup="true" CodeBehind="Tipos.aspx.cs" Inherits="Inventario_CGSI.Principal.Tipos" %>
<asp:Content ID="Contenido" ContentPlaceHolderID="contenidoCuerpo" runat="server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
        <!------------------------------------------------AGREGAR NUEVO TIPO--------------------------------------->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="divAgregarTipo" runat="server" class="divTablas">
                <asp:GridView ID="GridViewTipo" runat="server" CssClass="tablas" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceTipo">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                    </Columns>
                    <HeaderStyle CssClass="tablasEncabezados" />                
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceTipo" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_tipos]"></asp:SqlDataSource>
                <br/>
                <label>Agregar Tipo:</label>
                <asp:TextBox ID="TxtAgregar_Tipo" CssClass="cajasTexto" runat="server"></asp:TextBox><br />
                <table class="tabla_td">
                    <tr>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonAgregar_Tipo" Text="Aceptar" CssClass="botones" OnClick="ButtonAgregar_Tipo_Click"/>
                        </td>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonCancelar_Tipo" Text="Cancelar" CssClass="botones" OnClick="ButtonCancelar_Tipo_Click"/>
                        </td>
                    </tr>
                </table>        
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
