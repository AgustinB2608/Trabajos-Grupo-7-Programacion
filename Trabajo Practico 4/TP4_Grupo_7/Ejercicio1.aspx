<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4_Grupo_7.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
        .auto-style2 {
            width: 47%;
        }
        .auto-style5 {
            width: 153px;
            height: 35px;
        }
        .auto-style6 {
            width: 283px;
            height: 35px;
        }
        .auto-style7 {
            margin-left: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;<table class="auto-style2">
                <tr>
                    <td class="auto-style5"><span class="auto-style1">DESTINO INICIO:</span></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>PROVINCIA:&nbsp;</strong></td>
                    <td class="auto-style6">
            <asp:DropDownList ID="ddlProvincias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged" Height="19px">
            </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>LOCALIDAD:&nbsp;<br />
            </strong>
                    </td>
                    <td class="auto-style6">
            <asp:DropDownList ID="ddlLocalidadesInicio" runat="server" Height="19px" Width="111px">
            </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
            <span class="auto-style1">DESTINO FINAL:</span></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>PROVINCIA:</strong></td>
                    <td class="auto-style6"><strong> 
            <asp:DropDownList ID="ddlProvinciaFinal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaFinal_SelectedIndexChanged" Height="19px">
            </asp:DropDownList>
            </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>LOCALIDAD:</strong></td>
                    <td class="auto-style6"><strong>
            <asp:DropDownList ID="ddlLocalidadesFinal" runat="server" Height="19px" Width="112px">
            </asp:DropDownList>
            </strong>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnConfirmar" runat="server" OnClick="Button1_Click" Text="Aceptar" />
        <div class="auto-style7">
            <asp:Label ID="lblMensaje" runat="server" Text="mensaje"></asp:Label>
        </div>
        <br />
    </form>
</body>
</html>
