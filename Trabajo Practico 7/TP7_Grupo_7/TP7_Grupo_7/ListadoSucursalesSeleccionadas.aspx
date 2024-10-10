<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionadas.aspx.cs" Inherits="TP7_Grupo_7.ListadoSucursalesSeleccionadas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hklListadoSucu" runat="server" NavigateUrl="ListadoSucursalesSeleccionadas.aspx">Lisatado de sucursales</asp:HyperLink>
&nbsp;&nbsp;
            <asp:HyperLink ID="hkMostrarSucu" runat="server" NavigateUrl="SeleccionarSucursales.aspx">Mostrar sucursales seleccionadas</asp:HyperLink>
        </div>
    </form>
</body>
</html>
