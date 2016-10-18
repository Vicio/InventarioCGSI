<%@ Page Title="" Language="C#" MasterPageFile="~/Principal/MasterPage.Master" AutoEventWireup="true" CodeBehind="Modelos.aspx.cs" Inherits="Inventario_CGSI.Principal.Modelos" %>
<asp:Content ID="Contenido" ContentPlaceHolderID="contenidoCuerpo" runat="server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <!------------------------------------------------AGREGAR NUEVO MODELO--------------------------------------->
            <div id="divAgregarModelo" runat="server" class="divTablas" visible="true">
                <asp:GridView ID="GridViewModelo" runat="server" CssClass="tablas" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceModel">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
                    </Columns>
                    <HeaderStyle CssClass="tablasEncabezados" />                
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceModel" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_modelos]"></asp:SqlDataSource>
                <br/>
                <label>Agregar Modelo:</label>
                <asp:TextBox ID="TxtAgregar_Modelo" CssClass="cajasTexto" runat="server"></asp:TextBox><br />
                <table class="tabla_td">
                    <tr>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonAgregar_Modelo" Text="Aceptar" CssClass="botones" OnClick="ButtonAgregar_Modelo_Click"/>
                        </td>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonCancelar_Modelo" Text="Cancelar" CssClass="botones" OnClick="ButtonCancelar_Modelo_Click"/>
                        </td>
                    </tr>
                </table>        
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
