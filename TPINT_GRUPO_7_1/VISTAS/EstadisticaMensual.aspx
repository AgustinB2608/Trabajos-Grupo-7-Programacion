<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticaMensual.aspx.cs" Inherits="VISTAS.EstadisticaMensual" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 141px;
        }
        .auto-style2 {
            height: 340px;
        }
        .auto-style3 {
            width: 29%;
        }
        .auto-style4 {
            width: 147px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <asp:Label ID="lblInformes" runat="server" Font-Bold="True" Font-Size="X-Large" Text="INFORMES"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblTituloInforme1" runat="server" Text="Estadísticas de Asistencia y Ausencia: Comparativo Mensual"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblTitulo2Informe1" runat="server"></asp:Label>
            <br />
            <br />
            <table class="auto-style3">
                <tr>
                    <td class="auto-style1" style="line-height: 5px; font-size: x-large; color: #000000; font-style: normal; font-weight: bold; right: 0px">&nbsp;&nbsp; Ausencias</td>
                    <td class="auto-style4" style="font-size: x-large; font-weight: bold; font-style: normal">&nbsp;&nbsp; Asistencias</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
