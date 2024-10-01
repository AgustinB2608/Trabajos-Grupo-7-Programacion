<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP6_GRUPO_7.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
        .auto-style2 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
&nbsp;<span class="auto-style1"><strong>Grupo N°7<br />
            <br />
&nbsp;</strong><asp:HyperLink ID="hlkEjercicio1" runat="server" CssClass="auto-style2" NavigateUrl="~/Ejercicio1.aspx">Ejercicio 1</asp:HyperLink>
            <br />
            <br />
&nbsp;<asp:HyperLink ID="hlkEjercicio2" runat="server" CssClass="auto-style2" NavigateUrl="~/Ejercicio2.aspx">Ejercicio 2</asp:HyperLink>
            </span>
        </div>
    </form>
</body>
</html>
