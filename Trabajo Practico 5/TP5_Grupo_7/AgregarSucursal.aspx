<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="TP5_Grupo_7.AgregarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            font-size: x-large;
            width: 223px;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            font-size: medium;
        }
        .auto-style5 {
            height: 26px;
            width: 223px;
        }
        .auto-style6 {
            width: 223px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hplListarSucursales" runat="server" NavigateUrl="ListadoSucursales.aspx">Listado de sucursales</asp:HyperLink>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">GRUPO N°7</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <br />
                    <strong><span class="auto-style4">Agregar Sucursal</span></strong></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style6">Nombre Sucursal:</td>
                <td>
                    <asp:TextBox ID="TxtSucursal" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombreSucursal" runat="server" ControlToValidate="TxtSucursal" ErrorMessage="RequiredFieldValidator">Nombre ingresado inválido</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Descripcion:</td>
                <td>
                    <asp:TextBox ID="TxtDescripcion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Provincia:</td>
                <td>
                    <asp:DropDownList ID="DdlProvincia" runat="server">
                        <asp:ListItem>--Seleccionar--</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Direccion</td>
                <td>
                    <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>