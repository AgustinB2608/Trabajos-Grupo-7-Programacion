<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP6_GRUPO_7.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
        .auto-style2 {
            margin-left: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p class="auto-style1">
            <strong>INICIO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        </p>
        <p class="auto-style2">
            <asp:HyperLink ID="HLSeleccionar" runat="server" NavigateUrl="~/SeleccionarProductos.aspx">Seleccionar Productos</asp:HyperLink>
        </p>
        <p class="auto-style2">
            <asp:LinkButton ID="LBEliminar" runat="server">Eliminar Productos Seleccionados</asp:LinkButton>
        </p>
        <p class="auto-style2">
            <asp:HyperLink ID="HLMostrar" runat="server" NavigateUrl="~/MostrarProductos.aspx">Mostrar Producto</asp:HyperLink>
        </p>
        <p class="auto-style2">
            &nbsp;</p>
    </form>
</body>
</html>
