<%@ Page Language="C#" MasterPageFile="~/Principal/MasterPage.Master" AutoEventWireup="true" CodeBehind="SubirArchivo.aspx.cs" Inherits="Inventario_CGSI.Principal.SubirArchivo" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Contentido" ContentPlaceHolderID="contenidoCuerpo" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>  
    <div id="divSubirImagen" runat="server" class="divTablas">
        <label class="cajasTexto" style="color:red">
            El formato requerido para las imagenes es .JPG/.JPEG
        </label>
        <asp:AjaxFileUpload ID="AjaxFileUp" runat="server" OnUploadComplete="AjaxFileUp_UploadComplete" AllowedFileTypes="jpg,jpeg"/>    
    </div>
</asp:Content>
