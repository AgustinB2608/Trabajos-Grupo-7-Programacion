<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio5.aspx.cs" Inherits="TP2_Grupo_7.Ejercicio5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                <asp:DropDownList ID="ddlGB" runat="server" Height="16px" Width="122px">
                    <asp:ListItem>2GB</asp:ListItem>
                    <asp:ListItem>4GB</asp:ListItem>
                    <asp:ListItem>6GB</asp:ListItem>
                </asp:DropDownList>
        </p>

        <p class="auto-style1">&nbsp;&nbsp;&nbsp; Seleccione accesorios:</p>
         <asp:CheckBoxList ID="cblAccesorios" runat="server" CssClass="auto-style2">
             <asp:ListItem Value="2000,50">Monitor LCD</asp:ListItem>
             <asp:ListItem>HD 500GB</asp:ListItem>
             <asp:ListItem>Grabador DVD</asp:ListItem>
         </asp:CheckBoxList>
            
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
        <asp:Button ID="btnCalculo" runat="server"  Text="Button" OnClick="btnCalculo_Click" />
    </form>
</body>
</html>

