<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarProductos.aspx.cs" Inherits="TP6_GRUPO_7.MostrarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Productos seleccionados por el usuario:<br />
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx">Volver al inicio</asp:HyperLink>
        </div>
    </form>
</body>
</html>
