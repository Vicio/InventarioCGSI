<%@ Page Title="" Language="C#" MasterPageFile="~/Principal/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ubicaciones.aspx.cs" Inherits="Inventario_CGSI.Principal.Ubicaciones" %>
<asp:Content ID="Contenido" ContentPlaceHolderID="contenidoCuerpo" runat="server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:SqlDataSource ID="SqlDataSourceUbicacion" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_ubicaciones]"></asp:SqlDataSource>
            <!------------------------------------------------AGREGAR NUEVO UBICACION--------------------------------------->
            <div id="divAgregarUbicacion" runat="server" class="divTablas" visible="true">
                <asp:GridView ID="GridViewUbicacion" runat="server" CssClass="tablas" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceUbicacion">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Ubicación" HeaderText="Ubicación" SortExpression="Ubicación" />
                    </Columns>
                    <HeaderStyle CssClass="tablasEncabezados" />                
                </asp:GridView><br/>
                <label>Agregar Ubicación:</label>
                <asp:TextBox ID="TxtAgregar_Ubicacion" CssClass="cajasTexto" runat="server"></asp:TextBox><br />
                <table class="tabla_td">
                    <tr><td class="horizontal">
                 <asp:Button runat="server" ID="ButtonAgregar_Ubicacion" Text="Aceptar" CssClass="botones" OnClick="ButtonAgregar_Ubicacion_Click"/>
                        </td><td class="horizontal">
                <asp:Button runat="server" ID="ButtonCancelar_Ubicacion" Text="Cancelar" CssClass="botones" OnClick="ButtonCancelar_Ubicacion_Click"/>
            </td></tr></table>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
