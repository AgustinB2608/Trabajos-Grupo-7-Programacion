<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursales.aspx.cs" Inherits="TP5_Grupo_7.ListadoSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de Sucursales - TP5 Grupo 7</title>
    <style>
        #hyperlinks {
            text-align: center;
        }

        #hyperlinks a {
            display: inline-block;
            margin: 0 15px;
        }

        .espaciado {
            margin-top: 20px;
            margin-bottom: 20px;
        }

        .centrado {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="hyperlinks" class="espaciado">
            <asp:HyperLink ID="hplAgregarSucursal" runat="server" NavigateUrl="AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
            <asp:HyperLink ID="hplListarSucursales" runat="server" NavigateUrl="ListadoSucursales.aspx">Listado de sucursales</asp:HyperLink>
            <asp:HyperLink ID="hplEliminarSucursal" runat="server" NavigateUrl="EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
        </div>
        <div class="espaciado centrado">
            <asp:Label ID="lblListado" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Listado de sucursales"></asp:Label>
            <br /><br />
            Búsqueda ingrese id sucursal&nbsp;
            <asp:TextBox ID="txtSucursal" runat="server"></asp:TextBox>
            <asp:Button ID="btnFiltrar" runat="server" OnClick="Button1_Click" Text="Filtrar" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnMostrarTodos" runat="server" OnClick="btnMostrarTodos_Click" Text="Mostrar todos" />
            <br /><br />
            <asp:GridView ID="grvSucursales" runat="server"></asp:GridView>
            <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
