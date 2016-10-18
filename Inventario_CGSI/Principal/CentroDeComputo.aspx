<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Principal/MasterPage.Master" CodeBehind="CentroDeComputo.aspx.cs" Inherits="Inventario_CGSI.Principal.CentroDeComputo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Contentido" ContentPlaceHolderID="contenidoCuerpo" runat="Server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="panelActualizacion" runat="server">
        <ContentTemplate>
            <!-----------------------------------------------------TABLA ARTÍCULOS------------------------------------------------->
           
             <div id="divArticulos" runat="server" class="divTablas">
                <label>Equipo</label><br />
                <asp:TextBox runat="server" ID="TextBoxBusqueda" CssClass="cajasTexto"></asp:TextBox>
                <asp:Button runat="server" ID="ButtonBusqueda" CssClass="botones" Text="Buscar" OnClick="ButtonBusqueda_Click" />
                <asp:Button runat="server" ID="ButtonExportarExcel" CssClass="botones" Text="Exportar a Excel" OnClick="ButtonExportarExcel_Click" />
                <asp:GridView CssClass="tablas" ID="GridViewArticulos" runat="server" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ID" DataSourceID="SqlDataSourceEquipoComputo" OnRowCommand="GridViewArticulos_RowCommand" OnSorting="GridViewArticulos_Sorting">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                        <asp:BoundField DataField="Tamaño" HeaderText="Tamaño" SortExpression="Tamaño" />
                        <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus" />
                        <asp:BoundField DataField="NoSerie" HeaderText="No. Serie" SortExpression="No. Serie" />
                        <asp:TemplateField HeaderText="Baja">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="ChkBaja_Articulos" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ControlStyle-CssClass="botonesTablas" ButtonType="Button" HeaderText="" Text="Seleccionar" CommandName="DetalleArticulo"/>
                        <asp:ButtonField ControlStyle-CssClass="botonesTablas" ButtonType="Button" HeaderText="" Text="Modificar" CommandName="ModificarArticulo"/>
                    </Columns>
                    <HeaderStyle CssClass="tablasEncabezados" />
                </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSourceEquipoComputo" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT [ID], [Marca], [Modelo], [Tipo], [Tamaño], [Estatus], [NoSerie] FROM [vista_articulos] WHERE ([Clasificación] = 'CENTRO DE COMPUTO')">
                </asp:SqlDataSource>
                <table class="tabla_td">
                    <tr>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="AgregarNuevoArticulo" CssClass="botones" Text="Agregar" OnClick="AgregarNuevoArticulo_Click" />
                        </td>
                        <td class="horizontal">
                            <asp:Button runat="server" ID="BajaArticulo" CssClass="botones" Text="Dar de Baja" OnClick="BajaArticulo_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divAgregarArticulos" runat="server" class="divTablas" visible="false">
                <asp:Label ID="lbl_id_articulo" runat="server" Text=""></asp:Label>
                <table>
                    <tr>
                        <td class="horizontal">
                            <table class="tabla_td">
                                <tr>
                                    <td class="horizontal">
                                        <label>
                                        No. Serie:</label><br />
                                        <asp:TextBox ID="TxtNoSerie" runat="server" CssClass="cajasTexto"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        <label>
                                        Pertenece a:</label><br />
                                        <asp:DropDownList ID="DDLPerteneceADispositivo" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="cajasTexto" DataSourceID="SqlDataSourceDispositivosPerteneceA" DataTextField="Parte_PerteneceA" DataValueField="ID">
                                            <asp:ListItem Text="" Value="NULL"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceDispositivosPerteneceA" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_articulos_perteneceA] WHERE ([Clasificación] = @Clasificación)">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="CENTRO DE COMPUTO" Name="Clasificación" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td class="horizontal">
                                        <label>
                                        Tipo:</label><br />
                                        <asp:DropDownList ID="DDLTipo" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="cajasTexto" DataSourceID="Tipo" DataTextField="Tipo" DataValueField="ID" OnSelectedIndexChanged="DDLTipo_SelectedIndexChanged">
                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="Tipo" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_tipos]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        <label>
                                        Marca:</label><br />
                                        <asp:DropDownList ID="DDLMarca" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="cajasTexto" DataSourceID="Marca" DataTextField="Marca" DataValueField="ID" OnSelectedIndexChanged="DDLMarca_SelectedIndexChanged">
                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="Marca" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_marcas]"></asp:SqlDataSource>
                                    </td>
                                    <td class="horizontal">
                                        <label>
                                        Modelo:</label><br />
                                        <asp:DropDownList ID="DDLModelo" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="cajasTexto" DataSourceID="Modelo" DataTextField="Modelo" DataValueField="ID" OnSelectedIndexChanged="DDLModelo_SelectedIndexChanged">
                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="Modelo" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_modelos]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        <label>
                                        Estado:</label><br />
                                        <asp:DropDownList ID="DDLEstado" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="cajasTexto" DataSourceID="Estatus" DataTextField="Estatus" DataValueField="ID" OnSelectedIndexChanged="DDLEstado_SelectedIndexChanged">
                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="Estatus" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_estatus]"></asp:SqlDataSource>
                                    </td>
                                    <td class="horizontal">
                                        <label>
                                        Medidas:</label><br />
                                        <asp:DropDownList ID="DDLTamano" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="cajasTexto" DataSourceID="Tamanos" DataTextField="Tamaño" DataValueField="ID" OnSelectedIndexChanged="DDLTamano_SelectedIndexChanged">
                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="Tamanos" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_tamanos]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="horizontal">
                            <table class="tabla_td">
                                <tr>
                                    <td class="horizontal">
                                        <asp:Image ID="ImagenArticulo" runat="server" Visible="false" CssClass="imagen_detalle"/><br />
                                        <asp:Label runat="server" ID="lbl_imagen_art_actual" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        <label>
                                        Descripción:</label><br />
                                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="cajasTexto" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <div id="divSlideImagen" runat="server">
                                             <table runat="server">
                                                <tr>
                                                    <td>
                                                        <asp:Image runat="server" ID="Imagen_slide_1" CssClass="img1y2" Visible="false" /></td>
                                                    <td>
                                                        <asp:Image runat="server" ID="Imagen_slide_2" CssClass="img3" Visible="false"/></td>
                                                    <td>
                                                        <asp:Image runat="server" ID="Imagen_slide_3" CssClass="img1y2" Visible="false"/></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button runat="server" ID="BtnAnterior" Text="Anterior" OnClick="BtnAnterior_Click" CssClass="botones"/>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lbl_imagen" Text="Selecciona una imagen"></asp:Label>

                                                    </td>
                                                    <td>
                                                        <asp:Button runat="server" ID="BtnSiguiente" Text="Siguiente" OnClick="BtnSiguiente_Click" CssClass="botones" />

                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                        </td>
                    </tr>
                </table>
                <table class="tabla_td">
                    <tr>
                        <td class="horizontal">
                            <asp:Button ID="ButtonAgregarArticulos" runat="server" CssClass="botones" OnClick="ButtonAgregarArticulos_Click" Text="Aceptar" />
                        </td>
                        <td class="horizontal">
                            <asp:Button ID="ButtonACancelar" runat="server" CssClass="botones" OnClick="ButtonACancelar_Click" Text="Cancelar" />
                        </td>
                        <td class="horizontal">
                            <asp:Label ID="LblExitoA_agregar" runat="server" ForeColor="#D64234"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonExportarExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
