<%@ Page Title="" Language="C#" MasterPageFile="~/Principal/MasterPage.Master" AutoEventWireup="true" CodeBehind="Tamanos.aspx.cs" Inherits="Inventario_CGSI.Principal.Tamanos" %>
<asp:Content ID="Contenido" ContentPlaceHolderID="contenidoCuerpo" runat="server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <!------------------------------------------------AGREGAR NUEVO TAMANO--------------------------------------->
            <div id="divAgregarTamano" runat="server" class="divTablas" visible="true">
                <asp:GridView ID="GridViewTamano" runat="server" CssClass="tablas" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceTam">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Tamaño" HeaderText="Tamaño" SortExpression="Tamaño" />
                    </Columns>
                    <HeaderStyle CssClass="tablasEncabezados" />                
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceTam" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_tamanos]"></asp:SqlDataSource>
                <br/>
                <label>Agregar Medida:</label>
                <asp:TextBox ID="TxtAgregar_Tamano" CssClass="cajasTexto" runat="server"></asp:TextBox><br />
                <table class="tabla_td">
                    <tr>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonAgregar_Tamano" Text="Aceptar" CssClass="botones" OnClick="ButtonAgregar_Tamano_Click"/>
                        </td>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonCancelar_Tamano" Text="Cancelar" CssClass="botones" OnClick="ButtonCancelar_Tamano_Click"/>
                        </td>
                    </tr>
                </table>        
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
