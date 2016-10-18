<%@ Page Title="" Language="C#" MasterPageFile="~/Principal/MasterPage.Master" AutoEventWireup="true" CodeBehind="Adscripciones.aspx.cs" Inherits="Inventario_CGSI.Principal.Adscripciones" %>
<asp:Content ID="Contenido" ContentPlaceHolderID="contenidoCuerpo" runat="server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
        <!------------------------------------------------AGREGAR NUEVO ADSCRIPCION--------------------------------------->
            <asp:SqlDataSource ID="SqlDataSourceAdscrip" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_adscripciones]"></asp:SqlDataSource>
            <div id="divAgregarAdscripcion" runat="server" class="divTablas" visible="true">
                <asp:GridView ID="GridViewAdscripcion" runat="server" CssClass="tablas" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceAdscrip">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Adscripción" HeaderText="Adscripción" SortExpression="Adscripción" />
                    </Columns>
                    <HeaderStyle CssClass="tablasEncabezados" />                
                </asp:GridView><br/>
                <label>Agregar Adscripcion:</label>
                <asp:TextBox ID="TxtAgregar_Adscripcion" CssClass="cajasTexto" runat="server"></asp:TextBox><br />
                <table class="tabla_td">
                    <tr><td class="horizontal">
                 <asp:Button runat="server" ID="ButtonAgregar_Adscripcion" Text="Aceptar" CssClass="botones" OnClick="ButtonAgregar_Adscripcion_Click"/>
                        </td><td class="horizontal">
                <asp:Button runat="server" ID="ButtonCancelar_Adscripcion" Text="Cancelar" CssClass="botones" OnClick="ButtonCancelar_Adscripcion_Click"/>
            </td></tr></table>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
