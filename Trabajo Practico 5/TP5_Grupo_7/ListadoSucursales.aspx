<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursales.aspx.cs" Inherits="TP5_Grupo_7.ListadoSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="hyperlinks">
            <asp:HyperLink ID="hplAgregarSucursal" runat="server" NavigateUrl="AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
            <asp:HyperLink ID="hplListarSucursales" runat="server" NavigateUrl="ListadoSucursales.aspx">Listado de sucursales</asp:HyperLink>
        </div>
        <div>
            <br />
            Búsqueda ingrese id sucursal&nbsp;
            <asp:TextBox ID="txtSucursal" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="grvSucursales" runat="server">
            </asp:GridView>
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
