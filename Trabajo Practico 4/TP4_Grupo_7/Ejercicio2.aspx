<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4_Grupo_7.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp; IdProducto:&nbsp;
            <asp:DropDownList ID="ddlProducto" runat="server">
                <asp:ListItem Value="1">Igual a:</asp:ListItem>
                <asp:ListItem Value="2">Mayor a:</asp:ListItem>
                <asp:ListItem Value="3">Menor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtProducto" runat="server" CssClass="auto-style1" Height="19px" Width="250px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp; IdCategoria:
            <asp:DropDownList ID="ddlCategoria"  runat="server" AutoPostBack="true">
                <asp:ListItem Value="1">Igual a:</asp:ListItem>
                <asp:ListItem Value="2">Mayor a:</asp:ListItem>
                <asp:ListItem Value="3">Menor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCategoria" runat="server" Height="19px" Width="250px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnQuitar" runat="server"  Text="Quitar Filtro" OnClick="btnQuitar_Click" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:GridView ID="GvProductos" runat="server">
            </asp:GridView>
            </div>
    </form>
</body>
</html>
