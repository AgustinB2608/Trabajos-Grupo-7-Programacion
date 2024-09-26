<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP6_GRUPO_7.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblProductos" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Productos"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="gvProductos" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
