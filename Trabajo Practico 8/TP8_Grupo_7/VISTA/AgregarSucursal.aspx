<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="VISTA.AgregarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            Nombre sucursal:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNombreSucursal" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="rfvNombreSucursal" runat="server" ControlToValidate="txtNombreSucursal"></asp:RequiredFieldValidator>
        </div>
    </form>
</body>
</html>
