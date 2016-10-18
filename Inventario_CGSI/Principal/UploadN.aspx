<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadN.aspx.cs" Inherits="Inventario_CGSI.Principal.UploadN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" 
            onclick="btnUpload_Click" />
    </div>
    </form>
</body>
</html>
