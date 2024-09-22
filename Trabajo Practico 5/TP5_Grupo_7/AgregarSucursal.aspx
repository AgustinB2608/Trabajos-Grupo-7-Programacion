<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="TP5_Grupo_7.AgregarSucursal" UnobtrusiveValidationMode="None"%>

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
            height: 30px;
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
        #hyperlinks {
            text-align: center;
        }

        #hyperlinks a {
            display: inline-block;
            margin: 0 15px;
        }
        .auto-style7 {
            margin-left: 200px;
        }
        .auto-style8 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="hyperlinks">
            <asp:HyperLink ID="hplAgregarSucursal" runat="server" NavigateUrl="AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
            <asp:HyperLink ID="hplListarSucursales" runat="server" NavigateUrl="ListadoSucursales.aspx">Listado de sucursales</asp:HyperLink>
            <asp:HyperLink ID="hplEliminarSucursal" runat="server" NavigateUrl="EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" aria-busy="False" aria-orientation="horizontal" style="font-size: x-large; font-weight: bold">GRUPO N°7</td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <br />
                    <strong><span class="auto-style4" style="font-size: large">Agregar Sucursal<br />
                    </span></strong></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style6">Nombre Sucursal:</td>
                <td>
                    <asp:TextBox ID="TxtSucursal" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombreSucursal" runat="server" ControlToValidate="TxtSucursal" ErrorMessage="* Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Descripcion:</td>
                <td>
                    <asp:TextBox ID="TxtDescripcion" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="TxtDescripcion" ErrorMessage="* Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Provincia:</td>
                <td>
                    <asp:DropDownList ID="ddlProvincia" runat="server">
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
                <td class="auto-style7">
                    <asp:Button ID="BtnAceptar" runat="server" Text="Guardar" OnClick="BtnAceptar_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </form>
</body>
</html>