<%@ Page Language="C#" MasterPageFile="~/Login/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Inventario_CGSI.Login.Login" %>

<asp:Content ID="Contenido" ContentPlaceHolderID="contenidoCuerpo" Runat="Server">
    <div id="areaForma">
        <label>Correo:</label>
        <asp:TextBox CssClass="cajasTexto" ID="TextBoxUsuario" runat="server"></asp:TextBox>
        <label>Password:</label>
        <asp:TextBox CssClass="cajasTexto" TextMode="Password" ID="TextBoxPassword" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonAceptar" CssClass="botones" Text="Aceptar" runat="server" OnClick="ButtonAceptar_Click"/>
        <br />
        <asp:Label ID="error" Text="" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
    </div>
</asp:Content>