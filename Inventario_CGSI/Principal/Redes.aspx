<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Principal/MasterPage.Master" CodeBehind="Redes.aspx.cs" Inherits="Inventario_CGSI.Principal.Inventario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Contentido" ContentPlaceHolderID="contenidoCuerpo" runat="Server">
    <asp:ScriptManager ID="scriptActualizacion" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <div runat="server" id="divDDLTabla" class="divSelect" visible="true">
        <asp:DropDownList AppendDataBoundItems="true" ID="DDLTabla" runat="server" CssClass="cajasTexto" AutoPostBack="True" OnSelectedIndexChanged="DDLTabla_SelectedIndexChanged">
            <asp:ListItem Value="M">Material</asp:ListItem>
            <asp:ListItem Value="H">Herramientas</asp:ListItem>
        </asp:DropDownList>
    </div>
    <!----------------------------------------------------------------TABLA PARTES----------------------------------------------->
    <div id="divPartes" runat="server" class="divTablas" visible="true">
        Material<br />
        <asp:TextBox runat="server" ID="TextBoxBusqueda" CssClass="cajasTexto"></asp:TextBox>
        <asp:Button runat="server" ID="ButtonBusqueda" CssClass="botones" Text="Buscar" OnClick="ButtonBusqueda_Click" />
        <asp:Button runat="server" ID="ButtonExportarExcel" CssClass="botones" Text="Exportar a Excel" OnClick="ButtonExportarExcel_Click" />
        <asp:GridView CssClass="tablas" ID="GridViewPartes" runat="server" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" AllowSorting="True" DataSourceID="SqlDataSourceMaterialRedes" DataKeyNames="ID" OnRowCommand="GridViewPartes_RowCommand" OnSorting="GridViewPartes_Sorting">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Clasificación" HeaderText="Clasificación" SortExpression="Clasificación" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                <asp:BoundField DataField="Tamaño" HeaderText="Tamaño" SortExpression="Tamaño" />
                <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus" />
                <asp:BoundField DataField="NoSerie" HeaderText="NoSerie" SortExpression="NoSerie" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                <asp:TemplateField HeaderText="Baja">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="ChkBaja_Partes" />
                            </ItemTemplate>
                        </asp:TemplateField>
                <asp:ButtonField ControlStyle-CssClass="botonesTablas" ButtonType="Button" HeaderText="" Text="Seleccionar" CommandName="DetalleParte" />
                <asp:ButtonField ControlStyle-CssClass="botonesTablas" ButtonType="Button" HeaderText="" Text="Modificar" CommandName="ModificarParte" />
            <asp:TemplateField HeaderText="Componentes">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="ChkComponentes" />
                            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="tablasEncabezados" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceMaterialRedes" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_partes] WHERE ([Clasificación] = @Clasificación)">
            <SelectParameters>
                <asp:Parameter DefaultValue="REDES" Name="Clasificación" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <table class="tabla_td">
            <tr>
                <td class="horizontal">
                    <asp:Button ID="ButtonAgregarPartes" runat="server" Text="Agregar" CssClass="botones" OnClick="ButtonAgregarPartes_Click" />
                </td>
                <td class="horizontal">
                    <asp:Button runat="server" ID="BajaPartes" CssClass="botones" Text="Dar de Baja" OnClick="BajaPartes_Click" />
                </td>
                <td class="horizontal">
                    <table>
                        <tr>
                            <td class="horizontal">
                                <asp:Button runat="server" ID="AgregarComponentes" CssClass="botones" Text="Agregar Componente" OnClick="AgregarComponentes_Click" />
                            </td>
                            <td class="horizontal">
                                <asp:DropDownList ID="DDLPartesDispositivos" runat="server" DataSourceID="SqlDataSourceDispositivosPerteneceA" DataTextField="Dispositivo_PerteneceA" DataValueField="ID">
                                    <asp:ListItem Value="NULL" Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>    </div>
    <!----------------------------------------------------TABLA ARTICULOS------------------------------------------------------------->
    <div id="divArticulos" runat="server" class="divTablas" visible="false">
        Herramientas<br />
        <asp:TextBox runat="server" ID="TextBoxBusquedaHerramientas" CssClass="cajasTexto"></asp:TextBox>
        <asp:Button runat="server" ID="ButtonBusquedaHerramientas" CssClass="botones" Text="Buscar" OnClick="ButtonBusqueda_Click" />
        <asp:Button runat="server" ID="ButtonExportarHerramientasExcel" CssClass="botones" Text="Exportar a Excel" OnClick="ButtonExportarExcel_Click" />
        <asp:GridView CssClass="tablas" ID="GridViewArticulos" runat="server" HeaderStyle-CssClass="tablasEncabezados" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ID" DataSourceID="SqlDataSourceHerramientasRedes" OnRowCommand="GridViewArticulos_RowCommand" OnSorting="GridViewArticulos_Sorting">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Clasificación" HeaderText="Clasificación" SortExpression="Clasificación" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                <asp:BoundField DataField="Tamaño" HeaderText="Tamaño" SortExpression="Tamaño" />
                <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus" />
                <asp:BoundField DataField="NoSerie" HeaderText="NoSerie" SortExpression="NoSerie" />
                <asp:TemplateField HeaderText="Baja">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="ChkBaja_Articulos" />
                            </ItemTemplate>
                        </asp:TemplateField>
                <asp:ButtonField ControlStyle-CssClass="botonesTablas" ButtonType="Button" HeaderText="" Text="Seleccionar" CommandName="DetalleArticulo" />
                <asp:ButtonField ControlStyle-CssClass="botonesTablas" ButtonType="Button" HeaderText="" Text="Modificar" CommandName="ModificarArticulo" />
            </Columns>
            <HeaderStyle CssClass="tablasEncabezados" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceHerramientasRedes" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_articulos] WHERE ([Clasificación] = @Clasificación)">
            <SelectParameters>
                <asp:Parameter DefaultValue="REDES" Name="Clasificación" Type="String" />
            </SelectParameters>
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
        </table>    </div>

    <!--------------------------------------ARTÍCULOS---------------------------------------------------------------------->
            <div runat="server" id="divAgregarArticulos" class="divTablas" visible="false">
                <asp:Label runat="server" ID="lbl_id_articulo" Text=""></asp:Label>
                <table>
                    <tr>
                        <td class="horizontal">
                            <table class="tabla_td">
                                <tr>
                                    <td class="horizontal">
                                        <label>No. Serie:</label><br />
                                        <asp:TextBox ID="TxtNoSerie" runat="server" CssClass="cajasTexto"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    
                                    <td class="horizontal">
                                        <label>Pertenece a:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="True" runat="server" ID="DDLPerteneceADispositivo" CssClass="cajasTexto" DataSourceID="SqlDataSourceDispositivosPerteneceA" DataTextField="Dispositivo_PerteneceA" DataValueField="ID">
                                            <asp:ListItem Value="NULL" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceDispositivosPerteneceA" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_dispositivos_perteneceA] WHERE Clasificación='REDES'"></asp:SqlDataSource>
                                    </td>
                                    <td class="horizontal">
                                        <label>Tipo:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="true" ID="DDLTipo" runat="server" CssClass="cajasTexto" DataSourceID="SqlDataSourceTipo" DataTextField="Tipo" DataValueField="ID" OnSelectedIndexChanged="DDLTipo_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        <label>Marca:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="true" ID="DDLMarca" runat="server" CssClass="cajasTexto" DataSourceID="SqlDataSourceMarca" DataTextField="Marca" DataValueField="ID" OnSelectedIndexChanged="DDLMarca_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="horizontal">
                                        <label>Modelo:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="true" ID="DDLModelo" runat="server" CssClass="cajasTexto" DataSourceID="SqlDataSourceModel" DataTextField="Modelo" DataValueField="ID" OnSelectedIndexChanged="DDLModelo_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        <label>Estado:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="true" ID="DDLEstado" runat="server" CssClass="cajasTexto" DataSourceID="SqlDataSourceEstado" DataTextField="Estatus" DataValueField="ID" OnSelectedIndexChanged="DDLEstado_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="horizontal">
                                        <label>Medidas:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="true" ID="DDLTamano" runat="server" CssClass="cajasTexto" DataSourceID="SqlDataSourceTam" DataTextField="Tamaño" DataValueField="ID" OnSelectedIndexChanged="DDLTamano_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="horizontal">
                            <table class="tabla_td">
                                <tr>
                                    <td class="horizontal">
                                        <asp:Image runat="server" ID="ImagenArticulo" Visible="false" CssClass="imagen_detalle"/><br />
                                        <asp:Label runat="server" ID="lbl_imagen_art_actual" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        <label>Descripción:</label><br />
                                        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="cajasTexto" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div id="slider" runat="server">
                                            <table class="tablaImagenes">
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
                <table class="tabla_td">
                    <tr>
                        <td class="horizontal">
                            <asp:Button ID="ButtonAgregarArticulos" runat="server" Text="Aceptar" CssClass="botones" OnClick="ButtonAgregarArticulos_Click" />
                        </td>
                        <td class="horizontal">
                            <asp:Button ID="ButtonACancelar" runat="server" Text="Cancelar" CssClass="botones" OnClick="ButtonACancelar_Click" />
                        </td>
                        <td class="horizontal">
                            <asp:Label ID="LblExitoA_agregar" runat="server" ForeColor="#D64234"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <!-------------------------------------------------PARTES---------------------------------------------------------------->
            <div runat="server" id="divAgregarPartes" class="divTablas" visible="false">
                <asp:Label runat="server" ID="lbl_id_parte" Text=""></asp:Label>
                <table>
                    <tr>
                        <td class="horizontal">
                            <table class="tabla_td">
                                <tr>
                                    <td class="horizontal">
                                        <label>No. Parte:</label><br />
                                        <asp:TextBox ID="TxtNo_Parte" runat="server" CssClass="cajasTexto"></asp:TextBox>
                                    </td>
                                    <td class="horizontal">
                                        <label>Pertenece a:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="True" runat="server" ID="DDLPartePerteneceA" CssClass="cajasTexto" DataSourceID="SqlDataSourcePartesPerteneceA" DataTextField="Parte_PerteneceA" DataValueField="ID">
                                            <asp:ListItem Value="NULL" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourcePartesPerteneceA" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_partes_perteneceA] WHERE ([Clasificación] = @Clasificación)">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="REDES" Name="Clasificación" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        <label>Cantidad:</label><br />
                                        <asp:TextBox ID="TxtCantidad_Parte" runat="server" CssClass="cajasTexto" TextMode="Number" ValidateRequestMode="Disabled"></asp:TextBox>
                                    </td>
                                    <td class="horizontal">
                                        <label>Tipo:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="True" ID="DDLTipo_Parte" runat="server" CssClass="cajasTexto" DataSourceID="SqlDataSourceTipo" DataTextField="Tipo" DataValueField="ID" OnSelectedIndexChanged="DDLTipo_Parte_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                      <asp:SqlDataSource ID="SqlDataSourceTipo" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_tipos]"></asp:SqlDataSource>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="horizontal">
                                        <label>Marca:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="true" ID="DDLMarca_Parte" runat="server" CssClass="cajasTexto" DataSourceID="SqlDataSourceMarca" DataTextField="Marca" DataValueField="ID" OnSelectedIndexChanged="DDLMarca_Parte_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                       <asp:SqlDataSource ID="SqlDataSourceMarca" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_marcas]"></asp:SqlDataSource>
                                    </td>
                                    <td class="horizontal">
                                        <label>Medidas:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="true" ID="DDLTamano_Parte" runat="server" CssClass="cajasTexto" DataSourceID="SqlDataSourceTam" DataTextField="Tamaño" DataValueField="ID" OnSelectedIndexChanged="DDLTamano_Parte_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                       <asp:SqlDataSource ID="SqlDataSourceTam" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_tamanos]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        <label>Modelo:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="true" ID="DDLModelo_Parte" runat="server" CssClass="cajasTexto" DataSourceID="SqlDataSourceModel" DataTextField="Modelo" DataValueField="ID" OnSelectedIndexChanged="DDLModelo_Parte_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceModel" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_modelos]"></asp:SqlDataSource>
                                    </td>


                                    <td class="horizontal">
                                        <label>Estado:</label><br />
                                        <asp:DropDownList AutoPostBack="True" AppendDataBoundItems="true" ID="DDLEstado_Parte" runat="server" CssClass="cajasTexto" DataSourceID="SqlDataSourceEstado" DataTextField="Estatus" DataValueField="ID" OnSelectedIndexChanged="DDLEstado_Parte_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                                        </asp:DropDownList>
                                      <asp:SqlDataSource ID="SqlDataSourceEstado" runat="server" ConnectionString="<%$ ConnectionStrings:inventarioConnectionString %>" SelectCommand="SELECT * FROM [vista_estatus]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="horizontal">
                            <table class="tabla_td">
                                <tr>
                                    <td class="horizontal">
                                        <asp:Image runat="server" ID="ImagePartes" Visible="false" CssClass="imagen_detalle"/>
                                        <br /><asp:Label runat="server" ID="lbl_Imagen_actual_part"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="horizontal">
                                        <label>Descripción:</label><br />
                                        <asp:TextBox runat="server" ID="TxtDescripcion_Parte" CssClass="cajasTexto" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div id="DivSlidePartes" runat="server">
                                            <table class="tabla_td">
                                                <tr>
                                                    <td>
                                                        <asp:Image runat="server" ID="Imagen_Parte1" CssClass="img1y2" Visible="false" /></td>
                                                    <td>
                                                        <asp:Image runat="server" ID="Imagen_Parte2" CssClass="img3" Visible="false" /></td>
                                                    <td>
                                                        <asp:Image runat="server" ID="Imagen_Parte3" CssClass="img1y2" Visible="false" /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button runat="server" ID="BtnAnterior_Parte" Text="Anterior" CssClass="botones" OnClick="BtnAnterior_Parte_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="Lbl_slide_parte" Text="Selecciona una imagen"></asp:Label>

                                                    </td>
                                                    <td>
                                                        <asp:Button runat="server" ID="BtnSiguiente_Parte" Text="Siguiente" CssClass="botones" OnClick="BtnSiguiente_Parte_Click" />

                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                <table class="tabla_td">
                    <tr>
                        <td class="horizontal">
                            <asp:Button ID="ButtonAceptar_Parte" runat="server" Text="Aceptar" CssClass="botones" OnClick="ButtonAceptar_Parte_Click" />
                        </td>
                        <td class="horizontal">
                            <asp:Button ID="ButtonCancelar_Parte" runat="server" Text="Cancelar" CssClass="botones" OnClick="ButtonPCancelar_Click" />
                        </td>
                        <td class="horizontal">
                            <asp:Label ID="LblExitoP_agregar" runat="server" ForeColor="#D64234"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
</asp:Content>

