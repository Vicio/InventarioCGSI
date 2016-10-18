<%@ Page Title="" Language="C#" MasterPageFile="~/Principal/MasterPage.Master" AutoEventWireup="true" CodeBehind="Campi.aspx.cs" Inherits="Inventario_CGSI.Principal.Campi" %>
<asp:Content ID="Contenido" ContentPlaceHolderID="contenidoCuerpo" runat="server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
        <asp:SqlDataSource ID="SqlDataSourceCampus" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_campi]"></asp:SqlDataSource>
        <!------------------------------------------------AGREGAR NUEVO CAMPUS--------------------------------------->
            <div id="divAgregarCampus" runat="server" class="divTablas" visible="true">
                <asp:GridView ID="GridViewCampus" runat="server" CssClass="tablas" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceCampus">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Campus" HeaderText="Campus" SortExpression="Campus" />
                    </Columns>
                    <HeaderStyle CssClass="tablasEncabezados" />                
                </asp:GridView><br/>
                <label>Agregar Campus:</label>
                <asp:TextBox ID="TxtAgregar_Campus" CssClass="cajasTexto" runat="server"></asp:TextBox><br />
                <table class="tabla_td">
                    <tr>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonAgregar_Campus" Text="Aceptar" CssClass="botones" OnClick="ButtonAgregar_Campus_Click"/>
                        </td>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="ButtonCancelar_Campus" Text="Cancelar" CssClass="botones" OnClick="ButtonCancelar_Campus_Click"/>
                        </td>
                    </tr>

                </table>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
