<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio5.aspx.cs" Inherits="TP2_Grupo_7.Ejercicio5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ejercicio 5</title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 80px;
        }
        .auto-style2 {
            margin-left: 140px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p style="margin-left: 80px">
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblConfiguracion" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Elija su configuración"></asp:Label>
        </p>
            <p style="margin-left: 80px">
            <br />
        &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblSeleccion" runat="server" Font-Bold="True" Text="Seleccione cantidad de memoria : "></asp:Label>
        </p>
            <p style="margin-left: 120px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlGB" runat="server" Height="16px" Width="122px" AutoPostBack="True">
                    <asp:ListItem Value="200">2GB</asp:ListItem>
                    <asp:ListItem Value="375">4GB</asp:ListItem>
                    <asp:ListItem Value="500">6GB</asp:ListItem>
                </asp:DropDownList>
        </p>

        <p class="auto-style1">&nbsp;&nbsp;&nbsp; Seleccione accesorios:</p>
         <asp:CheckBoxList ID="cblAccesorios" runat="server" CssClass="auto-style2" AutoPostBack="True">
             <asp:ListItem Value="2000,50">Monitor LCD</asp:ListItem>
             <asp:ListItem Value="550,50">HD 500GB</asp:ListItem>
             <asp:ListItem Value="1200">Grabador DVD</asp:ListItem>
         </asp:CheckBoxList>
            
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
        <asp:Button ID="btnCalculo" runat="server"  Text="Calcular Precio" OnClick="btnCalculo_Click" />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>

